using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class GerenciarProdutosService
    {
        private readonly GerenciarProdutosRepository _gerenciarProdutosRepository;

        public GerenciarProdutosService(GerenciarProdutosRepository gerenciarProdutosRepository)
        {
            _gerenciarProdutosRepository = gerenciarProdutosRepository;
        }

        public async Task<IEnumerable<Produto>> ExibirProdutosCadastrados(int idFornecedor)
        {
            var produtos = await _gerenciarProdutosRepository.ExibirProdutosCadastrados(idFornecedor);

            if (produtos == null || !produtos.Any())
            {
                throw new Exception("Nenhum produto encontrado para o fornecedor especificado.");
            }

            return produtos;
        }

        public async Task<Produto> BuscarPeloId(int? id)
        {
            var dados = await _gerenciarProdutosRepository.BuscarPeloId(id);

            if (dados == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            return dados;
        }

        public async Task AtualizarProduto(Produto produto)
        {
            await _gerenciarProdutosRepository.AtualizarProduto(produto);
        }

        public async Task DeletarProduto(int id)
        {
            await _gerenciarProdutosRepository.DeletarProduto(id);
        }

    }
}
