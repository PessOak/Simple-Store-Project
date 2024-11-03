
//Classe responsavel por configurar e gerenciar a conexão com o banco de dados MySQL.

using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        // O nome da propriedade deve ser exatamente igual está mapeado na tabela no banco de dados
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Comprador> Comprador { get; set; }
        public DbSet<EnderecoComprador> EnderecoComprador { get; set; }
        public DbSet<EnderecoFornecedor> EnderecoFornecedor { get; set; }
        public DbSet<FoneComprador> FoneComprador { get; set; }
        public DbSet<FoneFornecedor> FoneFornecedor { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FoneComprador>().HasNoKey();
            modelBuilder.Entity<FoneFornecedor>().HasNoKey();
            modelBuilder.Entity<ProdutoCarrinho>().HasNoKey();

            modelBuilder.Entity<Carrinho>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Carrinho)
                .HasForeignKey(p => p.IdCarrinho); // Especifica que a chave estrangeira em Produto é IdCarrinho
        }
    }
}