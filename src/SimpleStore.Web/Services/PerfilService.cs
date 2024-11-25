using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class PerfilService(PerfilRepository perfilRepository)
    {
        private readonly PerfilRepository _perfilRepository = perfilRepository;

        // Método para obter os detalhes do comprador
        public Comprador BuscarDadosComprador(string cpf)
        {
            var perfil = _perfilRepository.BuscarDadosComprador(cpf);
            return perfil ?? throw new Exception("Perfil não encontrado.");
        }

        public async Task<bool> AtualizarDadosComprador(Comprador perfil)
        {
            if (string.IsNullOrWhiteSpace(perfil.NomeComp))
            {
                throw new ArgumentException("O nome não pode ser vazio.");
            }

            var sucesso = await _perfilRepository.AtualizarDadosComprador(perfil);
            if (!sucesso)
            {
                throw new Exception("Falha ao atualizar o perfil.");
            }
            return sucesso;
        }
    }
}