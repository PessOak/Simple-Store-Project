using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class LoginClienteRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<Comprador> ObterCompradorPorEmailESenha(string email, string senha)
        {
            var query = "SELECT * FROM comprador WHERE EmailComp = @Email AND SenhaComp = @Senha";

            return await _dbConnection.QuerySingleOrDefaultAsync<Comprador>(query, new { Email = email, Senha = senha });
        }
    }
}
