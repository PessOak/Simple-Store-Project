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
            TempData["SuccessMessage"] = null;
            ViewBag.ErrorMessage = null;
            return View(new Fornecedor());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Fornecedor fornecedor)
        {
            try
            { 
            if (ModelState.IsValid)
            {
                await _cadastroFornecedorService.CriarFornecedor(fornecedor);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
            }
            else
            {
                ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
            }
            } catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("Index", fornecedor);
        }
    }
}
