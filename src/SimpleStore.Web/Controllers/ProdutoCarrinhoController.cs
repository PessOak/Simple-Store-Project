using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class ProdutoCarrinhoController(ProdutoCarrinhoService produtoCarrinhoService) : Controller
    {
        private readonly ProdutoCarrinhoService _produtoCarrinhoService = produtoCarrinhoService;

        [HttpPost]
        public async Task<IActionResult> AdicionarAoCarrinho(int idCarrinho, int produtoId, int quantidade)
        {
            
            await _produtoCarrinhoService.AdicionarProdutoAoCarrinho(idCarrinho, produtoId, quantidade);

            return RedirectToAction("Index", "Produto"); // trocar para "Index", "Carrinho" quando tiver a página do carrinho
        }
    }
}
