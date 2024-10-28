using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class PerfilController : Controller
    {
        private readonly PerfilService _perfilService;

        public PerfilController(PerfilService perfilService)
        {
            _perfilService = perfilService;
        }

        // Carrega a página de perfil com detalhes completos
        public IActionResult Index()
        {
            var cpf = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Perfil = _perfilService.BuscarDadosComprador(cpf);
            if (Perfil == null)
            {
                return View("Error"); // Adicione uma view de erro adequada
            }
            return View(Perfil);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Perfil perfil)
        {
            if (ModelState.IsValid)
            {
                var sucesso = await _perfilService.AtualizarDadosComprador(perfil);
                if (sucesso)
                {
                    return RedirectToAction("Index", new { mensagem = "Perfil atualizado com sucesso!" });
                }
                else
                {
                    ModelState.AddModelError("", "Falha ao atualizar o perfil.");
                }
            }
            return View(perfil);
        }
    }
}