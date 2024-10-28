using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models; // Substitua pelo namespace correto dos seus modelos

public class PerfilRepository
{
    private readonly MySqlContext _context;

    public PerfilRepository(MySqlContext context)
    {
        _context = context;
    }

    public Perfil BuscarDadosComprador(string cpf)
    {
        using (var connection = _context.CreateConnection()) {
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

    public bool AtualizarDadosComprador(Comprador dados)
    {
        //var sqlcomprador = "update comprador set nomecomp = @nomecomp, emailcomp = @emailcomp where cpfcomp = @cpfcomp;";
        //var sqlendereco = "update enderecocomprador set logradouroendereco = @logradouroendereco, numeroendereco = @numeroendereco, bairroendereco = @bairroendereco, cidadeendereco = @cidadeendereco, estadoendereco = @estadoendereco, cependereco = @cependereco where cpfcomp = @cpfcomp;";
        //var sqlfone = "update fonecomprador set fonecomp = @fonecomp where cpfcomp = @cpfcomp;";

        //using (var transaction = _context.begintransaction())
        //{
        //    _context.execute(sqlcomprador, dados, transaction);
        //    _context.execute(sqlendereco, dados, transaction);
        //    _context.execute(sqlfone, dados, transaction);

        //    transaction.commit();
        //    return true;
        //}
        return true;
    }
}
