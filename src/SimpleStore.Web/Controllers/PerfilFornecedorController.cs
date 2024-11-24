using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class PerfilFornecedorController(PerfilFornecedorService perfilFornecedorService) : Controller
    {
        private readonly PerfilFornecedorService _perfilFornecedorService = perfilFornecedorService;

        // Carrega a página de perfil com detalhes completos
        public IActionResult Index()
        {
            var cnpj = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var perfilForn = _perfilFornecedorService.BuscarDadosComprador(cnpj);
            if (perfilForn == null)
            {
                return View("Error"); // Adicione uma view de erro adequada
            }
            return View(perfilForn);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Fornecedor perfilForn)
        {
            TempData["SuccessMessage"] = null;
            ViewBag.ErrorMessage = null;
            if (ModelState.IsValid)
            {
                var sucesso = await _perfilFornecedorService.AtualizarDadosComprador(perfilForn);
                TempData["SuccessMessage"] = "Cadastro realizado com sucesso!";
            }
            else
            {
                ViewBag.ErrorMessage = "Por favor, preencha todos os campos corretamente.";
            }
            return View("Index", perfilForn);
        }
    }
}
