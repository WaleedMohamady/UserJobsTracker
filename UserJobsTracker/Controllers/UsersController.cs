using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UserJobsTracker.BL.DTOs;
using UserJobsTracker.BL.Managers;
using UserJobsTracker.DAL.Context;
using UserJobsTracker.DAL.Models;

namespace UserJobsTracker.Controllers
{
    public class UsersController : Controller
    {
        private readonly BranchesManager _branchesManager;
        private UserManager<SystemUser> _userManager;
        //private readonly SystemUsersManager _userManager;
        public UsersController(BranchesManager branchesManager /*SystemUsersManager userManager*/)
        {
            _branchesManager = branchesManager;
            //_userManager = userManager;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                UserJobsTrackerDbContext _ctx = new UserJobsTrackerDbContext();
                _userManager = new UserManager<SystemUser>(new UserStore<SystemUser>(_ctx));

                var user = _userManager.Find(model.Username, model.Password);
                if (user != null)
                {
                    var currentClaim = new CurrentClaim
                    {
                        CurrentUserId = user.Id,
                        CurrentUsername = user.UserName,
                        DefaultBranchId = user.DefaultBranchId,
                    };
                    var claimsIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    claimsIdentity.AddClaim(new Claim("CurrentClaim", JsonConvert.SerializeObject(currentClaim)));
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { IsPersistent = model.RememberMe }, claimsIdentity);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username or password");
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", "Users");
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.Branches = _branchesManager.GetAll();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                UserJobsTrackerDbContext _ctx = new UserJobsTrackerDbContext();
                _userManager = new UserManager<SystemUser>(new UserStore<SystemUser>(_ctx));

                var user = new SystemUser
                {
                    UserName = model.Username,
                    DefaultBranchId = model.DefaultBranchId,
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // Sign in the user (optional)
                    var currentClaim = new CurrentClaim
                    {
                        CurrentUserId = user.Id,
                        CurrentUsername = user.UserName,
                        DefaultBranchId = user.DefaultBranchId,
                    };
                    var claimsIdentity = _userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    claimsIdentity.AddClaim(new Claim("CurrentClaim", JsonConvert.SerializeObject(currentClaim)));
                    HttpContext.GetOwinContext().Authentication.SignIn(new AuthenticationProperties() { IsPersistent = false }, claimsIdentity);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}