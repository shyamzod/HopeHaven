using HopeHaven1.Models;
using HopeHaven1.Models.ViewModels;
using HopeHaven1.Utility;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WpfApp2.Utility;

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

            // Return the JSON response
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult VerifyOtp(string enteredOtp, string PhoneNo)
        {
            bool isValidOtp = false;
            if (enteredOtp.Equals(Session["OTP"]) && PhoneNo.Equals(Session["PhoneNo"]))
            {
                isValidOtp = true;
            }

            if (isValidOtp)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                ModelState.AddModelError("", "Invalid OTP");
                return Json(new { success = false, errorMessage = "Invalid OTP" });
            }
        }
        public ActionResult TherapistLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TherapistLogin(TherapistViewModel therapist)
        {
            PasswordHash phash = new PasswordHash();
            therapist.Password = phash.ComputeHash(therapist.Password);
            Therapists therap =_context.therapists.Where(o => o.Name == therapist.NameorEmail || o.Email == therapist.NameorEmail && o.Password == therapist.Password).FirstOrDefault();
            if(therap!=null)
            {
                List<Patient> patients = _context.Patients.Where(patient => patient.TherapistId == therap.Id).ToList();
                return View("TherapistIndex", patients);
            }
            ViewBag.ErrorMessage = "Invalid UserNameorEmail or Password !!";
            return View();
        }
    }
}