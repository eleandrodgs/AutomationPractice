using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class HomePage : TestBase
    {
        #region Elements

        public static By InputSearch()
        {
            return By.Id("search_query_top");
        }

        public static By ProductBlouse()
        {
            return By.XPath("//ul[@id='homefeatured']//li[2]");
        }

        #endregion

    }
}
