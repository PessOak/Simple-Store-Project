using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class GerenciarProdutosService(GerenciarProdutosRepository gerenciarProdutosRepository)
    {
        private readonly GerenciarProdutosRepository _gerenciarProdutosRepository = gerenciarProdutosRepository;

    public async Task<IEnumerable<Produto>> ExibirProdutosCadastrados()
        {
            var produtoExiste = await _gerenciarProdutosRepository.ExibirProdutosCadastrados();

            return produtoExiste;
        }
    }
}
