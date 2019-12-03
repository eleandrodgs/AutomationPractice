using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class HomeController : HomePage
    {
        #region Clicks

        public static void ClickProductBlouse()
        {
            Loger = "Click no produto Blouser";
            Util.Click(ProductBlouse());
        }

        #endregion

        #region SendKeys

        public static void SetSearch(string text)
        {
            Loger = "Buscando pelo produto: " + text;
            Util.SendKeys(InputSearch(), text + Keys.Enter);     
        }

        #endregion

    }
}
