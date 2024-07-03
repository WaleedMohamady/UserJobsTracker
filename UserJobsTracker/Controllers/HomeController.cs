using Microsoft.AspNet.Identity;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace UserJobsTracker.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}