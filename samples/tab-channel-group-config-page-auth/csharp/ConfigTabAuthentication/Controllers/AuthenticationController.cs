using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TabAuthentication.Models;

namespace TabAuthentication.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly ILogger<AuthenticationController> _logger;

        private readonly IConfiguration Configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("SimpleAuthStart")]
        public ActionResult SimpleAuthStart()
        {
            ViewBag.ClientId = Configuration["SimpleClientId"].ToString();
            ViewBag.ResponseType = Configuration["ResponseType"].ToString();
            ViewBag.ResponseMode = Configuration["ResponseMode"].ToString();
            ViewBag.Resource = Configuration["Resource"].ToString();
            return View();
        }

        [Route("SimpleAuthEnd")]
        public ActionResult SimpleAuthEnd()
        {
            return View();
        }

        [Route("SimpleSuccess")]
        public ActionResult SimpleSuccess()
        {
            return View();
        }

        [Route("SimpleFailed")]
        public ActionResult SimpleFailed()
        {
            return View();
        }

        [Route("SilentAuthStart")]
        public ActionResult SilentAuthStart()
        {
            ViewBag.AuthStartClientId = Configuration["ClientId"].ToString();
            return View();
        }

        [Route("SilentAuthEnd")]
        public ActionResult SilentAuthEnd()
        {
            ViewBag.AuthEndClientId = Configuration["ClientId"].ToString();
            return View();
        }

    }
}
