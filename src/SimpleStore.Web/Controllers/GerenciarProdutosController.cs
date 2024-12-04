using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Enums;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class GerenciarProdutosController : Controller
    {
        private readonly GerenciarProdutosService _gerenciarProdutosService;

        public GerenciarProdutosController(GerenciarProdutosService gerenciarProdutosService)
        {
            _gerenciarProdutosService = gerenciarProdutosService;
        }

        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated || User.FindFirstValue(ClaimTypes.Role) != PapelUsuario.Fornecedor.ToString())
            {
                ViewBag.ErrorMessage = "Você precisa estar logado para acessar esta página.";
                return RedirectToAction("Index", "LoginFornecedor");
            }

            int idFornecedor = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            try
            {
                ViewBag.ErrorMessage = null;
                var produtos = await _gerenciarProdutosService.ExibirProdutosCadastrados(idFornecedor);
                return View(produtos);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _gerenciarProdutosService.BuscarPeloId(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            if (id != produto.IdProd) return NotFound();

            if (!ModelState.IsValid)
            {
                TempData["MensagemErro"] = "Erro na validação do modelo.";
                return View(produto);
            }

            // Processar upload da imagem, se houver
            if (produto.ImagemProduto != null && produto.ImagemProduto.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await produto.ImagemProduto.CopyToAsync(memoryStream);
                produto.ImgUrl = memoryStream.ToArray();
            }

            try
            {
                await _gerenciarProdutosService.AtualizarProduto(produto);
                TempData["MensagemSucesso"] = "Produto atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao atualizar o produto: {ex.Message}";
                return View(produto);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var produto = await _gerenciarProdutosService.BuscarPeloId(id);

            if (produto == null) return NotFound();

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _gerenciarProdutosService.DeletarProduto(id);
                TempData["MensagemSucesso"] = "Produto deletado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = $"Erro ao deletar o produto: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

    }
}
