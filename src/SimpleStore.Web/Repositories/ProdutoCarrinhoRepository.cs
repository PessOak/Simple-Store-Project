using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Data;


namespace SimpleStore.Web.Repositories
{
    public class ProdutoCarrinhoRepository(IDbConnection dbConnection)
    {
        private readonly IDbConnection _dbConnection = dbConnection;

        public async Task AdicionarProdutoAoCarrinho(int idCarrinho, int produtoId, int quantidade)
        {
            var query = @"
                INSERT INTO ProdutoCarrinho (IdCarrinho, IdProd, QuantProdCarrinho)
                VALUES (@IdCarrinho, @IdProd, @QuantProdCarrinho)
                ON DUPLICATE KEY UPDATE 
                    QuantProdCarrinho = QuantProdCarrinho + @QuantProdCarrinho;";

            await _dbConnection.ExecuteAsync(query, new
            {
                IdCarrinho = idCarrinho,  // Placeholder para o ID do carrinho (ex.: carrinho do usuário logado)
                IdProd = produtoId,
                QuantProdCarrinho = quantidade
            });

            var valorProduto = await _dbConnection.QuerySingleOrDefaultAsync<float>("SELECT PrecoProd FROM Produto WHERE IdProd = @IdProd", new { IdProd = produtoId });
            // trocar float por DECIMAL para não dar erros quando calcular a soma de TotalCarrinho
            var queryUpdateCarrinho = @"
                UPDATE Carrinho
                SET ValorTotalCarrinho = ValorTotalCarrinho + @valorProduto
                WHERE IdCarrinho = @IdCarrinho";

            await _dbConnection.ExecuteAsync(queryUpdateCarrinho, new { IdCarrinho = idCarrinho, valorProduto });
        }
    }
}
