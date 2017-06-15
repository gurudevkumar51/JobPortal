using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalDAL.Entity;
using Newtonsoft.Json;
using System.Web.Security;
using JobPortalDAL.Common;
using JobPortalDAL.DataAccess;
using JobPortalDAL.Manager;

namespace JobPortal.Controllers
{    
    [Authorize]
    public class AccountController : Controller
    {
        private IAccount acc;

        public AccountController()
        {
            acc = new AccountRepository();
        }

        [AllowAnonymous]
        public ActionResult login(string returnUrl)
        {
            Login lgin = new Login();
            if (Request.Cookies["MrLogin"] != null)
            {
                lgin.EmailId = Request.Cookies["MrLogin"].Values["Email"];
                lgin.Password = Request.Cookies["MrLogin"].Values["Password"];
                lgin.RememberMe = true;
            }
            return View(lgin);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]        
        public ActionResult login(Login lgn, string returnUrl)
        {
            string message = "";
            var v = acc.Login();
           // var v = new User();
            if (v != null)
            {
                var json = JsonConvert.SerializeObject(v);
                FormsAuthentication.SetAuthCookie(lgn.EmailId, lgn.RememberMe);
                if (lgn.RememberMe)
                {
                    HttpCookie cookie = new HttpCookie("MrLogin", json);
                    cookie.Values.Add("Email", lgn.EmailId);
                    cookie.Values.Add("Password", lgn.Password);                    
                    cookie.Expires.AddDays(15);
                    Response.Cookies.Add(cookie);
                }

                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                message = "Invalid credential provided";
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            if (Request.Cookies["MrLogin"] != null)
            {
                var user = new HttpCookie("MrLogin")
                {
                    Expires = DateTime.Now.AddDays(-1),
                    Value = null
                };
                Response.Cookies.Add(user);
            }
            return RedirectToActionPermanent("login", "Account");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterUser(User accnt)
        {
            var msg = "";
            accnt.Password = GenericClass.Hash(accnt.Password);
            var flag =false;// Umng.RegisterUser(accnt, out msg);
            if (flag == true)
            {
                var pp = "User registered successfully!";
                return Json(new { success = true, responseText = pp }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = false, responseText = msg }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePassword CPassword)
        {
            var msg = "";
            var flag = true; //Umng.ChangePassword(CPassword, Request.Cookies["MrLogin"].Values["Email"], out msg);
            if (flag == true)
            {
                var pp = "Password changed successfully!";
                return Json(new { success = true, responseText = pp }, JsonRequestBehavior.AllowGet);
            }
            else
            {                
                return Json(new { success = false, responseText = msg }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}