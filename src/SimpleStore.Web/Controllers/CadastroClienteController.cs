using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CadastroClienteController(CadastroClienteService cadastroClienteService) : Controller
    {

        private readonly CadastroClienteService _cadastroClienteService = cadastroClienteService;

        public IActionResult Index()
        {
            TempData["SuccessMessage"] = null;
            ViewBag.ErrorMessage = null;
            return View(new Comprador());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Comprador comprador)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _cadastroClienteService.Criar(comprador);
                    TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
                }
            }
            catch (ArgumentException ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }
            return View("Index", comprador);
        }
    }
}
