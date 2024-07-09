using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Web.Mvc;
using UserJobsTracker.BL.DTOs;

namespace UserJobsTracker.Controllers
{
    public class BaseController : Controller
    {
        public CurrentClaim CurrentClaim
        {
            get
            {
               return JsonConvert.DeserializeObject<CurrentClaim>(((ClaimsIdentity)User.Identity).FindFirst("CurrentClaim").Value);
            }
        }
    }
}