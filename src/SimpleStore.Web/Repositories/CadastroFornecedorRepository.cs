using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class CadastroFornecedorRepository(ApplicationDbContext context)
    {

        private readonly ApplicationDbContext _context = context;

        public async Task<Fornecedor> CriarFornecedor(Fornecedor fornecedor)
        {
            _context.Fornecedor.Add(fornecedor);
            await _context.SaveChangesAsync();
            return fornecedor;
        }
    }
}