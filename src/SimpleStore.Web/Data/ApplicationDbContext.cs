
//Classe responsavel por configurar e gerenciar a conexão com o banco de dados MySQL.

using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        // O nome da propriedade deve ser exatamente igual está mapeado na tabela no banco de dados
        public DbSet<Produto> Administrador { get; set; }
        
        public DbSet<Produto> Carrinho { get; set; }
        
        public DbSet<Produto> EnderecoComprador { get; set; }
        
        public DbSet<Produto> EnderecoFornecedor { get; set; }
        
        public DbSet<Produto> FoneComprador { get; set; }
        
        public DbSet<Produto> FoneFornecedor { get; set; }
        
        public DbSet<Produto> Fornecedor { get; set; }
        
        public DbSet<Produto> Login { get; set; }
        
        public DbSet<Produto> Pedido { get; set; }
        
        public DbSet<Produto> Perfil { get; set; }
        
        public DbSet<Produto> Produto { get; set; }
        
        public DbSet<Produto> ProdutoCarrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais de mapeamento, se necessário
        }
    }
}