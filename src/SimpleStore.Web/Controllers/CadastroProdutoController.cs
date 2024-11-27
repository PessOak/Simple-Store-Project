using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Threading.Tasks;

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

            return View(new CadastroProduto());
        }

        /// <summary>
        /// Salva um novo produto.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SalvarProduto(CadastroProduto produto)
        {
            if (!User.IsInRole("Fornecedor"))
            {
                TempData["MensagemErro"] = "Apenas fornecedores podem cadastrar produtos.";
                return RedirectToAction("LoginFornecedor");
            }

            if (User.Identity.IsAuthenticated)
            {
                var idFornecedor = int.Parse(User.FindFirst("IdForn")?.Value ?? "0");
                produto.IdForn = idFornecedor;

                // Validar se o fornecedor existe
                var fornecedorExiste = await _cadastroProdutoService.VerificarFornecedorAsync(idFornecedor);
                if (!fornecedorExiste)
                {
                    TempData["MensagemErro"] = "Fornecedor inválido. Tente novamente.";
                    return RedirectToAction("LoginFornecedor");
                }
            }
            else
            {
                TempData["MensagemErro"] = "Usuário não autenticado.";
                return RedirectToAction("LoginFornecedor");
            }

            if (!ModelState.IsValid)
            {
                return View("Index", produto);
            }

            bool sucesso = await _cadastroProdutoService.SalvarProdutoAsync(produto);

            if (sucesso)
            {
                TempData["MensagemSucesso"] = "Produto salvo com sucesso!";
                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Erro ao salvar o produto. Tente novamente.";
            return View("Index", produto);
        }
    }
}
