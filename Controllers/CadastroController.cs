using AutomationPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class CadastroController : CadastroPage
    {
        #region Clicks

        public static void ClickDropState()
        {
            Loger = "Escolhendo o state";
            Util.Click(AddresStates());
            Util.Click(OptionStateArizona());
        }

        public static void ClickBtnRegister()
        {
            Loger = "Clique no botão 'Register'";
            Util.Click(BtnRegister());
        }

        #endregion

        #region SendKeys

        public static void SetFirstNameCustomer(string text)
        {
            Loger = "Informando o nome do cliente";
            Util.SendKeys(TextFirstName(), text);
        }

        public static void SetLastNameCustomer(string text)
        {
            Loger = "Informando o sobrenome do cliente";
            Util.SendKeys(TextLastName(), text);
        }

        public static void SetPassword (string text)
        {
            Loger = "Informando a senha do cliente";
            Util.SendKeys(TextPassword(), text);
        }

        public static void SetAddressFirstName(string text)
        {
            Loger = "Informando o endereço";
            Util.SendKeys(AddressFirstName(), text);
        }

        public static void SetAddressLastName(string text)
        {
            Loger = "Informando o endereço";
            Util.SendKeys(AddressLastName(), text);
        }

        public static void SetAddress(string text)
        {
            Loger = "Informando o endereço";
            Util.SendKeys(Address(), text);
        }

        public static void SetAddressCity(string text)
        {
            Loger = "Informando a cidade";
            Util.SendKeys(AddressCity(), text);
        }

        public static void SetPostalCode(string text)
        {
            Loger = "Informando o postal code";
            Util.SendKeys(AddressPostalCode(), text);
        }

        public static void SetMobilePhone(string text)
        {
            Loger = "Informando o mobile phone";
            Util.SendKeys(TextMobilePhone(), text);
        }

        public static void SetAddressReference(string text)
        {
            Loger = "Informando o address reference";
            Util.SendKeys(AddressReference(), text);
        }

        #endregion


    }
}
