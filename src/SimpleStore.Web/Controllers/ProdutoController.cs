using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoController(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        // Action que exibe todos os produtos
        public async Task<IActionResult> Index()
        {
            var produtos = await _produtoRepository.ListarProdutos();
            return View(produtos);
        }

        // Action para exibir os detalhes de um produto
        public async Task<IActionResult> Details(int id)
        {
            var produto = await _produtoRepository.ListarProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }
    }
}
