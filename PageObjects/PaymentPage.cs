using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class PaymentPage : TestBase
    {
        #region Elements

        public static By OptionPayByCheck()
        {
            return By.XPath("//div[@id='HOOK_PAYMENT']//a[@class='cheque']");
        }

        public static By BtnConfirmOrder()
        {
            return By.XPath("//p[@id='cart_navigation']//button");
        }

        public static By TotalCompra()
        {
            return By.XPath("//span[@id='total_price']");
        }
        #endregion
    }
}
