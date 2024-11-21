using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
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

        [HttpPost]
        public async Task<IActionResult> NovoFornecedor(Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                await _cadastroFornecedorService.CriarFornecedor(fornecedor);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
            }
            else
            {
                ViewBag.ErrorMessage = ("Por favor, preencha todos os campos.");
            }
            return View("Index", fornecedor);
        }
    }
}
