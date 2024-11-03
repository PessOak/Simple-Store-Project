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
        public async Task<IActionResult> Create(Comprador comprador)
        {

            if (ModelState.IsValid)
            {
                await _cadastroService.CriarComprador(comprador);
                return RedirectToAction("Index", "LoginCliente");
            }

            return RedirectToAction("Index");
        }
    }
}
