using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoveCute;
using System.Text.RegularExpressions;

namespace MoveCuteTests
{
    [TestClass]
    public class FileSyncTests
    {
        [TestMethod]
        public void TestGetRegexFromDateUnitDictionary()
        {
            string dateFormat = "";
            
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("yyyy", ref dateFormat), @"\d{4}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("h", ref dateFormat), @"\d{1,2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("HH", ref dateFormat), @"\d{2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("H", ref dateFormat), @"\d{1,2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("mm", ref dateFormat), @"\d{2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("m", ref dateFormat), @"\d{1,2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("ss", ref dateFormat), @"\d{2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("s", ref dateFormat), @"\d{1,2}");
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("tt", ref dateFormat), @"[AP]M");
            Assert.AreEqual(dateFormat, @"yyyy&h&HH&H&mm&m&ss&s&tt&");
        }

        [TestMethod]
        public void TestGetRegexFromDateUnitUndefined()
        {
            string dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("f", ref dateFormat), "f");
            Assert.AreEqual(dateFormat, "'f'&");

            dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("ff", ref dateFormat), "ff");
            Assert.AreEqual(dateFormat, "'ff'&");

            dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("asdf", ref dateFormat), "asdf");
            Assert.AreEqual(dateFormat, "'asdf'&");

            dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit(" ", ref dateFormat), @"\ ");
            Assert.AreEqual(dateFormat, "' '&");

            dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("*", ref dateFormat), @"\*");
            Assert.AreEqual(dateFormat, "'*'&");

            dateFormat = "";
            Assert.AreEqual(FileSync.GetRegexFromDateUnit("#", ref dateFormat), @"\#");
            Assert.AreEqual(dateFormat, "'#'&");
        }

        [TestMethod]
        public void TestGetTokenRegexStr()
        {
            string dateFormat = "";
            Assert.AreEqual(FileSync.GetTokenRegexStr("yy-MM-dd", ref dateFormat), @"(\d{2})(-)(\d{2})(-)(\d{2})");
            Assert.AreEqual(FileSync.GetTokenRegexStr("d", ref dateFormat), @"(\d{1,2})");
        }

        [TestMethod]
        public void TestExtractDateStringSuccess()
        {
            Regex regex = new Regex(@"^C:\\Music\\(\d{4}-\d{2}-\d{2})\ recording.mp3$");
            string path = @"C:\Music\2020-01-31 recording.mp3";
            Assert.AreEqual(FileSync.ExtractDateString(regex, path), "2020-01-31&");

            regex = new Regex(@"^C:\\Music\\(\d{4}-\d{2}-\d{2})\ recording.mp3$");
            path = @"C:\Music\2020-01-30 recording.mp3";
            Assert.AreEqual(FileSync.ExtractDateString(regex, path), "2020-01-30&");
        }

        [TestMethod]
        public void TestExtractDateStringExceptions()
        {
            Regex regex = new Regex(@"^C:\\Music\\(\d{4}-\d{2}-\d{2})\ recording.mp3$");
            string path = @"C:\Music\2020-01-30.mp3";
            try { FileSync.ExtractDateString(regex, path); Assert.Fail(); }
            catch { Assert.IsTrue(true); }

            regex = new Regex(@"^C:\\Music\\(\d{4}-\d{2}-\d{2})\ recording.mp3$");
            path = @"C:\Music\2020-01-3 recording.mp3";
            try { FileSync.ExtractDateString(regex, path); Assert.Fail(); }
            catch { Assert.IsTrue(true); }
        }
    }
}
