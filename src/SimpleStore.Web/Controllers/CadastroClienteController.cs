using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using System.Diagnostics;

namespace SimpleStore.Web.Controllers
{
    public class CadastroClienteController : Controller
    {
        private readonly ILogger<CadastroClienteController> _logger;

        public CadastroClienteController(ILogger<CadastroClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
