using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class PerfilFornecedorService(PerfilFornecedorRepository perfilfornecedorRepository)
    {
        private readonly PerfilFornecedorRepository _perfilFornecedorRepository = perfilfornecedorRepository;

        // Método para obter os detalhes do fornecedor
        public Fornecedor BuscarDadosComprador(string cnpj)
        {
            var perfilForn = _perfilFornecedorRepository.BuscarDadosComprador(cnpj);
            return perfilForn ?? throw new Exception("Perfil não encontrado.");
        }

        public async Task<bool> AtualizarDadosComprador(Fornecedor perfilForn)
        {
            if (string.IsNullOrWhiteSpace(perfilForn.NomeForn))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }

            var sucesso = await _perfilFornecedorRepository.AtualizarDadosComprador(perfilForn);
            if (!sucesso)
            {
                throw new Exception("Falha ao atualizar o perfil.");
            }
            return sucesso;
        }

    }
    
}
