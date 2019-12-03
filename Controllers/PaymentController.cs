using AutomationPractice.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Controllers
{
    public class PaymentController : PaymentPage
    {
        #region Clicks

        public static void ClickOptionCheck()
        {
            Loger = "Click em 'Bank Wire'";
            Util.Click(OptionPayByCheck());
        }
        public static void ClickBtnConfirmOrder()
        {
            Loger = "Click em 'Confirm Order'";
            Util.Click(BtnConfirmOrder());
        }


        #endregion
    }
}
