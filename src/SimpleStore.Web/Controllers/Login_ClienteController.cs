using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using System.Diagnostics;

namespace SimpleStore.Web.Controllers
{
    public class Login_ClienteController : Controller
    {
        private readonly ILogger<Login_ClienteController> _logger;

        public Login_ClienteController(ILogger<Login_ClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
