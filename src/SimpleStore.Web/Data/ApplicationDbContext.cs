
//Classe responsavel por configurar e gerenciar a conexão com o banco de dados MySQL.

using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Models;

namespace SimpleStore.Web.Data
{   
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
        
            // O nome da propriedade deve ser exatamente igual está mapeado na tabela no banco de dados
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

                    // modelBuilder.Entity<ProdutoCarrinho>().HasNoKey();

                    modelBuilder.Entity<Carrinho>()
                        .HasMany(c => c.Produto)
                        .WithOne(p => p.Carrinho)
                        .HasForeignKey(p => p.IdCarrinho); // Especifica que a chave estrangeira em Produto é IdCarrinho


                    // Pedido.Where(p => p.IdPedido == 5).Single(); // é uma query equivalente ao SELECT * FROM pedido WHERE pedido = 5

                    // var carrinho = Carrinho.Where(p => p.IdCarrinho == 10).Single();

                    // Configura chave composta e relacionamento para ProdutoCarrinho
                    modelBuilder.Entity<ProdutoCarrinho>()
                        .HasKey(pc => new { pc.IdCarrinho, pc.IdProd });

                    modelBuilder.Entity<ProdutoCarrinho>()
                        .HasOne(pc => pc.Produto)
                        .WithMany()
                        .HasForeignKey(pc => pc.IdProd); // Relacionamento entre ProdutoCarrinho e Produto

                
        }
    }    
}