using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Enums;
using SimpleStore.Web.Services;
using System.Security.Claims;

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

            if (User.IsInRole(PapelUsuario.Fornecedor.ToString()) || string.IsNullOrEmpty(cpfComp))
            {
                return RedirectToAction("Index", "LoginCliente");
            }

            // Tenta obter o carrinho ou cria um novo caso não exista
            var carrinho = await _carrinhoService.ObterCarrinhoOuCriarAsync(cpfComp);

            return View(carrinho);
        }

        [HttpPost]
        public IActionResult FinalizarCompra(int idCarrinho)
        {
            // Redireciona para a página de Finalizar Pedido
            return RedirectToAction("Index", "FinalizarPedido", new { idCarrinho });
        }
    }
}
