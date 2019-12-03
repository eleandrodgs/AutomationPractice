using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class AuthenticationController : AuthenticationPage
    {
        #region Clicks
        
        public static void ClickBtnCreateAccount()
        {
            Loger = "Clique no botão 'Create an account'";
            Util.Click(BtnCreateAccount());
        }

        #endregion

        #region SendKeys
               
        public static void SetEmailAddress(string text)
        {
            Loger = "Informando o email: " + text;
            Util.SendKeys(TextEmailAddress(), text);
        }
        #endregion

    }
}
