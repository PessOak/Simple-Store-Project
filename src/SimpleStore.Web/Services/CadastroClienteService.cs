using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroClienteService(CadastroClienteRepository cadastroClienteRepository)
    {
        private readonly CadastroClienteRepository _cadastroClienteRepository = cadastroClienteRepository;

        public async Task<IEnumerable<Comprador>> ListarClientes()
        {
            var cadastroCliente = await _cadastroClienteRepository.ListarClientes();

            return cadastroCliente;
        }

        public async Task<Comprador> ListarClientesPorCpf(int cpf)
        {
            var cpfCliente = await _cadastroClienteRepository.ListarClientesPorCpf(cpf);

            return cpfCliente;
        }

        public async Task<Comprador> CriarComprador(Comprador comprador)
        {
            return await _cadastroClienteRepository.CriarComprador(comprador);
        }
    }
}
