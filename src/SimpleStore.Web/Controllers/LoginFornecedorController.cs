using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.Web.Enums;
using SimpleStore.Web.Models;
using SimpleStore.Web.Services;
using System.Security.Claims;

namespace SimpleStore.Web.Controllers
{
    public class LoginFornecedorController : Controller
    {
        private readonly LoginFornecedorService _loginFornecedorService;

        public LoginFornecedorController(LoginFornecedorService loginFornecedorService)
        {
            _loginFornecedorService = loginFornecedorService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFornecedor login)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = await _loginFornecedorService.ObterFornecedor(login.Email, login.Senha);
                bool loginValido = _loginFornecedorService.ValidarLogin(fornecedor);

                if (loginValido)
                {
                    var claims = new List<Claim>
                    {
                        new(ClaimTypes.Name, fornecedor.NomeForn),
                        new(ClaimTypes.NameIdentifier, fornecedor.IdForn.ToString()),
                        new("CNPJ", fornecedor.DocForn),
                        new(ClaimTypes.Email, fornecedor.EmailForn),
                        new(ClaimTypes.Role, PapelUsuario.Fornecedor.ToString())
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
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ViewBag.ErrorMessage = "Email ou senha inválidos.";
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
