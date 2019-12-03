using AutomationPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class DetailsProductController : DetailsProductPage
    {
        #region Clicks
        public static void ClickBtnAddToCart()
        {
            Loger = "Clique no botão 'Add to cart'";
            Util.WaitElement(BtnAddToCart());
            Util.Click(BtnAddToCart());       
        }

        public static void ClickBtnProceedToCheckout()
        {
            Loger = "Clique no botão 'Proceed to Checkout'";
            Util.Click(BtnProceedToCheckout());
        }

        #endregion
    }
}
