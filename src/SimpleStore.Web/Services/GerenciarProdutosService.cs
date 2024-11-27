using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class GerenciarProdutosService(GerenciarProdutosRepository gerenciarProdutosRepository)
    {
        private readonly GerenciarProdutosRepository _gerenciarProdutosRepository = gerenciarProdutosRepository;

        public async Task<IEnumerable<Produto>> ExibirProdutosCadastrados(int idFornecedor)
        {
            var produtos = await _gerenciarProdutosRepository.ExibirProdutosCadastrados(idFornecedor);

            if (produtos == null || !produtos.Any())
            {
                throw new Exception("Nenhum produto encontrado para o fornecedor especificado.");
            }

            return produtos;
        }
    }
}
