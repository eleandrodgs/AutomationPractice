using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationPractice.TestsWeb
{
    [TestClass]
    public class Compra : TestBase
    {
        [TestMethod]
        [Description("Validar a realização de uma compra com sucesso")]
        public void RealizarUmaCompraComSucesso()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com");
        }
    }
}
