using HopeHaven1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WpfApp2.Utility;

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
                List<string> photobase24strings = new List<string>();
                if (Request.Files.Count > 0)
                {
                    for (int i = 0; i < Request.Files.Count; i++)
                    {
                        var photo1 = Request.Files[i];
                        var imgbytes = new Byte[photo1.ContentLength];
                        photo1.InputStream.Read(imgbytes, 0, photo1.ContentLength);
                        var base64string = Convert.ToBase64String(imgbytes, 0, imgbytes.Length);
                        photobase24strings.Add(base64string);
                    }
                }
                therapist.profilePhoto = photobase24strings[0];
                PasswordHash phash = new PasswordHash();
                therapist.Password = phash.ComputeHash(therapist.Password);
                dbContext.therapists.Add(therapist);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

            }

        }
    }
}