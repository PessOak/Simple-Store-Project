using Dapper;
using SimpleStore.Web.Controllers;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<Comprador> ListarClientesPorId(int CpfComp)
        {
            var consulta = "SELECT * FROM comprador WHERE CpfComp = @CpfComp";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Comprador>(consulta, new { CpfComp = CpfComp });
            }
        }

        // Métodos adicionais de CRUD podem ser adicionados aqui
    }
}
