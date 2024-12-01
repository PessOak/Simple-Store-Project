using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Threading.Tasks;

namespace SimpleStore.Web.Controllers
{
    public class FinalizarPedidoController : Controller
    {
        private readonly FinalizarPedidoService _finalizarPedidoService;

        public FinalizarPedidoController(FinalizarPedidoService finalizarPedidoService)
        {
            _finalizarPedidoService = finalizarPedidoService;
        }

        /// <summary>
        /// Exibe a página de finalização do pedido.
        /// </summary>
        /// <param name="idCarrinho">ID do carrinho.</param>
        /// <returns>View com os detalhes do pedido.</returns>
        public async Task<IActionResult> Index(int idCarrinho)
        {
            // Obtém os produtos e o total do pedido
            var (produtos, totalPedido) = await _finalizarPedidoService.ObterDetalhesPedidoAsync(idCarrinho);

            // Passa os dados para a view através do ViewData
            ViewData["Produtos"] = produtos;
            ViewData["TotalPedido"] = totalPedido;

            return View();
        }

        /// <summary>
        /// Confirma o pedido após o usuário revisar os detalhes.
        /// </summary>
        /// <param name="pedido">Objeto do pedido.</param>
        /// <returns>Redireciona para a página de sucesso se válido.</returns>
        [HttpPost]
        public async Task<IActionResult> Confirmar(Pedido pedido)
        {
            if (!ModelState.IsValid)
            {
                // Caso o modelo seja inválido, retorna à mesma página com os dados do pedido
                return View("Index", pedido);
            }

            // Finaliza o pedido
            await _finalizarPedidoService.FinalizarPedidoAsync(pedido);

            // Redireciona para a página de sucesso
            return RedirectToAction("Sucesso");
        }

        /// <summary>
        /// Exibe a página de sucesso após a confirmação do pedido.
        /// </summary>
        /// <returns>View de sucesso.</returns>
        public IActionResult Sucesso()
        {
            return View();
        }
    }
}
