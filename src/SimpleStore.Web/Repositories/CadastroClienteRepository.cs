using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class CadastroClienteRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Comprador> ObterPorEmail(string email)
        {   
            return await _context.Comprador.Where(comprador => comprador.EmailComp == email).FirstOrDefaultAsync();
        }

        public async Task<Comprador> Criar(Comprador comprador)
        {
            _context.Comprador.Add(comprador);
            await _context.SaveChangesAsync();
            return comprador;
        }

    }
}
