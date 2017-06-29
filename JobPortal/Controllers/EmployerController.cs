using JobPortalDAL.Common;
using JobPortalDAL.Entity;
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
        // GET: Employer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddJob(Job jb)
        {
            jb.UserID = 1;
            jb.ExpireDate = DateTime.Now.AddDays(5);
            jb.CreatedDate = DateTime.Now;

            if (Session["token"].ToString() == null || Session["token"].ToString() == "")
            {
                return RedirectToAction("login", "Account");
            }
            var url = GenericClass.ApiUrl + "api/Job/Add";
            var tok = Session["token"].ToString();
            var response = await GenericClass.CallApi(url, tok);

            return Json(new { success = true, responseText = response }, JsonRequestBehavior.AllowGet);
        }
    }
}