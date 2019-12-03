using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class CadastroPage : TestBase
    {
        public static By TextFirstName()
        {
            return By.Id("customer_firstname");         
        }

        public static By TextLastName()
        {
            return By.Id("customer_lastname");
        }

        public static By TextPassword()
        {
            return By.Id("passwd");
        }

        public static By AddressFirstName()
        {
            return By.Id("firstname");
        }

        public static By AddressLastName()
        {
            return By.Id("lastname");
        }

        public static By Address()
        {
            return By.Id("address1");
        }

        public static By AddressCity()
        {
            return By.Id("city");
        }

        public static By AddresStates()
        {
            return By.Id("id_state");
        }

        public static By OptionStateArizona()
        {
            return By.XPath("//select[@id='id_state']/option[@value='3']");
        }

        public static By AddressPostalCode()
        {
            return By.Id("postcode");
        }

        public static By TextMobilePhone()
        {
            return By.Id("phone_mobile");
        }

        public static By AddressReference()
        {
            return By.Id("alias");
        }

        public static By BtnRegister()
        {
            return By.Id("submitAccount");
        }

    }
}
