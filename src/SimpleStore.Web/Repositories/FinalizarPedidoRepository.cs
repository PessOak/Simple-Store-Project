using Dapper;
using SimpleStore.Web.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace SimpleStore.Web.Repositories
{
    public class FinalizarPedidoRepository
    {
        private readonly IDbConnection _dbConnection;

        public FinalizarPedidoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        /// <summary>
        /// Salva um pedido no banco de dados.
        /// </summary>
        /// <param name="pedido">Objeto contendo os dados do pedido.</param>
        public async Task SalvarPedidoAsync(Pedido pedido)
        {
            try
            {
                var query = @"
                    INSERT INTO Pedido (IdCarrinho, DataPedido, ValorTotalPedido)
                    VALUES (@IdCarrinho, @DataPedido, @ValorTotalPedido);
                ";

                await _dbConnection.ExecuteAsync(query, new
                {
                    IdCarrinho = pedido.IdCarrinho,
                    DataPedido = pedido.DataPedido,
                    ValorTotalPedido = pedido.ValorTotalPedido
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o pedido no banco de dados.", ex);
            }
        }

        /// <summary>
        /// Busca um pedido pelo ID.
        /// </summary>
        /// <param name="idPedido">ID do pedido.</param>
        /// <returns>Objeto Pedido ou nulo se não encontrado.</returns>
        public async Task<Pedido> ObterPedidoPorIdAsync(int idPedido)
        {
            try
            {
                var query = "SELECT * FROM Pedido WHERE IdPedido = @IdPedido";

                return await _dbConnection.QuerySingleOrDefaultAsync<Pedido>(query, new { IdPedido = idPedido });
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar o pedido de ID {idPedido}.", ex);
            }
        }

        /// <summary>
        /// Busca os detalhes do carrinho, produtos e fornecedores para a página FinalizarPedido.
        /// </summary>
        /// <param name="idCarrinho">ID do carrinho.</param>
        /// <returns>Lista de produtos e detalhes do carrinho.</returns>
        public async Task<IEnumerable<dynamic>> ObterDetalhesCarrinhoAsync(int idCarrinho)
        {
            try
            {
                var query = @"
                    SELECT 
                        p.Img_Prod AS ImagemProduto,
                        p.Nome_Prod AS NomeProduto,
                        c.Itens_Carrinho AS Quantidade,
                        (p.Preço_Prod * c.Itens_Carrinho) AS PrecoTotalProduto,
                        f.LinkZap_Form AS LinkContatoFornecedor,
                        carr.Total_Carrinho AS ValorTotalPedido
                    FROM 
                        Carrinho carr
                    JOIN 
                        Produto p ON carr.ID_Produto = p.ID_Prod
                    JOIN 
                        Fornecedor f ON p.ID_Form = f.ID_Form
                    WHERE 
                        carr.ID_Carrinho = @IdCarrinho;
                ";

                return await _dbConnection.QueryAsync<dynamic>(query, new { IdCarrinho = idCarrinho });
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao buscar os detalhes do carrinho.", ex);
            }
        }
    }
}
