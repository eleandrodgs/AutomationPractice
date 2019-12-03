using AutomationPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class ShippingController : ShippingPage
    {
        #region Clicks

        public static void ClickCheckAceiteTermos()
        {
            Loger = "Clique no aceite dos termos";
            Util.Click(CheckAceiteTermos());
        }

        public static void ClickBtnProceedToCheckout()
        {
            Loger = "Clique no botão 'Proceed to checkout'";
            Util.Click(BtnProceedToCheckout());
        }

        #endregion

    }
}
