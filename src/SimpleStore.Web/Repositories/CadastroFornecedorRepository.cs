using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class CadastroFornecedorRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Fornecedor> ObterPorEmail(string email)
        {
            var fornecedor = await _context.Fornecedor.Where(c => c.EmailForn == email).FirstOrDefaultAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> CriarFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }
    }
}