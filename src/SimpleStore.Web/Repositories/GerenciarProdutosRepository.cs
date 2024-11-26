using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Repositories
{
    public class GerenciarProdutosRepository(ApplicationDbContext context)
    {
        private readonly ApplicationDbContext _context = context;
        
        //public async Task<Produto> ExibirProdutosCadastrados(string produtos)
        //{
        //    //return await _context.Produto.ToList<>
        //}

    }
}
