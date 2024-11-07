using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class ProdutoCarrinhoController : Controller
    {
        private readonly ProdutoCarrinhoService _produtoCarrinhoService;

        public ProdutoCarrinhoController(ProdutoCarrinhoService produtoCarrinhoService)
        {
            _produtoCarrinhoService = produtoCarrinhoService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAoCarrinho(int produtoId, int quantidade)
        {
            // Obter o CPF do usuário logado da Claims
            string cpfComp = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(cpfComp))
            {
                // Se não encontrar o CPF, redireciona para a página de produtos/home
                return RedirectToAction("Index", "Produto"); 
            }

            // Com o CPF podemos buscar o carrinho do usuário no banco
            int idCarrinho = await _produtoCarrinhoService.ObterIdCarrinhoUsuarioAsync(cpfComp);

            if (idCarrinho == 0)
            {
                // Se o carrinho não existir, criar um novo carrinho ou exibir erro MUDAR REDIRECIONAMENTO
                return RedirectToAction("Index", "Produto");
            }

            // Adicionar o produto ao carrinho
            await _produtoCarrinhoService.AdicionarProdutoAoCarrinho(idCarrinho, produtoId, quantidade);

            return RedirectToAction("Index", "Produto");
        }
    }
}
