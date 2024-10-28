using Dapper;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class CadastroClienteRepository
    {
        private readonly MySqlContext _context;

        public CadastroClienteRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comprador>> ListarClientes()
        {
           
            var consulta = "SELECT * FROM comprador";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QueryAsync<Comprador>(consulta);
            }
        }

        public async Task<Comprador> ListarClientesPorCpf(int CpfComp)
        {
            var consulta = "SELECT * FROM comprador WHERE CpfComp = @CpfComp";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Comprador>(consulta, new { CpfComp = CpfComp });
            }
        }

        public async Task<Comprador> CriarComprador(Comprador Comprador)
        {
            var consulta = @"
                INSERT INTO comprador (CpfComp, NomeComp, EmailComp, SenhaComp)
                VALUES (@CpfComp, @NomeComp, @EmailComp, @SenhaComp);
                SELECT * FROM comprador WHERE CpfComp = @CpfComp;";

            using (var connection = _context.CreateConnection())
            {
              return await connection.QuerySingleOrDefaultAsync<Comprador>(consulta, Comprador);
            }
        }
    }
}
