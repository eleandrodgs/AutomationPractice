using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class ResultadoController : PageObjects.ResultadoPage
    {
        #region Clicks

        public static void ClickProduct()
        {
            Loger = "Clique no produto";
            Util.Click(Resultado()).Click();         
        }

        #endregion
    }
}
