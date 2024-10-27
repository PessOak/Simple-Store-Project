using Dapper;
using SimpleStore.Web.Controllers;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleStore.Web.Repositories
{
    public class LoginClienteRepository
    {
        private readonly MySqlContext _context;

        public LoginClienteRepository(MySqlContext context)
        {
            _context = context;
        }

        public async Task<Comprador> ObterCompradorPorEmailESenha(string email, string senha)
        {
            var query = "SELECT * FROM comprador WHERE EmailComp = @Email AND SenhaComp = @Senha";

            using (var connection = _context.CreateConnection())
            {
                return await connection.QuerySingleOrDefaultAsync<Comprador>(query, new { Email = email, Senha = senha });
            }
        }
    }
}
