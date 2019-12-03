using System;
using AutomationPractice.Controllers;
using AutomationPractice.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace AutomationPractice.TestsWeb
{
    [TestClass]
    public class Compra : TestBase
    {
        [TestMethod]
        [Description("Validar a realização de uma compra com sucesso")]
        public void RealizarUmaCompraComSucessoFront()
        {
            #region Parameters          

            string firstnameaddress = "Carlos";
            string lastnameaddress = "Silva";
            string address = "Avenida Floriano";
            string city = "Curitiba";
            string postalcode = "12345";
            string totalcompra = "$29.00";

            #endregion

            #region Steps

            Util.WaitElement(HomePage.ProductBlouse());
            HomeController.ClickProductBlouse();                
            DetailsProductController.ClickBtnAddToCart();
            DetailsProductController.ClickBtnProceedToCheckout();
            Util.WaitElement(CartSummaryPage.QuantityProducts());

            //Validação se o produto está no carrinho
            Checkpoint(Util.CheckText(CartSummaryPage.QuantityProducts(), "1 Product"), "Produto adicionado no carrinho com sucesso");
                     
            CartSummaryController.ClickBtnProceedToCheckout();
            Util.WaitElement(AuthenticationPage.TextEmailAddress());
            AuthenticationController.SetEmailAddress(Util.GeraEmail());
            AuthenticationController.ClickBtnCreateAccount();
            Util.WaitElement(CadastroPage.TextFirstName());
            CadastroController.SetFirstNameCustomer("Carlos");
            CadastroController.SetLastNameCustomer("Silva");
            CadastroController.SetPassword("123456");
            CadastroController.SetAddressFirstName(firstnameaddress);
            CadastroController.SetAddressLastName(lastnameaddress);
            CadastroController.SetAddress(address);
            CadastroController.SetAddressCity(city);
            CadastroController.ClickDropState();
            CadastroController.SetPostalCode(postalcode);
            CadastroController.SetMobilePhone("+5541988045699");
            CadastroController.SetAddressReference("Rua Santo Antonio");
            CadastroController.ClickBtnRegister();

            string firstnamevalidation = Driver.FindElement(AddressesPage.DeliveryAddressFirstName()).Text;
            string lastnamevalidation = Driver.FindElement(AddressesPage.DeliveryAddressLastName()).Text;
           
            //Validação se o endereço está correto
            Checkpoint(firstnamevalidation.Contains(firstnameaddress) && lastnamevalidation.Contains(address), "Endereço validado com sucesso");

            AddressesController.ClickBtnProceedToCheckout();
            Util.WaitElement(ShippingPage.CheckAceiteTermos());
            ShippingController.ClickCheckAceiteTermos();
            ShippingController.ClickBtnProceedToCheckout();
            Util.WaitElement(PaymentPage.TotalCompra());

            //Validação se o total da compra está correto
            Checkpoint(Util.CheckText(PaymentPage.TotalCompra(), totalcompra), "Valor total da compra validado com sucesso");

            Util.WaitElement(PaymentPage.OptionPayByCheck());
            PaymentController.ClickOptionCheck();
            Util.WaitElement(PaymentPage.BtnConfirmOrder());
            PaymentController.ClickBtnConfirmOrder();

            Checkpoint(Util.Exists(OrderConfirmationPage.AlertSucess()), "Compra realizada com sucesso");
         
            #endregion

        }
    }
}
