using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        // Action que exibe todos os produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoService.ListarProdutos();

            return View(produtos);
        }

        // Action para exibir os detalhes de um produto
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoService.ListarProdutoPorId(id);
            
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
    }
}
