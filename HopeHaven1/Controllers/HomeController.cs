using HopeHaven1.Models;
using HopeHaven1.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HopeHaven1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ApplicationDbContext _context = new ApplicationDbContext();
        private readonly OtpService otpService;

        public HomeController()
        {
            otpService = new OtpService();
        }

        public ActionResult Index()
        {
            List<Therapists> listOfTherapists = new List<Therapists>();
            listOfTherapists = _context.therapists.ToList();
            return View("Home", listOfTherapists);
        }
        public ActionResult BookSession(string Id=null)
        {
            if(Id!=null)
            {
                Therapists therapist = new Therapists();
                int id = Convert.ToInt32(Id);
                therapist = _context.therapists.Where(m => m.Id == id).FirstOrDefault();
                return View(therapist);
            }
            ViewBag.Otp = TempData["OTP"];
            ViewBag.PhoneNo = TempData["PhoneNo"];
            return View();
        }
        [HttpPost]
        public ActionResult GetOtp(string PhoneNo)
        {
            string otp = otpService.GenerateOtp(); // Generate a random OTP
            otpService.SendOtp("+91" + PhoneNo, otp);
            Session["OTP"] = otp;
            Session["PhoneNo"] = PhoneNo;
            TempData["OTP"] = PhoneNo;
            TempData["PhoneNo"] = PhoneNo;
            return RedirectToAction("BookSession");
        }

        [HttpPost]
        public ActionResult VerifyOtp(string enteredOtp,string PhoneNo)
        {
            bool isValidOtp = false;
            if (enteredOtp.Equals(Session["OTP"]) && PhoneNo.Equals(Session["PhoneNo"]))
            {
                isValidOtp = true;
            }

            if (isValidOtp)
            {
                return RedirectToAction("Index", "Payment");
            }
            else
            {
                ModelState.AddModelError("", "Invalid OTP");
                return View("BookSession");
            }
        }
    }
}