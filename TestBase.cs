using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice
{
    public class TestBase
    {
        protected IWebDriver Driver;

        public TestContext TestContext { get; set; }

        [TestInitialize]
        public void InitializeTest()
        {
            Driver = new ChromeDriver(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Data\chromedriver.exe"));
        }

        [TestCleanup]
        public void CleanUpTest()
        {
            if (Driver != null)
                Driver.Quit();
        }
    }
}
