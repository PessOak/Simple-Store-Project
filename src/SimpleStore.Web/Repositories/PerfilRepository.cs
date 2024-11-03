using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class PerfilRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public Perfil BuscarDadosComprador(string cpf)
        {
            // Busca os dados principais do comprador
            var perfil = _dbConnection.Query<Perfil>("SELECT * FROM Comprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();

            if (perfil != null)
            {
                // Busca os endereços associados ao comprador
                perfil.EnderecoComprador = _dbConnection.Query<EnderecoComprador>("SELECT * FROM EnderecoComprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();

                // Busca os telefones associados ao comprador
                perfil.FoneComprador = _dbConnection.Query<FoneComprador>("SELECT * FROM FoneComprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();
            }

            return perfil;
        }

        public async Task<bool> AtualizarDadosComprador(Perfil perfil)
        {
            var sqlComprador = "UPDATE comprador SET NomeComp = @NomeComp, EmailComp = @EmailComp, SenhaComp = @SenhaComp WHERE CpfComp = @CpfComp;";

            // TODO: Criar lógica para atualizar o endereço e fone
            // var sqlEndereco = "update enderecocomprador set logradouroendereco = @logradouroendereco, numeroendereco = @numeroendereco, bairroendereco = @bairroendereco, cidadeendereco = @cidadeendereco, estadoendereco = @estadoendereco, cependereco = @cependereco where cpfcomp = @cpfcomp;";
            // var sqlFone = "update fonecomprador set fonecomp = @fonecomp where cpfcomp = @cpfcomp;";

            var linhasAfetadas = await _dbConnection.ExecuteAsync(sqlComprador, perfil);
            return linhasAfetadas > 0; // Retorna true se uma linha foi atualizada
        }
    }
}