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
using System.Net.Http;
using JobPortalDAL.Manager;
using System.Configuration;

namespace JobPortal.Controllers
{    
    public class AccountController : Controller
    {
        private IAccount acc;
       // public string ApiUrl = ConfigurationManager.AppSettings["ApiUrl"].ToString();

        public AccountController()
        {
            acc = new AccountRepository();            
        }

        [AllowAnonymous]
        public ActionResult login(string returnUrl)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Login lgin = new Login();
                if (Request.Cookies["UDetails"] != null)
                {
                    lgin.EmailId = Request.Cookies["UDetails"].Values["Email"];
                    lgin.Password = Request.Cookies["UDetails"].Values["Password"];
                    lgin.RememberMe = true;
                }
                return View(lgin);
            }
            else { return RedirectToAction("Index", "Home"); }                        
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> login(Login lgn, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(lgn);
            }

            var token = JsonConvert.DeserializeObject<Token>(acc.Login(lgn.EmailId, lgn.Password));
            token.userName = lgn.EmailId;

            if (token != null && token.access_token != "" && token.access_token != null)
            {                
                var result = JsonConvert.DeserializeObject<APIUserResponse>(await acc.GetUserDetailsAsync(token.access_token));                
                if (result.responseText[0] != null)
                {
                    FormsAuthentication.SetAuthCookie(lgn.EmailId, false);
                    var authTicket = new FormsAuthenticationTicket(1, lgn.EmailId, DateTime.Now, DateTime.Now.AddMinutes(20), lgn.RememberMe, result.responseText[0].Role);
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);

                    var json = JsonConvert.SerializeObject(result.responseText[0]);
                    HttpCookie Ucookie = new HttpCookie("LoggedUDetails", json);
                    Ucookie.Expires.AddDays(15);
                    Response.Cookies.Add(Ucookie);

                    if (lgn.RememberMe)
                    {
                        HttpCookie cookie = new HttpCookie("UDetails");
                        cookie.Values.Add("Email", lgn.EmailId);
                        cookie.Values.Add("Password", lgn.Password);
                        cookie.Values.Add("Token", token.access_token);
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
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(lgn);
            }
            return View(lgn);            
        }

        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();            
            return RedirectToAction("login", "Account");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RegisterUser(User accnt)
        {
            var msg = "";
            accnt.Password = GenericClass.Hash(accnt.Password);
            var flag = false;// Umng.RegisterUser(accnt, out msg);
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