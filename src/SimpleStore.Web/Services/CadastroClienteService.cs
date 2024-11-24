using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;
namespace SimpleStore.Web.Services
{
    public class CadastroClienteService(CadastroClienteRepository cadastroClienteRepository)
    {
        private readonly CadastroClienteRepository _cadastroClienteRepository = cadastroClienteRepository;

        public async Task<Comprador> CriarComprador(Comprador comprador)
        {
            var compradorExistente = await _cadastroClienteRepository.ObterPorEmail(comprador.EmailComp);
            if (compradorExistente != null)
            {
                throw new ArgumentException("O e-mail já está cadastrado.");
            }

            return await _cadastroClienteRepository.CriarComprador(comprador);
        }
    }
}
