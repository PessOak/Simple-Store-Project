using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;
using System.Security.Claims;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoService _carrinhoService;

        public CarrinhoController(CarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        public async Task<IActionResult> Index()
        {
            // Obter CPF do usuário logado
            string cpfComp = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(cpfComp))
            {
                return RedirectToAction("Login", "Account");
            }

            // Tenta obter o carrinho ou cria um novo caso não exista
            var carrinho = await _carrinhoService.ObterCarrinhoOuCriarAsync(cpfComp);

            return View(carrinho);
        }

        [HttpPost]
        public async Task<IActionResult> RemoverProduto(int idProduto)
        {
            // Obter CPF do usuário logado
            string cpfComp = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(cpfComp))
            {
                return RedirectToAction("Login", "Account");
            }

            // Chama o serviço para remover o produto do carrinho
            await _carrinhoService.RemoverProdutoDoCarrinhoAsync(cpfComp, idProduto);

            // Redirecionar de volta para a página do carrinho
            return RedirectToAction("Index");
        }


    }
}
