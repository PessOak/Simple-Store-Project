using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using System.Diagnostics;

namespace SimpleStore.Web.Controllers
{
    public class Login_FornecedorController : Controller
    {
        private readonly ILogger<Login_FornecedorController> _logger;

        public Login_FornecedorController(ILogger<Login_FornecedorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
