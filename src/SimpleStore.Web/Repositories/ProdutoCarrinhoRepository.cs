using Dapper;
using Microsoft.EntityFrameworkCore;
using SimpleStore.Web.Data;
using SimpleStore.Web.Models;
using System.Data;
using System.Data.Common;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


namespace SimpleStore.Web.Repositories
{
    public class ProdutoCarrinhoRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProdutoCarrinhoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AdicionarProdutoAoCarrinho(int idCarrinho, int produtoId, int quantidade)
        {
            var query = @"
            INSERT INTO ProdutoCarrinho (IdCarrinho, IdProd, QuantProdCarrinho)
            VALUES (@IdCarrinho, @IdProd, @QuantProdCarrinho)
            ON DUPLICATE KEY UPDATE 
                QuantProdCarrinho = QuantProdCarrinho + @QuantProdCarrinho;";

            await _dbConnection.ExecuteAsync(query, new
            {
                IdCarrinho = idCarrinho,
                IdProd = produtoId,
                QuantProdCarrinho = quantidade
            });
        }

        public async Task<bool> AtualizarValorTotalCarrinho(int idCarrinho, int produtoId, int quantidade)
        { 
            // Atualizar o valor total do carrinho
            var valorProduto = await _dbConnection.QuerySingleOrDefaultAsync<decimal>("SELECT PrecoProd FROM Produto WHERE IdProd = @IdProd", new { IdProd = produtoId });
            var valorTotalCarrinho = quantidade * valorProduto;
            var queryUpdateCarrinho = @"
                    UPDATE Carrinho
                    SET ValorTotalCarrinho = ValorTotalCarrinho + @valorTotalCarrinho
                    WHERE IdCarrinho = @IdCarrinho"
            ;

            var resultado = await _dbConnection.ExecuteAsync(queryUpdateCarrinho, new { IdCarrinho = idCarrinho, valorTotalCarrinho });

            return resultado > 0; // Retorna true se o produto foi removido com sucesso
        }

        public async Task<bool> RemoverProdutoDoCarrinhoAsync(int idCarrinho, int idProduto)
        {
            var query = @"
        DELETE FROM ProdutoCarrinho
        WHERE IdCarrinho = @IdCarrinho
        AND IdProd = @IdProduto";

            var resultado = await _dbConnection.ExecuteAsync(query, new { IdCarrinho = idCarrinho, IdProduto = idProduto });

            return resultado > 0; // Retorna true se o produto foi removido com sucesso
        }


        public async Task<int> ObterIdCarrinhoUsuarioAsync(string cpfComp)
        {
            var query = "SELECT IdCarrinho FROM Carrinho WHERE CpfComp = @CpfComp";
            return await _dbConnection.QuerySingleOrDefaultAsync<int>(query, new { CpfComp = cpfComp });
        }
    }

}
