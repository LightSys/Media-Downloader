using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace MoveCute
{
    public class FileSync
    {
        private static Dictionary<string, string> DateUnitToRegex = new Dictionary<string, string>
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

            Regex pathMatcher = GenerateFilterRegex(macro, out string dateFormat);
            
            string output = "";
            TimeSpan shortestSpan = new TimeSpan(long.MaxValue);
            DateTime now = DateTime.Now;

            //TODO: Add other selection criteria (currently only closest to current date and not future)

            string dateUnits = ExtractDateUnits(macro);

            foreach (string path in potentialMatches)
            {
                if (!pathMatcher.IsMatch(path)) continue;
                
                if (dateUnits == "") return path; // no format string provided, return first match
                
                DateTime fileDate = CalculateFileDate(pathMatcher, path, dateUnits);
                TimeSpan diff = now - fileDate;

                if (fileDate < now && diff < shortestSpan)
                {
                    shortestSpan = diff;
                    output = path;
                }

            }

            if (output == "") return "";

            return output;
        }



        private static string[] FindPotentialFileMatches(string macro)
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

        private static Regex GenerateFilterRegex(string macro, out string dateFormatStr)
        {
            string regexStr = "";
            int i = 0;
            while (i < macro.Length)
            {
                char ch = macro[i++];
                if (ch == '{')
                {
                    string dateToken = "";
                    while (ch != '}') //TODO: doesn't this need a length check?
                    {
                        ch = macro[i++];
                        dateToken += ch;
                    }
                    regexStr += GetTokenRegexStr(dateToken);
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
            
            dateFormatStr = ""; //TODO: deleteme

            regexStr = "^" + regexStr + "$";
            return new Regex(regexStr);
        }

        private static string GetTokenRegexStr(string dateToken)
        {
            //dateToken examples: "YYYY", "MMDD", "YY-MM-DD"
            string tokenRegexStr = "";
            char currentAtom = '\0';
            string currentDateUnit;
            int i = 0;
            while (i < dateToken.Length)
            {
                char ch = dateToken[i++];
                if (ch != currentAtom)
                {
                    currentAtom = ch;
                    currentDateUnit = "";
                    while (ch == currentAtom && i < dateToken.Length)
                    {
                        currentDateUnit += ch;
                        ch = dateToken[i++];
                    }
                    //TODO: wrap currentDateUnit in parens to atomize further - needed for duplicate removal
                    tokenRegexStr += GetRegexFromDateUnit(currentDateUnit);
                    i--;
                }
            }

            return "(" + tokenRegexStr + ")";
        }

        private static string GetRegexFromDateUnit(string dateUnit)
        {
            if (DateUnitToRegex.ContainsKey(dateUnit))
            {
                return DateUnitToRegex[dateUnit];
            }

            // no defined dateUnit found
            return Regex.Escape(dateUnit);
        }

        private static DateTime CalculateFileDate(Regex pathMatcher, string filePath, string dateUnits)
        {
            string pathDateString = ExtractDateString(pathMatcher, filePath);
            // TODO: remove corresponding duplicate date unit - maybe do inside of ExtractDateString?
            return DateTime.ParseExact(pathDateString, dateUnits, new CultureInfo("en-US"));
        }

        /// <summary>
        /// Extracts the date units from the macro by concatenating braced strings.
        /// </summary>
        /// <param name="macro"></param>
        /// <returns></returns>
        private static string ExtractDateUnits(string macro)
        {
            //TODO: Probably construct this inside of GetTokenRegexStr instead of here.
            // also should make non-defined date units into ParseExact literals.

            Regex braceContain = new Regex(@"\{(.+?)\}");
            MatchCollection matches = braceContain.Matches(macro);
            string dateUnits = "";
            foreach (Match match in matches)
            {
                dateUnits += match.Groups[1].Captures[0].Value + "-";
            }

            return dateUnits;
        }

        /// <summary>
        /// Extracts a date string from a file path, given the regex that identifies the date units.
        /// </summary>
        /// <param name="pathMatcher">Regular expression to capture the date units.</param>
        /// <param name="filePath">A file path that should fully match pathMatcher</param>
        /// <returns></returns>
        private static string ExtractDateString(Regex pathMatcher, string filePath)
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
                pathDateString += group.Value + "-";
            }
            return pathDateString;
        }
    }
}
