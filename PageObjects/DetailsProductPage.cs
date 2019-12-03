using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class DetailsProductPage : TestBase
    {
        #region Elements

        public static By BtnAddToCart()
        {
            return By.XPath("//body[@id='product']//p[@id='add_to_cart']/button");
        }

        public static By BtnProceedToCheckout()
        {
            return By.XPath("//div[@id='layer_cart']//a[@title='Proceed to checkout']");
        }

        #endregion

    }
}
