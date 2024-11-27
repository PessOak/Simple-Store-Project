using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class GerenciarProdutosController : Controller 
    {
       
        private readonly GerenciarProdutosService _gerenciarProdutosService;

        public GerenciarProdutosController(GerenciarProdutosService gerenciarProdutosService) {
            _gerenciarProdutosService = gerenciarProdutosService;
        }
 
        public async Task<IActionResult> Index()
        {
            var produtos = await _gerenciarProdutosService.ExibirProdutosCadastrados();

            return View(produtos);
        }
    }
}
