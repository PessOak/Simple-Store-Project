using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroClienteService(CadastroClienteRepository cadastroClienteRepository)
    {
        private readonly CadastroClienteRepository _cadastroClienteRepository = cadastroClienteRepository;

        public async Task<Comprador> CriarComprador(Comprador comprador)
        {
            return await _cadastroClienteRepository.CriarComprador(comprador);
        }
    }
}
