using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        // Action para exibir o conteúdo do carrinho
        public IActionResult Index()
        {
            return View();
        }
    }
}
