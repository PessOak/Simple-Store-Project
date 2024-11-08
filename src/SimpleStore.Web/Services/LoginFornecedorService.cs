using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class LoginFornecedorService(LoginFornecedorRepository loginfornecedorRepository)
    {
        private readonly LoginFornecedorRepository _loginfornecedorRepository = loginfornecedorRepository;

        public async Task<Fornecedor> ObterFornecedor(string email, string senha)
        {
            return await _loginfornecedorRepository.ObterFornecedorPorEmailESenha(email, senha);
        }

        public bool ValidarLogin(Fornecedor fornecedor)
        {
            return fornecedor != null; // Retorna true se o comprador foi encontrado
            // Se necessário adicionar mais validações aqui
        }
    }
}
