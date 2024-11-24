using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class PerfilRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public Comprador BuscarDadosComprador(string cpf)
        {
            // Busca os dados principais do comprador
            var perfil = _dbConnection.Query<Comprador>("SELECT * FROM comprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();
            return perfil;
        }

        public async Task<bool> AtualizarDadosComprador(Comprador perfil)
        {
            var sqlComprador = "UPDATE comprador SET NomeComp = @NomeComp, FoneComp = @FoneComp, LogradouroComp = @LogradouroComp, NumeroComp = @NumeroComp, BairroComp = @BairroComp, CidadeComp = @CidadeComp, EstadoComp = @EstadoComp, CepComp = @CepComp WHERE CpfComp = @CpfComp;";

            var linhasAfetadas = await _dbConnection.ExecuteAsync(sqlComprador, perfil);
            return linhasAfetadas > 0; // Retorna true se uma linha foi atualizada
        }
    }
}