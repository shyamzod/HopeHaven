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
        public ActionResult BookSession(int Id)
        {
                Therapists therapist = new Therapists();
                therapist = _context.therapists.Where(m => m.Id == Id).FirstOrDefault();
                return View(therapist);
        }
        [HttpPost]
        public ActionResult GetOtp(string PhoneNo)
        {
            string otp = otpService.GenerateOtp(); // Generate a random OTP
            otpService.SendOtp("+91" + PhoneNo, "123");
            TempData["OTP"] = otp;
            TempData["PhoneNo"] = PhoneNo;
            return RedirectToAction("BookSession");
        }

        [HttpPost]
        public ActionResult VerifyOtp(string enteredOtp, string validateOTP=null)
        {
            bool isValidOtp = false;
            if (enteredOtp == TempData["OTP"])
            {
                isValidOtp = true;
            }

            if (isValidOtp)
            {
                // OTP is valid, proceed with the desired action
                return RedirectToAction("Welcome");
            }
            else
            {
                // OTP is invalid, show an error message
                ModelState.AddModelError("", "Invalid OTP");
                return View("VerifyOtp");
            }
            return View("Home");
        }
    }
}