using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.PageObjects
{
    public class ResultadoPage : TestBase
    {
        #region Elements

        public static By Resultado()
        {
            return By.XPath("//*[@id='center_column']/ul/li/div/div[1]/div/a[1]/img");            
        }

        #endregion
    }
}
