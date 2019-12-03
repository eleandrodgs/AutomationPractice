using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.TestsAPI
{
    [TestClass]
    public class CarrinhoDeCompra : TestBase
    {
        [TestMethod]
        [Description("Validação do shopping_cart")]
        public void CarrinhoTesteAPI()
        {
            #region Params

            string validation_totalshipping = "2.00";
            #endregion

            #region Steps

            IRestResponse resposta = Util.TestGet("shopping_cart");
            var responseconverted = JObject.Parse(resposta.Content);
            string total_shipping = responseconverted.GetValue("total_shipping").ToString();

            if (HttpStatusCode.OK == resposta.StatusCode && total_shipping.Equals(validation_totalshipping))
            {
                Logger("Endpoint: " + resposta.ResponseUri);
                Logger("Code response: " + resposta.StatusCode);
                Logger("Body response:" + resposta.Content);
                Logger("Total shipping retornado: " + total_shipping);
            }
            else
            {
                Logger("Endpoint: " + resposta.ResponseUri);
                Logger("TESTE FALHOU: " + resposta.StatusCode + " " + resposta.ErrorMessage + " " + resposta.Content);
                Logger("Total shipping retornado:" + total_shipping);
            }
            Assert.AreEqual(HttpStatusCode.OK, resposta.StatusCode);          
            
            #endregion
        }
    }
}
