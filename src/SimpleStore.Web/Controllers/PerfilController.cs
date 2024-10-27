using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Repositories;
using SimpleStore.Web.Services;
using SimpleStore.Web.Models;

public class PerfilController : Controller
{
    private readonly IDatabaseService _databaseService;

    public PerfilController(IDatabaseService databaseService)
    {
        _databaseService = databaseService;
    }

    // Carrega a página de perfil com detalhes completos
    [HttpGet]
    public IActionResult Index()
    {
        var cpf = User.Identity.Name;  // Assume-se que o CPF é mantido como identificador na autenticação
        var perfilViewModel = _databaseService.GetCompradorDetails(cpf);
        if (perfilViewModel == null)
        {
            return View("Error"); // Adicione uma view de erro adequada
        }
        return View(perfilViewModel);
    }

    // Exibe a página de edição de perfil
    [HttpGet]
    public IActionResult Editar()
    {
        var cpf = User.Identity.Name;
        var perfilViewModel = _databaseService.GetCompradorDetails(cpf);
        if (perfilViewModel == null)
        {
            return View("Error"); // Adicione uma view de erro adequada
        }
        return View(perfilViewModel);
    }

    // Processa as alterações no perfil
    [HttpPost]
    public IActionResult Editar(PerfilViewModel model)
    {
        if (ModelState.IsValid)
        {
            var updateResult = _databaseService.UpdateCompradorDetails(model);
            if (updateResult)
            {
                return RedirectToAction("Index", new { mensagem = "Perfil atualizado com sucesso!" });
            }
            else
            {
                ModelState.AddModelError("", "Falha ao atualizar o perfil.");
            }
        }
        return View(model);
    }
}