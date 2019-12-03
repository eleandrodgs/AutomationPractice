using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice
{
    public class TestBase
    {
        #region Globals

        public const int DefaulTimeOut = 30;
        private static IWebDriver _webDriver;
        public static EventFiringWebDriver Driver;
        public static Actions Action;
        public string Url { get; set; }      
        public string User { get; set; }
        public string Password { get; set; }
        public string Browser { get; set; }
        public string ExtentFileName;
        public static string TestResultsDirectory;
        public static string EvidenceFileName;
        public static string TestInfo;
        public static string Loger = string.Empty;
        public string Description = string.Empty;
        public string Title = string.Empty;
        public ExtentReports Extent;
        public static ExtentTest Test;
        public static Screenshot Screenshot;
        public ExtentHtmlReporter HtmlReporter;

        #endregion

        #region Attr

        [TestInitialize()]
        public void MyTestInitialize()
        {
            string testCase = TestContext.TestName;

            if (testCase.Contains("API"))
            {
                InitializeAPI();
            }
            else if (testCase.Contains("Front"))
            {
                InitializeFront();
            }
        }


        public void InitializeFront()
        {
            TestResultsDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestResults", DateTime.Now.ToString("dd-MM-yyyy hh_mm_ss"));

            ExtentFileName = Path.Combine(TestResultsDirectory, TestContext.TestName + '_' + DateTime.Now.ToString("ddMMyyyy_hhmmss") + ".html");

            if (!Directory.Exists(TestResultsDirectory))
            {
                Directory.CreateDirectory(TestResultsDirectory);
            }

            if (!File.Exists(ExtentFileName))
            {
                File.Create(ExtentFileName);
            }

            HtmlReporter = new ExtentHtmlReporter(ExtentFileName);
            Extent = new ExtentReports();
            Extent.AttachReporter(HtmlReporter);

            Test = Extent.CreateTest(TestContext.TestName + " " + Title, Description);

            GetDriverBrowser();
            Driver = new EventFiringWebDriver(_webDriver);
            Action = new Actions(Driver);
            SetEnviornment();
            Driver.Manage().Window.Position = new System.Drawing.Point(1000, 0);
            Driver.Navigate().GoToUrl(Url);
            Driver.Manage().Window.Maximize();

            Driver.ElementValueChanged += FiringDriver_ElementValueChanged;
            Driver.ElementClicked += Driver_ElementClicked;

        }


        public void InitializeAPI()
        {
            var dateTimeNow = $"{DateTime.Now:yyyy-MM-ddThh_mm_ss}";

            TestResultsDirectory = $"C:\\TestsAPI{Environment.UserName}_{dateTimeNow}\\In";

            if (!Directory.Exists(TestResultsDirectory))
            {
                Directory.CreateDirectory(TestResultsDirectory);
            }

            EvidenceFileName = Path.Combine(TestResultsDirectory, $"{dateTimeNow}.txt");
        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
            string testCase = TestContext.TestName;

            if (testCase.Contains("API"))
            {
                CleanUpAPI();
            }
            else if (testCase.Contains("Front"))
            {
                CleanUpFront();
            }
        }

        public void CleanUpAPI()
        {
            Logger($"Tests: {TestContext.TestName} was {TestContext.CurrentTestOutcome}.");

            Logger($"Tests: {TestContext.TestName} was finished.");

            TestContext.AddResultFile(EvidenceFileName);
        }

        public void CleanUpFront()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                Test.Fail(GetErrorMessage());
            }

            Extent.Flush();
            Driver.Quit();
            _webDriver.Quit();
            HtmlReporter.Stop();

            using (var sw = new StreamWriter(ExtentFileName, true))
            {
                sw.WriteLine("<style>img {border: 1px solid #ddd;border-radius: 4px;padding: 5px;width: 150px;} img:hover {box-shadow: 0 0 2px 1px rgba(0, 140, 186, 0.5);}</style><script>function OpenImage(src){ var newTab = window.open(); newTab.document.body.innerHTML = " + '"' + "<img src=" + '"' + " + src + " + '"' + ">" + '"' + ";}</script>");
                sw.Close();
            }

            Extent = null;
            HtmlReporter = null;
            Test = null;
            Loger = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            ExecuteCmd("taskkill /im chromedriver.exe /f /t");
            TestContext.AddResultFile(ExtentFileName);
        }

        #endregion

        #region Properties

        private TestContext mTestContext;
        public TestContext TestContext
        {
            get
            {
                return mTestContext;
            }
            set
            {
                mTestContext = value;
            }
        }

        #endregion

        #region Methods

        public void Logger(string info)
        {
            using (StreamWriter sw = new StreamWriter(EvidenceFileName, true))
            {
                sw.WriteLine($"{DateTime.Now:yyyy-MM-ddThh_mm_ss} {info}");
            }
        }

        public void SetEnviornment()
        {
            using (var sr =
                new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Ambiente.txt")))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line != null && line.Contains("Url:"))
                    {
                        Url = line.Split(new[] { "Url:" }, StringSplitOptions.None).Last().Trim();
                    }                  

                }
            }
        }

        public void GetDriverBrowser()
        {            
            SetBrowser();
            if (Browser.Equals("Chrome"))
            {
                _webDriver = new ChromeDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));


            }
            else if (Browser.Equals("Firefox"))
            {
                _webDriver = new FirefoxDriver(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Drivers"));
            }

        }

        private void SetBrowser()
        {
            using (var sr =
                new StreamReader(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "Ambiente.txt")))
            {
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    if (line != null && line.Contains("Browser:"))
                    {
                        Browser = line.Split(new[] { "Browser:" }, StringSplitOptions.None).Last().Trim();
                    }
                }
            }

        }

        public string GetErrorMessage()
        {
            const BindingFlags privateGetterFlags = BindingFlags.GetField |
                                                    BindingFlags.GetProperty |
                                                    BindingFlags.NonPublic |
                                                    BindingFlags.Instance |
                                                    BindingFlags.FlattenHierarchy;

            var mMessage = string.Empty; // Returns empty if TestOutcome is not failed
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                // Get hold of TestContext.m_currentResult.m_errorInfo.m_stackTrace (contains the stack trace details from log)
                var field = TestContext.GetType().GetField("m_currentResult", privateGetterFlags);
                if (field != null)
                {
                    var mCurrentResult = field.GetValue(TestContext);
                    field = mCurrentResult.GetType().GetField("m_errorInfo", privateGetterFlags);
                    if (field != null)
                    {
                        var mErrorInfo = field.GetValue(mCurrentResult);
                        field = mErrorInfo.GetType().GetField("m_stackTrace", privateGetterFlags);
                        if (field != null) mMessage = field.GetValue(mErrorInfo) as string;
                    }
                }
            }

            return mMessage;
        }


        public List<KeyValuePair<string, string>> ExecuteCmd(string command)
        {
            var process = new Process();
            var list = new List<KeyValuePair<string, string>>();

            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/C " + command;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.Start();
            process.WaitForExit();

            list.Add(new KeyValuePair<string, string>("Output", process.StandardOutput.ReadToEnd()));
            list.Add(new KeyValuePair<string, string>("Error", process.StandardError.ReadToEnd()));

            System.Threading.Thread.Sleep(3000);

            return list;
        }

        public static void Checkpoint(bool condition, string message)
        {
            Screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            EvidenceFileName = Path.Combine(TestResultsDirectory, "evidence" + DateTime.Now.ToString("ddMMyyyyThhmmss") + ".png");

            Screenshot.SaveAsFile(EvidenceFileName, ScreenshotImageFormat.Png);

            TestInfo = "<h5>CheckPoint: " + message + "</h5><br/><a target='_blank' onclick=OpenImage('data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "')><img src='data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "' alt='Forest'></a>";

            if (condition)
            {
                Test.Pass(TestInfo);

                File.Delete(EvidenceFileName);
            }
            else
            {
                Test.Fail(TestInfo);

                File.Delete(EvidenceFileName);

                Assert.Fail(message);
            }
        }

        public static string ConvertImageToBase64(string fileName)
        {
            var imageArray = File.ReadAllBytes(fileName);
            return Convert.ToBase64String(imageArray);
        }

        public string GetDescription(WebElementEventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(e.Element.GetAttribute("id")))
                {
                    return e.Element.TagName + " " + e.Element.GetAttribute("type") + " [Id=" + e.Element.GetAttribute("id") + ']';
                }

                if (!String.IsNullOrEmpty(e.Element.GetAttribute("class")))
                {
                    return e.Element.TagName + " " + e.Element.GetAttribute("type") + " [Class=" + e.Element.GetAttribute("class") + ']';
                }

                if (!String.IsNullOrEmpty(e.Element.GetAttribute("name")))
                {
                    return e.Element.TagName + " " + e.Element.GetAttribute("type") + " [Name=" + e.Element.GetAttribute("name") + ']';
                }

                if (!String.IsNullOrEmpty(e.Element.GetAttribute("innertext")))
                {
                    return e.Element.TagName + " " + e.Element.GetAttribute("type") + " [InnerText=" + e.Element.GetAttribute("innertext") + ']';
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return "";
        }

        #endregion

        #region Events

        public void FiringDriver_ElementValueChanged(object sender, WebElementEventArgs e)
        {
            Screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            EvidenceFileName = Path.Combine(TestResultsDirectory, "evidence" + DateTime.Now.ToString("ddMMyyyyThhmmss") + ".png");

            Screenshot.SaveAsFile(EvidenceFileName, ScreenshotImageFormat.Png);

            TestInfo = "<h5>" + Loger + "</h5><br/>ElementValueChanged: " + GetDescription(e) + "<br/><a target='_blank' onclick=OpenImage('data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "')><img src='data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "' alt='Forest'></a>";

            Test.Info(TestInfo);

            File.Delete(EvidenceFileName);

            Loger = String.Empty;
        }     

        private void Driver_ElementClicked(object sender, WebElementEventArgs e)
        {
            Screenshot = ((ITakesScreenshot)Driver).GetScreenshot();

            EvidenceFileName = Path.Combine(TestResultsDirectory, "evidence" + DateTime.Now.ToString("ddMMyyyyThhmmss") + ".png");

            Screenshot.SaveAsFile(EvidenceFileName, ScreenshotImageFormat.Png);

            TestInfo = "<h5>" + Loger + "</h5><br/>ElementClicked: " + GetDescription(e) + "<br/><a target='_blank' onclick=OpenImage('data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "')><img src='data:image/png;base64," + ConvertImageToBase64(EvidenceFileName) + "' alt='Forest'></a>";

            Test.Info(TestInfo);

            File.Delete(EvidenceFileName);

            Loger = String.Empty;
        }    

        #endregion

    }
}
