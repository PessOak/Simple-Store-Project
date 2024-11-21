using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CadastroClienteController(CadastroClienteService cadastroClienteService) : Controller
    {

        private readonly CadastroClienteService _cadastroService = cadastroClienteService;

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Comprador comprador)
        {

            if (ModelState.IsValid)
            {
                await _cadastroService.CriarComprador(comprador);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index", "LoginCliente");
            }
            else
            {
                ViewBag.ErrorMessage = ("Por favor, preencha todos os campos corretamente.");
            }

            return View("Index", comprador);
        }
    }
}
