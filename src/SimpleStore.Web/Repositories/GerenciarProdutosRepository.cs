using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class GerenciarProdutosRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Produto>> ExibirProdutosCadastrados(int idFornecedor)
        {
            return await _context.Produto
                .Where(produto => produto.IdForn == idFornecedor) // Filtro pelo IdForn
                .OrderBy(produto => produto.IdProd) // Ordena pelo Id do Produto, opcional
                .ToListAsync();
        }

        public async Task<Produto> BuscarPeloId(int? id)
        {
            var dados = await _context.Produto.FindAsync(id);
            return dados;

        }

        public async Task<Produto> AtualizarProduto(Produto produto)
        {
            _context.Produto.Update(produto);
            await _context.SaveChangesAsync();
            return produto;
        }
    }
}
