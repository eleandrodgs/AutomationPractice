using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
   public class CartSummaryPage : TestBase
    {
        #region Elements

        public static By QuantityProducts()
        {
            return By.XPath("//span[@id='summary_products_quantity']");
        }

        public static By BtnProceedToCheckout()
        {
            return By.XPath("//p[@class='cart_navigation clearfix']/a[@title='Proceed to checkout']");
        }

        #endregion

    }
}
