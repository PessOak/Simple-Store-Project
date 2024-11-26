using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class GerenciarProdutosController(GerenciarProdutosService gerenciarProdutosService)
    {
        private readonly GerenciarProdutosService _gerenciarProdutosService = gerenciarProdutosService;

        //public IActionResult Index() {

        //    Return View();
        //}
    }
}
