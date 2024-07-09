using System.Web.Mvc;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.BL.Managers;

namespace UserJobsTracker.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        #region Fields
        private readonly JobsManager _jobsManager;
        private readonly BranchesManager _branchesManager;
        #endregion

        #region CTOR
        public HomeController(JobsManager jobsManager, BranchesManager branchesManager)
        {
            _jobsManager = jobsManager;
            _branchesManager = branchesManager;
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            var branches = _branchesManager.GetAll();
            branches.Insert(0, new BranchDTO { Id = null, Name = "All"});
            ViewBag.Branches = branches;
            ViewBag.DefaultBranchId = CurrentClaim.DefaultBranchId;
            return View();
        }
        #endregion

        #region Create
        public ActionResult Create()
        {
            ViewBag.Branches = _branchesManager.GetAll();
            return PartialView("_CreateJobsDetails");
        }

        public JsonResult Save(CreateJobDTO job)
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
        #endregion

        #region Edit
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            ViewBag.Branches = _branchesManager.GetAll();
            var job = _jobsManager.GetById(Id);
            return PartialView("_EditJobDetails", job);
        }

        [HttpPost]
        public ActionResult Edit(UpdateJobDTO updateJobDTO)
        {
            try
            {
                if (updateJobDTO == null) return Json(false, JsonRequestBehavior.AllowGet);
                _jobsManager.Update(updateJobDTO);
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Delete
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
        #endregion

        #region APIs
        public JsonResult GetJobs(int? branchId)
        {
            var jobs = _jobsManager.GetAllByBranchId(branchId);
            return Json(jobs, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}