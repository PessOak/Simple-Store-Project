using Dapper;
using SimpleStore.Web.Models;
using System.Data;


namespace SimpleStore.Web.Repositories
{
    public class PerfilFornecedorRepository(IDbConnection dbConnection)
    {
         private readonly IDbConnection _dbConnection = dbConnection;

        public Fornecedor BuscarDadosComprador(string cnpj)
        {
            // Busca os dados principais do comprador
            var perfilForn = _dbConnection.Query<Fornecedor>("SELECT * FROM fornecedor WHERE DocForn = @DocForn", new { DocForn = cnpj }).FirstOrDefault();
            return perfilForn;
        }

        public async Task<bool> AtualizarDadosComprador(Fornecedor perfilForn)
        {
            var sqlFornecedor = "UPDATE fornecedor SET NomeForn = @NomeForn, LinkZapForn = @LinkZapForn, RazaoSocialForn = @RazaoSocialForn, FoneForn = @FoneForn, LogradouroForn = @LogradouroForn, NumeroForn = @NumeroForn, BairroForn = @BairroForn, CidadeForn = @CidadeForn, EstadoForn = @EstadoForn, CepForn = @CepForn WHERE DocForn = @DocForn;";

            var linhasAfetadas = await _dbConnection.ExecuteAsync(sqlFornecedor, perfilForn);
            return linhasAfetadas > 0; // Retorna true se uma linha foi atualizada
        }

    }
}
