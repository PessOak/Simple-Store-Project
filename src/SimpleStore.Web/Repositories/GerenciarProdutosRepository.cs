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
    }

}
