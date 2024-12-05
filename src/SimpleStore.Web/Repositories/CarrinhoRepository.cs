using Dapper;
using SimpleStore.Web.Models;
using System.Data;

namespace SimpleStore.Web.Repositories
{
    public class CarrinhoRepository
    {
        private readonly IDbConnection _dbConnection;

        public CarrinhoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task CriarCarrinhoAsync(Carrinho carrinho)
        {
            var query = @"
        INSERT INTO Carrinho (CpfComp, ValorTotalCarrinho)
        VALUES (@CpfComp, 0);"; // Inicializando com ValorTotalCarrinho = 0

            await _dbConnection.ExecuteAsync(query, new { CpfComp = carrinho.CpfComp });
        }



        public async Task<Carrinho> ObterCarrinhoPorCpfAsync(string cpfComp)
        {
            // Query para obter o carrinho e seus produtos
            var query = @"
        SELECT 
            c.IdCarrinho,
            c.CpfComp,
            c.ValorTotalCarrinho,
            pc.IdCarrinho AS ProdutoCarrinhoIdCarrinho,
            pc.IdProd AS ProdutoCarrinhoIdProd,
            pc.QuantProdCarrinho,
            p.IdProd AS ProdutoIdProd,
            p.IdProd,
            p.NomeProd,
            p.PrecoProd,
            p.DescProd,
            p.ImgUrl -- Incluído aqui
        FROM Carrinho c
        LEFT JOIN ProdutoCarrinho pc ON c.IdCarrinho = pc.IdCarrinho
        LEFT JOIN Produto p ON pc.IdProd = p.IdProd
        WHERE c.CpfComp = @CpfComp";

            var carrinho = new Dictionary<int, Carrinho>();

            await _dbConnection.QueryAsync<Carrinho, ProdutoCarrinho, Produto, Carrinho>(
                query,
                (carrinhoRow, produtoCarrinhoRow, produtoRow) =>
                {
                    if (!carrinho.TryGetValue(carrinhoRow.IdCarrinho, out var carrinhoAtual))
                    {
                        carrinhoAtual = carrinhoRow;
                        carrinho[carrinhoRow.IdCarrinho] = carrinhoAtual;
                    }

                    if (produtoCarrinhoRow != null)
                    {
                        produtoCarrinhoRow.IdProd = produtoRow.IdProd;
                        if (produtoRow != null)
                        {
                            produtoCarrinhoRow.Produto = produtoRow;
                        }
                        carrinhoAtual.Produtos.Add(produtoCarrinhoRow);
                    }

                    return carrinhoAtual;
                },
                new { CpfComp = cpfComp },
                splitOn: "ProdutoCarrinhoIdCarrinho,ProdutoIdProd"
            );

            return carrinho.Values.FirstOrDefault();
        }

    }
}
