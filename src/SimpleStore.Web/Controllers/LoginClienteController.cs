using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Threading.Tasks;

namespace SimpleStore.Web.Controllers
{
    public class LoginClienteController : Controller
    {
        private readonly LoginClienteService _loginclienteService;

        public LoginClienteController(LoginClienteService loginclienteService)
        {
            _loginclienteService = loginclienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Login()
        //{
        //    return View();
        //}

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                bool loginValido = await _loginclienteService.ValidarLogin(login.Email, login.Senha);

                if (loginValido)
                {
                    return RedirectToAction("Index","Produto"); // Redireciona para a página desejada após o login
                }
                else
                {
                    ModelState.AddModelError("", "CPF ou senha inválidos."); // Mensagem de erro
                }
            }

            return RedirectToAction("Index");
        }

    }
}
