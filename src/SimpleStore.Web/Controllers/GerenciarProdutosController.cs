using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Enums;
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

            if (!User.Identity.IsAuthenticated || User.FindFirstValue(ClaimTypes.Role) != PapelUsuario.Fornecedor.ToString())
            {
                ViewBag.ErrorMessage = "Você precisa estar logado para acessar esta página.";
                return RedirectToAction("LoginFornecedor", "Index");
            }

            string cnpjFornecedor = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int cnpj = int.Parse(cnpjFornecedor);

            try
            {
                ViewBag.ErrorMessage = null;
                var produtos = await _gerenciarProdutosService.ExibirProdutosCadastrados(cnpj);
                return View(produtos);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }
    }
}
