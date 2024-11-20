using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CadastroFornecedorService(CadastroFornecedorRepository cadastroFornecedorRepository)
    {

        private readonly CadastroFornecedorRepository _cadastroFornecedorRepository = cadastroFornecedorRepository;

    }
}
