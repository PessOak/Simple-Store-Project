using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class PerfilController(PerfilService perfilService) : Controller
    {
        private readonly PerfilService _perfilService = perfilService;

        // Carrega a página de perfil com detalhes completos
        public IActionResult Index()
        {
            var cpf = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var perfil = _perfilService.BuscarDadosComprador(cpf);
            if (perfil == null)
            {
                return View("Error"); // Adicione uma view de erro adequada
            }
            return View(perfil);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Comprador perfil)
        {
            TempData["SuccessMessage"] = null;
            ViewBag.ErrorMessage = null;
            if (ModelState.IsValid)
            {
                var sucesso = await _perfilService.AtualizarDadosComprador(perfil);
                TempData["SuccessMessage"] = "Alteração realizada com sucesso!";
            }
            else
            {
                ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
            }
            return View("Index", perfil);
        }
    }
}