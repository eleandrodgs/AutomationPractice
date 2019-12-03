using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class AuthenticationPage : TestBase
    {
        #region Elements

        public static By TextEmailAddress()
        {
            return By.Id("email_create");
        }

        public static By BtnCreateAccount()
        {
            return By.Id("SubmitCreate");
        }

        #endregion

    }
}
