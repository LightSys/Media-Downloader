using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace MoveCute
{
    public class FileSync
    {
        private static readonly Dictionary<string, string> DateUnitToRegex = new Dictionary<string, string>
        {
            // TODO: these currently accept any numbers and could be changed to only include valid numbers
            {"yyyy", @"\d{4}"},
            {"yy", @"\d{2}"},
            {"y", @"\d{1,2}"},
            {"MM", @"\d{2}"},
            {"M", @"\d{1,2}"},
            {"dd", @"\d{2}"},
            {"d", @"\d{1,2}"},
            {"hh", @"\d{2}"},
            {"h", @"\d{1,2}"},
            {"HH", @"\d{2}"},
            {"H", @"\d{1,2}"},
            {"mm", @"\d{2}"},
            {"m", @"\d{1,2}"},
            {"ss", @"\d{2}"},
            {"s", @"\d{1,2}"},
            {"tt", @"[AP]M"},
            {"t", @"[AP]"},
        };

        public string DestPath { get; set; }
        public string SrcMacro { get; set; }
        public string SrcPath { get { return EvaluateMacro(SrcMacro); } }

        public static readonly DateTime InvalidDateTime = DateTime.MinValue;
        
        override public string ToString()
        {
            return SrcMacro + " -> " + DestPath;
        }
        /// <summary>
        ///     Gets the file path that matches the given macro.
        ///     The first encountered file path is returned if no date units are specified.
        ///     If no matches are found, the empty string is returned.
        /// </summary>
        /// <param name="macro">The macro which can contain date units in braces and asterisk wildcards.</param>
        /// <returns>
        ///     A file path or the empty string
        /// </returns>
        public static string EvaluateMacro(string macro)
        {
            string[] potentialMatches = FindPotentialFileMatches(macro);
            if (potentialMatches == null || potentialMatches.Length == 0)
            {
                return "";
            }
            
            Console.WriteLine("\r\n\r\n\r\n");
            Console.WriteLine("potentials:");
            foreach (string path in potentialMatches) Console.WriteLine(path);

            string dateFormat = "";
            Regex pathMatcher = GenerateFilterRegex(macro, ref dateFormat);
            
            string output = "";
            TimeSpan shortestSpan = new TimeSpan(long.MaxValue);
            DateTime now = DateTime.Now;

            //TODO: Add other selection criteria (currently only closest to current date and not future)
            //TODO: maybe expose some var which says whether or not a valid future match was found

            Console.WriteLine("df: " + dateFormat);
            Console.WriteLine("files: ");
            foreach (string path in potentialMatches)
            {
                Console.Write(path);

                if (!pathMatcher.IsMatch(path))
                {
                    Console.WriteLine("");
                    continue;
                }

                Console.Write("<---matches");

                if (dateFormat == "")
                {
                    Console.WriteLine("");
                    return path; // no format string provided, return first match
                }
                
                DateTime fileDate = CalculateFileDate(pathMatcher, path, dateFormat);

                if (fileDate == InvalidDateTime) continue;

                TimeSpan diff = now - fileDate;

                Console.Write(diff.TotalMinutes);
                if (fileDate < now && diff < shortestSpan)
                {
                    shortestSpan = diff;
                    output = path;
                }
                
                Console.WriteLine("");
            }

            if (output == "") return "";

            return output;
        }


        public static string[] FindPotentialFileMatches(string macro)
        {
            if (string.IsNullOrWhiteSpace(macro)) return default;
            string basePath = "";

            // replace all filters with '*'
            Regex braceContain = new Regex(@"\{.+?\}");
            string starredStr = braceContain.Replace(macro, "*");

            // remove everything after first '*'
            int index = starredStr.IndexOf('*');
            if (index > -1) basePath = starredStr.Substring(0, index);
            else basePath = string.Copy(starredStr);

            // remove everything after last '\'
            index = basePath.LastIndexOf('\\');
            if (index > -1) basePath = basePath.Substring(0, index);
            else return default;

            // remove front of starredStr
            index = starredStr.LastIndexOf('\\');
            if (index > -1) starredStr = starredStr.Substring(index + 1);
            // Unsure whether or not this if statement can fail

            // squash stars
            starredStr = new Regex(@"\*+").Replace(starredStr, "*");

            DirectoryInfo di = new DirectoryInfo(basePath);
            
            if (di.Exists) return Directory.GetFiles(basePath, starredStr, SearchOption.AllDirectories);
            return default;
        }

        public static Regex GenerateFilterRegex(string macro, ref string dateFormatStr)
        {
            string regexStr = "";
            int i = 0;
            while (i < macro.Length)
            {
                char ch = macro[i++];
                if (ch == '{')
                {
                    string dateToken = "";
                    ch = macro[i++]; // skip over '{'
                    while (ch != '}') 
                    {
                        dateToken += ch;
                        ch = macro[i++];
                        if (i == macro.Length) throw new ArgumentException(@"Mismatched ""{"". If the filename has ""{"", try ""{{}"".");
                    }
                    regexStr += GetTokenRegexStr(dateToken, ref dateFormatStr);
                }
                else if (ch == '*')
                {
                    regexStr += @"[^\\]*";
                }
                else //any other character
                {
                    regexStr += Regex.Escape(ch.ToString());
                }
            }
            
            regexStr = "^" + regexStr + "$";
            return new Regex(regexStr);
        }

        public static string GetTokenRegexStr(string dateToken, ref string dateFormatStr)
        {
            Regex repeatMatcher = new Regex(@"(.)\1*");
            MatchCollection matches = repeatMatcher.Matches(dateToken);

            string tokenRegexStr = "";
            foreach (Match match in matches)
            {
                string repeat = match.Value;
                tokenRegexStr += "(" + GetRegexFromDateUnit(repeat, ref dateFormatStr) + ")";
            }

            return tokenRegexStr;
        }

        public static string GetRegexFromDateUnit(string dateUnit, ref string dateFormatStr)
        {
            if (DateUnitToRegex.ContainsKey(dateUnit))
            {
                dateFormatStr += dateUnit + "&";
                return DateUnitToRegex[dateUnit];
            }

            // no defined dateUnit found
            dateFormatStr += "'" + dateUnit + "'&";

            return Regex.Escape(dateUnit);
        }

        public static DateTime CalculateFileDate(Regex pathMatcher, string filePath, string dateUnits)
        {
            if (string.IsNullOrEmpty(dateUnits)) throw new ArgumentException("empty dateUnits.");
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("empty filepath.");

            string pathDateString = ExtractDateString(pathMatcher, filePath);

            if (string.IsNullOrEmpty(pathDateString)) throw new ArgumentException("empty pathDateString. Not sure how.");
            
            try
            {
                return DateTime.ParseExact(pathDateString, dateUnits, new CultureInfo("en-US"));
            }
            catch (FormatException)
            {
                // the regex captured an invalid value
                // invalid examples: 13-32 for {MM-dd}, 0 for {M}, 11-12 for {MM-MM}
                // some valid examples to note: 12-12 for {MM-MM}, 1-1 for {h-H}, 3-03 for {m-mm}

                return InvalidDateTime;
            }
        }

        /// <summary>
        /// Captures a date string from a file path, given the regex that identifies the date units.
        /// </summary>
        /// <param name="pathMatcher">Regular expression to capture the date units.</param>
        /// <param name="filePath">A file path that should fully match pathMatcher</param>
        /// <returns></returns>
        public static string ExtractDateString(Regex pathMatcher, string filePath)
        {
            if (!pathMatcher.IsMatch(filePath))
            {
                throw new ArgumentException("filePath doesn't match pathMatcher: " + filePath + " " + pathMatcher);
            }

            GroupCollection groups = pathMatcher.Match(filePath).Groups;
            string pathDateString = "";

            for (int i = 1; i < groups.Count; i++) //skip index 0, which contains full match
            {
                Group group = groups[i];
                var unit = group.Value;

                pathDateString += group.Value + "&";
            }
            return pathDateString;
        }
    }
}
