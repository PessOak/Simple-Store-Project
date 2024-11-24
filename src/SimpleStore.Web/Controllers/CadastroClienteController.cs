using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;

namespace SimpleStore.Web.Controllers
{
    public class CadastroClienteController(CadastroClienteService cadastroClienteService) : Controller
    {

        private readonly CadastroClienteService _cadastroClienteService = cadastroClienteService;

        public IActionResult Index()
        {
            TempData["SuccessMessage"] = null;
            return View(new Comprador());
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Comprador comprador)
        {
            if (ModelState.IsValid)
            {
                await _cadastroClienteService.CriarComprador(comprador);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
                return RedirectToAction("Index", "LoginCliente");
            }
            else
            {
                ViewBag.ErrorMessage = ("Por favor, preencha todos os campos corretamente.");
            }

            return View("Index", comprador);
        }

        [HttpPost]
        public async Task<IActionResult> CriarComprador(Comprador comprador)
        {
            try
            {
                var novoComprador = await _cadastroClienteService.CriarComprador(comprador);
                return RedirectToAction("ndex"); // Direciona para uma página de sucesso
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(comprador); // Retorna para a mesma página com os erros
            }
        }
    }
}
