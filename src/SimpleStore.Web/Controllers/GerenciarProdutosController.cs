using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class GerenciarProdutosController : Controller 
    {
       
        private readonly GerenciarProdutosService _gerenciarProdutosService;

        public GerenciarProdutosController(GerenciarProdutosService gerenciarProdutosService) {
            _gerenciarProdutosService = gerenciarProdutosService;
        }

        public async Task<IActionResult> Index()
        {
            string cnpjFornecedor = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int cnpj = int.Parse(cnpjFornecedor);

            try
            {
                var produtos = await _gerenciarProdutosService.ExibirProdutosCadastrados(cnpj);
                return View(produtos);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
