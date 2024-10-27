using Dapper;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class ProdutoRepository
    {
        private readonly MySqlContext _context;

        public ProdutoRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ListarProdutos()
        {
            var query = "SELECT * FROM produto";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Produto>(query);
            }
        }

        public async Task<Produto> ListarProdutoPorId(int id)
        {
            var query = "SELECT * FROM produto WHERE IdProd = @Id";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Produto>(query, new { Id = id });
            }
        }

        // Métodos adicionais de CRUD podem ser adicionados aqui
    }
}
