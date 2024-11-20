using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CadastroFornecedorController(CadastroFornecedorService cadastroFornecedorService) : Controller
    {
        private readonly CadastroFornecedorService _cadastroFornecedorService = cadastroFornecedorService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _cadastroFornecedorService.CriarFornecedor(fornecedor);
                return RedirectToAction("Index", "LoginFornecedor");
            }

            return RedirectToAction("Index");
        }
    }
}
