using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    [Authorize]
    public class CadastroProdutoController : Controller
    {
        private readonly CadastroProdutoService _cadastroProdutoService;

        public CadastroProdutoController(CadastroProdutoService cadastroProdutoService)
        {
            _cadastroProdutoService = cadastroProdutoService;
        }

        /// <summary>
        /// Exibe a página de cadastro de produto.
        /// </summary>
        [HttpGet]
        public IActionResult Index()
        {
            if (!User.IsInRole("Fornecedor"))
            {
                TempData["MensagemErro"] = "Apenas fornecedores podem acessar esta página.";
                return RedirectToAction("LoginFornecedor");
            }

            return View(new Produto());
        }

        /// <summary>
        /// Salva um novo produto.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalvarProduto(Produto produto)
        {
            if (!User.IsInRole("Fornecedor"))
            {
                TempData["MensagemErro"] = "Apenas fornecedores podem cadastrar produtos.";
                return RedirectToAction("LoginFornecedor");
            }

            if (User.Identity.IsAuthenticated)
            {
                // Busca o ClaimTypes.NameIdentifier para obter o Id do Fornecedor
                var idFornecedorClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (int.TryParse(idFornecedorClaim, out var idFornecedor))
                {
                    produto.IdForn = idFornecedor;
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível identificar o fornecedor.";
                    return RedirectToAction("LoginFornecedor");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Usuário não autenticado.";
                return RedirectToAction("LoginFornecedor");
            }

            // Validação manual da imagem
            if (produto.ImagemProduto == null || produto.ImagemProduto.Length == 0)
            {
                ModelState.AddModelError("ImagemProduto", "Obrigatório enviar uma imagem do produto.");
            }

            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro de validação: {error.ErrorMessage}");
                }
                return View("Index", produto);
            }

            bool sucesso = await _cadastroProdutoService.SalvarProdutoAsync(produto);

            if (sucesso)
            {
                TempData["MensagemSucesso"] = "Produto salvo com sucesso!";
                return RedirectToAction("Index", "GerenciarProdutos");
            }

            TempData["MensagemErro"] = "Erro ao salvar o produto. Tente novamente.";
            return View("Index", produto);
        }
    }
}
