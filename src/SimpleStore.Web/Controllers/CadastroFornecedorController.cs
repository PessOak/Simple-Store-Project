using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CadastroFornecedorController : Controller
    {
        private readonly CadastroFornecedorService _cadastroFornecedorService;

        public CadastroFornecedorController(CadastroFornecedorService cadastroFornecedorService)
        {
            _cadastroFornecedorService = cadastroFornecedorService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
