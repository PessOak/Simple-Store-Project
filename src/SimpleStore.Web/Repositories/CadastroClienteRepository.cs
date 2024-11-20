using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class CadastroClienteRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task<Comprador> CriarComprador(Comprador comprador)
        {
            var consulta = @"
                INSERT INTO comprador (CpfComp, NomeComp, EmailComp, SenhaComp)
                VALUES (@CpfComp, @NomeComp, @EmailComp, @SenhaComp);
                SELECT * FROM comprador WHERE CpfComp = @CpfComp;";

            return await _dbConnection.QuerySingleOrDefaultAsync<Comprador>(consulta, comprador);
        }
    }
}
