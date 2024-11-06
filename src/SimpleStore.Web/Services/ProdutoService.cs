using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class ProdutoService(ProdutoRepository produtoRepository)
    {
        private readonly ProdutoRepository _produtoRepository = produtoRepository;

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            var produtos = await _produtoRepository.ListarProdutos();

            return produtos;
        }

        public async Task<Produto> ListarProdutoPeloNome(string nome)
        {
            var produto = await _produtoRepository.ListarProdutoPeloNome(nome);

            return produto;
        }
    }
}
