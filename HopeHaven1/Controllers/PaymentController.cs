using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeHaven1.Controllers
{
    public class PaymentController : Controller
    {
        private readonly string razorpayKeyId = System.Configuration.ConfigurationManager.AppSettings["RazorpayKeyId"];
        private readonly string razorpayKeySecret = System.Configuration.ConfigurationManager.AppSettings["RazorpayKeySecret"];

        public ActionResult Index()
        {
            ViewBag.RazorpayKeyId = razorpayKeyId;
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string razorpayPaymentId, string razorpayOrderId, string razorpaySignature)
        {
            var client = new RazorpayClient(razorpayKeyId, razorpayKeySecret);
            Dictionary<string, string> attributes = new Dictionary<string, string>()
        {
            { "razorpay_payment_id", razorpayPaymentId },
            { "razorpay_order_id", razorpayOrderId },
            { "razorpay_signature", razorpaySignature }
        };

            var payment = client.Payment.Fetch(razorpayPaymentId);

            if (payment != null && payment["status"] == "captured")
            {
                // Payment succeeded
                return View("Success");
            }
            else
            {
                // Payment failed
                return View("Failure");
            }
        }
    }
}