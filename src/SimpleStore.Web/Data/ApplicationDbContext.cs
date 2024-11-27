using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // O nome da propriedade deve ser exatamente igual ao mapeado na tabela no banco de dados
        public DbSet<Administrador> Administrador { get; set; }
        public DbSet<Carrinho> Carrinho { get; set; }
        public DbSet<Comprador> Comprador { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoCarrinho> ProdutoCarrinho { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração do relacionamento entre Carrinho e Produto
            modelBuilder.Entity<Carrinho>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Carrinho)
                .HasForeignKey(p => p.IdCarrinho);

            // Configura chave composta e relacionamento para ProdutoCarrinho
            modelBuilder.Entity<ProdutoCarrinho>()
                .HasKey(pc => new { pc.IdCarrinho, pc.IdProd });

            modelBuilder.Entity<ProdutoCarrinho>()
                .HasOne(pc => pc.Produto)
                .WithMany()
                .HasForeignKey(pc => pc.IdProd);

            // Configuração para Produto: Alterar ImgUrl para MEDIUMBLOB
            modelBuilder.Entity<Produto>()
                .Property(p => p.ImgUrl)
                .HasColumnType("MEDIUMBLOB");
        }
    }
}
