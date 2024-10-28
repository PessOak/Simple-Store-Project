using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;
using SimpleStore.Web.Models;

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
            var cpf = User.Identity.Name;  // Assume-se que o CPF é mantido como identificador na autenticação
            var Perfil = _perfilService.BuscarDadosComprador(cpf);
            if (Perfil == null)
            {
                return View("Error"); // Adicione uma view de erro adequada
            }
            return View(Perfil);
        }

        // Exibe a página de edição de perfil
        //[HttpGet]
        //public IActionResult Editar()
        //{
        //    var cpf = User.Identity.Name;
        //    var Comprador = _perfilService.BuscarDadosComprador(cpf);
        //    if (Comprador == null)
        //    {
        //        return View("Error"); // Adicione uma view de erro adequada
        //    }
        //    return View(Comprador);
        //}

        // Processa as alterações no perfil
        [HttpPost]
        public IActionResult Editar(Comprador dados)
        {
            if (ModelState.IsValid)
            {
                var AtualizarDados = _perfilService.AtualizarDadosComprador(dados);
                if (AtualizarDados)
                {
                    return RedirectToAction("Index", new { mensagem = "Perfil atualizado com sucesso!" });
                }
                else
                {
                    ModelState.AddModelError("", "Falha ao atualizar o perfil.");
                }
            }
            return View(dados);
        }
    }
}