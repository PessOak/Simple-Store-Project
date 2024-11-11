using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class LoginClienteController : Controller
    {
        private readonly LoginClienteService _loginClienteService;

        public LoginClienteController(LoginClienteService loginClienteService)
        {
            _loginClienteService = loginClienteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var comprador = await _loginClienteService.ObterComprador(login.Email, login.Senha);
                bool loginValido = _loginClienteService.ValidarLogin(comprador);

                if (loginValido)
                {
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
                        ExpiresUtc = DateTime.UtcNow.AddHours(12),
                        IsPersistent = true,
                    };

                    await HttpContext.SignInAsync(principal, props);
                    return RedirectToAction("Index", "Produto"); // Redireciona para a página desejada após o login
                }
                else
                {
                    ViewBag.ErrorMessage = "Email ou senha inválidos."; // Define a mensagem de erro para a View
                }
            }

            return View("Index", login); // Mantém o usuário na página de login com erros
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
