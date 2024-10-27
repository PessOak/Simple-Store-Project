using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.Web.Controllers
{
    public class LoginClienteController : Controller
    {
        private readonly ILogger<LoginClienteController> _logger;

        public LoginClienteController(ILogger<LoginClienteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
