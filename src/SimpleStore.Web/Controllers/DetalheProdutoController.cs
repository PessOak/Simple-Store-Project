using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using System.Diagnostics;

namespace SimpleStore.Web.Controllers
{
    public class DetalheProdutoController : Controller
    {
        private readonly ILogger<DetalheProdutoController> _logger;

        public DetalheProdutoController(ILogger<DetalheProdutoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
