using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class LoginFornecedorController(LoginFornecedorService loginFornecedorService) : Controller
    {
        private readonly LoginFornecedorService _loginFornecedorService = loginFornecedorService;

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
                var fornecedor = await _loginFornecedorService.ObterFornecedor(login.Email, login.Senha);
                bool loginValido = _loginFornecedorService.ValidarLogin(fornecedor);

                if (loginValido)
                {
                    // Pode adicionar propriedades para a sessão do usuário aqui
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, fornecedor.NomeForn),
                        new(ClaimTypes.NameIdentifier, fornecedor.DocForn),
                        new(ClaimTypes.Email, fornecedor.EmailForn)
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
                    ModelState.AddModelError("", "Documento ou senha inválidos."); // Mensagem de erro
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
