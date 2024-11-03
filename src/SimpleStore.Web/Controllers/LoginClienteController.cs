using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class LoginClienteController(LoginClienteService loginClienteService) : Controller
    {
        private readonly LoginClienteService _loginClienteService = loginClienteService;

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
                var comprador = await _loginClienteService.ObterComprador(login.Email, login.Senha);
                bool loginValido = _loginClienteService.ValidarLogin(comprador);

                if (loginValido)
                {
                    // Pode adicionar propriedades para a sessão do usuário aqui
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, comprador.NomeComp),
                        new(ClaimTypes.NameIdentifier, comprador.CpfComp),
                        new(ClaimTypes.Email, comprador.EmailComp)
                    };

                    var identity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new(identity);

                    var props = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTime.UtcNow.ToLocalTime().AddHours(12),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, props);
                    return RedirectToAction("Index", "Produto"); // Redireciona para a página desejada após o login
                }
                else
                {
                    ModelState.AddModelError("", "CPF ou senha inválidos."); // Mensagem de erro
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }

    }
}
