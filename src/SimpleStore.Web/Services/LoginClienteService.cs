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

        public async Task<Comprador> ObterComprador(string email, string senha)
        {
            return await _loginclienteRepository.ObterCompradorPorEmailESenha(email, senha);
        }

        public bool ValidarLogin(Comprador Comprador)
        {
            return Comprador != null; // Retorna true se o comprador foi encontrado
            // Se necessário adicionar mais validações aqui
        }
    }
}
