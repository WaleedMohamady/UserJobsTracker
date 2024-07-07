using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using UserJobsTracker.BL.Managers;
using UserJobsTracker.DAL.Models;

namespace UserJobsTracker.Controllers
{
    public class HomeController : Controller
    {
        private readonly JobsManager _jobsManager;
        private readonly BranchesManager _branchesManager;
        public HomeController(JobsManager jobsManager, BranchesManager branchesManager)
        {
            _jobsManager = jobsManager;
            _branchesManager = branchesManager;
        }
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var username = User.Identity.GetUserName();

            // Access other user-related information as needed
            var claims = ((ClaimsIdentity)User.Identity).Claims;
            var branchId = claims.FirstOrDefault(c => c.Type == "DefaultBranchId")?.Value;

            ViewBag.UserId = userId;
            ViewBag.Username = username;
            ViewBag.BranchId = branchId;

            return View();
        }

        public JsonResult GetJobs()
        {
            var jobs = _jobsManager.GetAll();
            return Json(jobs, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.Branches = _branchesManager.GetAll();
            return PartialView("_CreateJobsDetails");
        }

        public JsonResult Save(Job job)
        {
            try
            {
                if (job == null) return Json(false, JsonRequestBehavior.AllowGet);
                _jobsManager.Add(job);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.Branches = _branchesManager.GetAll();
            var job = _jobsManager.GetById(Id);
            return PartialView("_EditJobDetails", job);
        }

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            try
            {
                if (job == null) return Json(false, JsonRequestBehavior.AllowGet);
                _jobsManager.Update(job);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DeleteJob(int JobId)
        {
            try
            {
                var result = _jobsManager.Delete(JobId);
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
    }
}