using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using System.Diagnostics;

namespace SimpleStore.Web.Controllers
{
    public class LoginFornecedorController : Controller
    {
        private readonly ILogger<LoginFornecedorController> _logger;

        public LoginFornecedorController(ILogger<LoginFornecedorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
