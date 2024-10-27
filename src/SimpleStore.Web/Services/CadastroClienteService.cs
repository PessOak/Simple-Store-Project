using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroClienteService
    {
        private readonly CadastroClienteRepository _cadastroClienteRepository;

        public CadastroClienteService (CadastroClienteRepository cadastroClienteRepository)
        {
            _cadastroClienteRepository = cadastroClienteRepository;
        }

        public async Task<IEnumerable<Comprador>> ListarClientes()
        {
            var cadastroCliente = await _cadastroClienteRepository.ListarClientes();

            return cadastroCliente;
        }

        public async Task<Comprador> ListarClientesPorId(int CpfComp)
        {
            var cpfCliente = await _cadastroClienteRepository.ListarClientesPorId(CpfComp);

            return cpfCliente;
        }
    }
}
