using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.Web.Controllers
{
    public class LoginFornecedorController(ILogger<LoginFornecedorController> logger) : Controller
    {
        private readonly ILogger<LoginFornecedorController> _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

    }
}
