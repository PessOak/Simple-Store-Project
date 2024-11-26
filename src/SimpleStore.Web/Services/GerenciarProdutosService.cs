using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class GerenciarProdutosService(GerenciarProdutosRepository gerenciarProdutosRepository)
    {
        private readonly GerenciarProdutosRepository _gerenciarProdutosRepository = gerenciarProdutosRepository;


    }
}
