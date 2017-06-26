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

        public async Task<ActionResult> Jobs()
        {
            var allJobs = await jb.GetAllJobs();
            return View("Index");
        }
    }
}