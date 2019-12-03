using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class OrderConfirmationPage : TestBase
    {
        #region Elements

        public static By AlertSucess()
        {
            return By.XPath("//p[@class='alert alert-success']");
        }

        #endregion
    }
}
