using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class LoginClienteService(LoginClienteRepository loginclienteRepository)
    {
        private readonly LoginClienteRepository _loginclienteRepository = loginclienteRepository;

        public async Task<Comprador> ObterComprador(string email, string senha)
        {
            return await _loginclienteRepository.ObterCompradorPorEmailESenha(email, senha);
        }

        public bool ValidarLogin(Comprador comprador)
        {
            return comprador != null; // Retorna true se o comprador foi encontrado
            // Se necessário adicionar mais validações aqui
        }
    }
}
