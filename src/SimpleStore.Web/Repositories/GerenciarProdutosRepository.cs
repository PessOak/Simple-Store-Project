using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class GerenciarProdutosRepository
    {
        private readonly ApplicationDbContext _context;

        public GerenciarProdutosRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ExibirProdutosCadastrados(int idFornecedor)
        {
            return await _context.Produto
                .Where(produto => produto.IdForn == idFornecedor)
                .OrderBy(produto => produto.IdProd)
                .ToListAsync();
        }

        public async Task<Produto> BuscarPeloId(int? id)
        {
            return await _context.Produto.FindAsync(id);
        }

        public async Task AtualizarProduto(Produto produto)
        {
            var produtoExistente = await _context.Produto.FindAsync(produto.IdProd);

            if (produtoExistente == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            produtoExistente.NomeProd = produto.NomeProd;
            produtoExistente.DescProd = produto.DescProd;
            produtoExistente.QuantProd = produto.QuantProd;
            produtoExistente.PrecoProd = produto.PrecoProd;
            produtoExistente.CategProd = produto.CategProd;

            if (produto.ImgUrl != null && produto.ImgUrl.Length > 0)
            {
                produtoExistente.ImgUrl = produto.ImgUrl;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeletarProduto(int id)
        {
            var produto = await _context.Produto.FindAsync(id);

            if (produto == null)
            {
                throw new Exception("Produto não encontrado.");
            }

            _context.Produto.Remove(produto);
            await _context.SaveChangesAsync();
        }

    }
}
