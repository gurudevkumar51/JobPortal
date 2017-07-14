using JobPortalDAL.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobPortalDAL.DataAccess;
using System.Threading;
using System.Threading.Tasks;

namespace JobPortal.Controllers
{
    public class HomeController : Controller
    {
        private IJob jb;

        public HomeController()
        {
            jb = new JobRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home
        public ActionResult JobList()
        {
            return View();
        }        

        public async Task<ActionResult> Jobs()
        {
            var allJobs = await jb.GetAllJobs();
            return Json(allJobs, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> SeekerCount()
        {
            var Count = await jb.SeekerCount();
            return Json(Count, JsonRequestBehavior.AllowGet);
        }
    }
}