using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class LoginFornecedorRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<Fornecedor> ObterFornecedorPorEmailESenha(string email, string senha)
        {
            var query = "SELECT * FROM Fornecedor WHERE EmailForn = @Email AND SenhaForn = @Senha";

            return await _dbConnection.QuerySingleOrDefaultAsync<Fornecedor>(query, new { Email = email, Senha = senha });
        }
    }
}
