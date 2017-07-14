using JobPortalDAL.Common;
using JobPortalDAL.DataAccess;
using JobPortalDAL.Entity;
using JobPortalDAL.Manager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace JobPortal.Controllers
{
    public class EmployerController : Controller
    {
        private IJob Jb;
        public EmployerController()
        {
            Jb = new JobRepository();
        }
        // GET: Employer
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult AddJob()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddJob(Job jb)
        {
            var token = "";

            //jb.ExpireDate = DateTime.Now.AddDays(5).ToString();
            jb.CreatedDate = DateTime.Now.ToString();

            if (Request.Cookies["UDetails"] != null)
            {
                token = Request.Cookies["UDetails"].Values["Token"];
                var user = Request.Cookies["LoggedUDetails"].Value;

                var result = JsonConvert.DeserializeObject<User>(user);
                jb.UserID = result.UserID;
            }
            else
            {
                return RedirectToAction("login", "Account");
            }            

            if (token == null || token == "")
            {
                return RedirectToAction("login", "Account");
            }           

            var response = Jb.AddJob(jb, token);

            return Json(new { success = true, responseText = response }, JsonRequestBehavior.AllowGet);
        }
    }
}