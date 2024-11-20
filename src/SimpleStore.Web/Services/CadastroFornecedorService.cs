using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroFornecedorService(CadastroFornecedorRepository cadastroFornecedorRepository)
    {

        private readonly CadastroFornecedorRepository _cadastroFornecedorRepository = cadastroFornecedorRepository;

        public async Task<Fornecedor> CriarFornecedor(Fornecedor fornecedor)
        {
            return await _cadastroFornecedorRepository.CriarFornecedor(fornecedor);
        }
    }
}
