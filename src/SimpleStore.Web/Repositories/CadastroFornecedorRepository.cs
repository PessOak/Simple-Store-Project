using SimpleStore.Web.Data;

namespace SimpleStore.Web.Repositories
{
    public class CadastroFornecedorRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;
        
    }
}
