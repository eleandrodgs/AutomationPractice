using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class ShippingPage : TestBase
    {
        #region Elements

        public static By CheckAceiteTermos()
        {
            return By.XPath("//input[@id='cgv']");
        }

        public static By BtnProceedToCheckout()
        {
            return By.XPath("//button[@name='processCarrier']");
        }

        #endregion
    }
}
