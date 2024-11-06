using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class ProdutoCarrinhoService(ProdutoCarrinhoRepository produtoCarrinhoRepository)
    {
        private readonly ProdutoCarrinhoRepository _produtoCarrinhoRepository = produtoCarrinhoRepository;

        public async Task AdicionarProdutoAoCarrinho(int idCarrinho, int produtoId, int quantidade)
        {
            // Chama o repositório para adicionar o produto ao carrinho
            await _produtoCarrinhoRepository.AdicionarProdutoAoCarrinho(idCarrinho, produtoId, quantidade);
        }
    }
}
