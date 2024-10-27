using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class LoginClienteService
    {
        private readonly LoginClienteRepository _loginclienteRepository;

        public LoginClienteService(LoginClienteRepository loginclienteRepository)
        {
            _loginclienteRepository = loginclienteRepository;
        }

        public async Task<bool> ValidarLogin(string email, string senha)
        {
            var comprador = await _loginclienteRepository.ObterCompradorPorEmailESenha(email, senha);
            return comprador != null; // Retorna true se o comprador foi encontrado
        }
    }
}
