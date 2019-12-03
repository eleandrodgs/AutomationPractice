using Bogus;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationPractice
{
    public static class Util
    {
        public static string UrlApi => "http://5d9cc58566d00400145c9ed4.mockapi.io/";    

        public static string GeraEmail()
        {
            Faker faker = new Faker("pt_BR");
            return faker.Internet.Email();
            
        }
       
        public static IRestResponse TestPostComModelo<T>(string URL, T modelo) where T : class
        {
            return TestPost(URL, JsonConvert.SerializeObject(modelo));
        }

        public static IRestRequest CreateRequest(Method method)
        {
            var request = new RestRequest(method);
            request.AddHeader("cache-control", "no-cache");         

            return request;
        }

        public static IRestClient CreateClient(string URL)
        {
            return new RestClient(UrlApi + URL);
        }

        public static IRestResponse TestPost(string URL, string RequestBody)
        {
            var client = CreateClient(URL);
            var request = CreateRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", RequestBody, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            return response;
        }

        public static IRestResponse TestGet(string URL)
        {
            var client = CreateClient(URL);
            var request = CreateRequest(Method.GET);
            request.AddHeader("content-type", "application/json");  //Adding Json Header as response type Json           
            IRestResponse response = client.Execute(request);

            return response;
        }

        public static By SendKeys(this By by, string text, int timeoutSeconds = TestBase.DefaulTimeOut)
        {
            for (var i = 0; i < timeoutSeconds; i++)
            {
                try
                {
                    // TestBase.Logger = $"Inserir valor: ({text}) no Elemento com localizador: ({by})";
                    TestBase.Driver.FindElement(by).SendKeys(text);

                    return by;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Assert.Fail($"Não foi possível encontrar elemento Locator: {by}");

            return null;
        }

        public static By Click(this By by, int timeoutSeconds = TestBase.DefaulTimeOut)
        {
            for (var i = 0; i < timeoutSeconds; i++)
            {
                try
                {
                    // TestBase.Logger = $"Efetuar click no Elemento com localizador: ({by})";
                    TestBase.Driver.FindElement(by).Click();

                    return by;
                }
                catch (Exception)
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            Assert.Fail($"Não foi possível encontrar elemento Locator: {by}");
            TestBase.Checkpoint(false, "Não foi possível prosseguir");

            return null;
        }

        public static bool CheckText(this By by, string text, int timeoutSeconds = TestBase.DefaulTimeOut)
        {
            for (var i = 0; i < timeoutSeconds; i++)
            {
                try
                {
                    if (TestBase.Driver.FindElements(by).Count > 0)
                    {
                        return TestBase.Driver.FindElement(by).Text.Equals(text);
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }

            return false;
        }

        public static IWebElement WaitElement(this By by, int timeoutSeconds = 20, bool failIfNotExists = true)
        {
            for (int i = 0; i < timeoutSeconds; i++)
            {
                try
                {                  

                    return TestBase.Driver.FindElement(by);
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }

            //Assert.Fail($"Não foi possível encontrar elemento no Locator: {by}");

            if (failIfNotExists)
            {
                TestBase.Checkpoint(false, $"Elemento não encontrado pelo localizador {by}");
            }

            return null;

            //return null;
        }

        public static bool Exists(this By by, int timeoutSeconds = TestBase.DefaulTimeOut)
        {
            for (var i = 0; i < timeoutSeconds; i++)
            {
                try
                {
                    if (TestBase.Driver.FindElements(by).Count > 0)
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(1000);
                }
            }

            return false;
        }


    }
}
