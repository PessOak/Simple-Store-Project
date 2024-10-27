using Dapper;
using SimpleStore.Web.Controllers;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Data;

public class PerfilRepository : IPerfilRepository
{
    private readonly IDbConnection _dbConnection;

    public PerfilRepository(IDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    // Busca detalhes completos do comprador
    public PerfilViewModel GetCompradorDetails(string cpf)
    {
        var sql = @"
            SELECT * FROM Comprador WHERE CpfComp = @Cpf;
            SELECT * FROM EnderecoComprador WHERE CpfComp = @Cpf;
            SELECT * FROM FoneComprador WHERE CpfComp = @Cpf;
        ";

        using (var multipleResults = _dbConnection.QueryMultiple(sql, new { Cpf = cpf }))
        {
            var comprador = multipleResults.Read<Comprador>().FirstOrDefault();
            if (comprador != null)
            {
                comprador.EnderecoCompradores = multipleResults.Read<EnderecoComprador>().ToList();
                comprador.FoneCompradores = multipleResults.Read<FoneComprador>().ToList();
            }

            return comprador != null ? new PerfilViewModel
            {
                CpfComp = comprador.CpfComp,
                NomeComp = comprador.NomeComp,
                EmailComp = comprador.EmailComp,
                LogradouroEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.LogradouroEndereco,
                NumeroEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.NumeroEndereco,
                BairroEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.BairroEndereco,
                CidadeEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.CidadeEndereco,
                EstadoEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.EstadoEndereco,
                CepEndereco = comprador.EnderecoCompradores.FirstOrDefault()?.CepEndereco,
                FoneComp = comprador.FoneCompradores.FirstOrDefault()?.FoneComp
            } : null;
        }
    }

    // Atualiza detalhes do comprador
    public bool UpdateCompradorDetails(PerfilViewModel model)
    {
        var sqlComprador = "UPDATE Comprador SET NomeComp = @Nome, EmailComp = @Email WHERE CpfComp = @Cpf;";
        var sqlEndereco = "UPDATE EnderecoComprador SET LogradouroEndereco = @Logradouro, NumeroEndereco = @Numero, BairroEndereco = @Bairro, CidadeEndereco = @Cidade, EstadoEndereco = @Estado, CepEndereco = @Cep WHERE CpfComp = @Cpf;";
        var sqlFone = "UPDATE FoneComprador SET FoneComp = @Fone WHERE CpfComp = @Cpf;";

        using (var transaction = _dbConnection.BeginTransaction())
        {
            _dbConnection.Execute(sqlComprador, new { Nome = model.NomeComp, Email = model.EmailComp, Cpf = model.CpfComp }, transaction);
            _dbConnection.Execute(sqlEndereco, new
            {
                Logradouro = model.LogradouroEndereco,
                Numero = model.NumeroEndereco,
                Bairro = model.BairroEndereco,
                Cidade = model.CidadeEndereco,
                Estado = model.EstadoEndereco,
                Cep = model.CepEndereco,
                Cpf = model.CpfComp
            }, transaction);
            _dbConnection.Execute(sqlFone, new { Fone = model.FoneComp, Cpf = model.CpfComp }, transaction);

            transaction.Commit();
            return true;
        }
    }
}

public interface IPerfilRepository
{
    PerfilViewModel GetCompradorDetails(string cpf);
    bool UpdateCompradorDetails(PerfilViewModel model);
}
