using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroFornecedorService(CadastroFornecedorRepository cadastroFornecedorRepository)
    {
        private readonly CadastroFornecedorRepository _cadastroFornecedorRepository = cadastroFornecedorRepository;

        public async Task<Fornecedor> CriarFornecedor(Fornecedor fornecedor)
        {
            var FornecedorExistente = await _cadastroFornecedorRepository.ObterPorEmail(fornecedor.EmailForn);
            if (FornecedorExistente != null)
            {
                throw new ArgumentException("O e-mail já está cadastrado.");
            }

            return await _cadastroFornecedorRepository.CriarFornecedor(fornecedor);
        }
    }
}
