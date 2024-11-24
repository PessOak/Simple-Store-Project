using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private readonly CarrinhoService _carrinhoService;

        public CarrinhoController(CarrinhoService carrinhoService)
        {
            _carrinhoService = carrinhoService;
        }

        // Exibir o conteúdo do carrinho
        public IActionResult Index(string cpfComprador)
        {
            if (string.IsNullOrEmpty(cpfComprador))
            {
                // Retorna um erro ou redireciona, caso o CPF não seja fornecido
                return BadRequest("CPF do comprador é obrigatório.");
            }
            
            var carrinho = _carrinhoService.ObterCarrinho(cpfComprador); // Obter o carrinho específico do comprador
            return View(carrinho);
        }

        // Adicionar produto ao carrinho
        [HttpPost]
        public IActionResult AdicionarProduto(string cpfComprador, int idProduto, int quantidade)
        {
            _carrinhoService.AdicionarProduto(cpfComprador, idProduto, quantidade);
            return RedirectToAction("Index", new { cpfComprador });
        }

        // Remover produto do carrinho
        [HttpPost]
        public IActionResult RemoverProduto(string cpfComprador, int idProduto)
        {
            _carrinhoService.RemoverProduto(cpfComprador, idProduto);
            return RedirectToAction("Index", new { cpfComprador });
        }

        // Atualizar quantidade do produto no carrinho
        [HttpPost]
        public IActionResult AtualizarQuantidade(string cpfComprador, int idProduto, int quantidade)
        {
            _carrinhoService.AtualizarQuantidade(cpfComprador, idProduto, quantidade);
            return RedirectToAction("Index", new { cpfComprador });
        }
    }
}
