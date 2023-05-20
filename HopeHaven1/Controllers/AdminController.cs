using HopeHaven1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HopeHaven1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext dbContext = new ApplicationDbContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            Session["UserName"] = "Shyam";
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminLogin logindetails)
        {
            AdminLogin login = dbContext.AdminLogins.Where(user => user.UserName == logindetails.UserName && user.Password == logindetails.Password).FirstOrDefault();
            if(login!=null)
            {
                FormsAuthentication.SetAuthCookie(logindetails.UserName, false);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ErrorMessage = "UserName and Password are Invalid !!";
                return View();
            }
        }
        [HttpPost]
        public void AddTherapist(Therapists therapist)
        {
            try
            {
                dbContext.therapists.Add(therapist);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
    }
}