using Dapper;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

public class PerfilRepository
{
    private readonly MySqlContext _context;

    public PerfilRepository(MySqlContext context)
    {
        _context = context;
    }

    public Perfil BuscarDadosComprador(string cpf)
    {
        using (var connection = _context.CreateConnection())
        {
            // Busca os dados principais do comprador
            var perfil = connection.Query<Perfil>("SELECT * FROM Comprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();

            if (perfil != null)
            {
                // Busca os endereços associados ao comprador
                perfil.EnderecoComprador = connection.Query<EnderecoComprador>("SELECT * FROM EnderecoComprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();

                // Busca os telefones associados ao comprador
                perfil.FoneComprador = connection.Query<FoneComprador>("SELECT * FROM FoneComprador WHERE CpfComp = @CpfComp", new { CpfComp = cpf }).FirstOrDefault();
            }

            return perfil;
        }
    }

    public async Task<bool> AtualizarDadosComprador(Perfil perfil)
    {
        var sqlComprador = "UPDATE comprador SET NomeComp = @NomeComp, EmailComp = @EmailComp, SenhaComp = @SenhaComp WHERE CpfComp = @CpfComp;";

        // TODO: Criar lógica para atualizar o endereço e fone
        // var sqlEndereco = "update enderecocomprador set logradouroendereco = @logradouroendereco, numeroendereco = @numeroendereco, bairroendereco = @bairroendereco, cidadeendereco = @cidadeendereco, estadoendereco = @estadoendereco, cependereco = @cependereco where cpfcomp = @cpfcomp;";
        // var sqlFone = "update fonecomprador set fonecomp = @fonecomp where cpfcomp = @cpfcomp;";

        using (var connection = _context.CreateConnection())
        {
            var linhasAfetadas = await connection.ExecuteAsync(sqlComprador, perfil);
            return linhasAfetadas > 0; // Retorna true se uma linha foi atualizada
        }
    }
}
