using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.Web.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
