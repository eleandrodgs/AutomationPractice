using AutomationPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class CartSummaryController : CartSummaryPage
    {
        #region Clicks

        public static void ClickBtnProceedToCheckout()
        {
            Loger = "Clique no botão 'Proceed to CheckOut'";
            Util.Click(CartSummaryPage.BtnProceedToCheckout());
        }

        #endregion

    }
}
