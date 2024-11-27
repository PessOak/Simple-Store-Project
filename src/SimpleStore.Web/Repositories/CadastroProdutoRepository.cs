using Dapper;
using SimpleStore.Web.Models;
using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace SimpleStore.Web.Repositories
{
    public class CadastroProdutoRepository
    {
        private readonly IDbConnection _dbConnection;

        public CadastroProdutoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> AdicionarProdutoAsync(Produto produto)
        {
            var query = @"
        INSERT INTO Produto (IdForn, NomeProd, DescProd, QuantProd, PrecoProd, CategProd, ImgUrl)
        VALUES (@IdForn, @NomeProd, @DescProd, @QuantProd, @PrecoProd, @CategProd, @ImgUrl);
        SELECT LAST_INSERT_ID();";

            Console.WriteLine($"Query: {query}");
            Console.WriteLine($"Parâmetros: IdForn={produto.IdForn}, NomeProd={produto.NomeProd}, DescProd={produto.DescProd}, QuantProd={produto.QuantProd}, PrecoProd={produto.PrecoProd}, CategProd={produto.CategProd}");

            return await _dbConnection.QuerySingleAsync<int>(query, new
            {
                produto.IdForn,
                produto.NomeProd,
                produto.DescProd,
                produto.QuantProd,
                produto.PrecoProd,
                produto.CategProd,
                produto.ImgUrl
            });
        }


        public async Task<bool> FornecedorExisteAsync(int idForn)
        {
            var query = "SELECT COUNT(1) FROM Fornecedor WHERE IdForn = @IdForn";
            return await _dbConnection.ExecuteScalarAsync<bool>(query, new { IdForn = idForn });
        }
    }
}
