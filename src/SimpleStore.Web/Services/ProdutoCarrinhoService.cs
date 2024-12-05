using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class ProdutoCarrinhoService
    {
        private readonly ProdutoCarrinhoRepository _produtoCarrinhoRepository;

        public ProdutoCarrinhoService(ProdutoCarrinhoRepository produtoCarrinhoRepository)
        {
            _produtoCarrinhoRepository = produtoCarrinhoRepository;
        }

        public async Task AdicionarProdutoAoCarrinho(int idCarrinho, int produtoId, int quantidade)
        {
            await _produtoCarrinhoRepository.AdicionarProdutoAoCarrinho(idCarrinho, produtoId, quantidade);

            await _produtoCarrinhoRepository.AtualizarValorTotalCarrinho(idCarrinho, produtoId, quantidade);
        }

        //remoção de produto do carrinho
        public async Task<bool> RemoverProdutoDoCarrinhoAsync(int idCarrinho, int idProduto, int quantidade)
        {
            // Chama o repositório para remover o produto do carrinho
            return await _produtoCarrinhoRepository.RemoverProdutoDoCarrinhoAsync(idCarrinho, idProduto) &&
            await _produtoCarrinhoRepository.AtualizarValorTotalCarrinho(idCarrinho, idProduto, -quantidade);
        }

        // Método para obter o id do carrinho do usuário (opcional, caso precise)
        public async Task<int> ObterIdCarrinhoUsuarioAsync(string cpfComp)
        {
            // Lógica para buscar o carrinho do usuário
            var carrinhoId = await _produtoCarrinhoRepository.ObterIdCarrinhoUsuarioAsync(cpfComp);
            return carrinhoId;
        }
    }
}
