using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class ProdutoRepository(IDbConnection dbConnection, ApplicationDbContext context)
    {
        private readonly IDbConnection _dbConnection = dbConnection;
        private readonly ApplicationDbContext _context = context;

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            //var query = "SELECT * FROM produto";

            //return await _dbConnection.QueryAsync<Produto>(query);

            return await _context.Produto.OrderBy(p => p.NomeProd).ToListAsync();
        }

        public async Task<Produto> ListarProdutoPeloNome(string nome)
        {
            var query = "SELECT * FROM produto WHERE NomeProd = @Nome";

            return await _dbConnection.QuerySingleOrDefaultAsync<Produto>(query, new { Nome = nome });
        }
    }
}
