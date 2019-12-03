using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class AddressesPage : TestBase
    {
        #region Elements

        public static By DeliveryAddressFirstName()
        {
            return By.XPath("//ul[@id='address_delivery']/li[@class='address_firstname address_lastname']");
        }

        public static By DeliveryAddressLastName()
        {
            return By.XPath("//ul[@id='address_delivery']/li[@class='address_address1 address_address2']");
        }     

        public static By BtnProceedToCheckout()
        {
            return By.XPath("//button[@name='processAddress']");
        }

        #endregion
    }
}
