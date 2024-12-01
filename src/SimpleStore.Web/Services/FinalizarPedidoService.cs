using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleStore.Web.Services
{
    public class FinalizarPedidoService
    {
        private readonly FinalizarPedidoRepository _repository;

        public FinalizarPedidoService(FinalizarPedidoRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Obtém os dados iniciais para a página de finalização do pedido.
        /// </summary>
        /// <param name="idCarrinho">ID do carrinho associado.</param>
        /// <returns>Objeto do tipo Pedido com os dados preenchidos.</returns>
        public async Task<Pedido> ObterDadosParaFinalizacaoAsync(int idCarrinho)
        {
            // Busca os detalhes do carrinho
            var detalhes = await _repository.ObterDetalhesCarrinhoAsync(idCarrinho);

            // Calcula o valor total do pedido a partir dos produtos
            var valorTotal = detalhes.FirstOrDefault()?.ValorTotalPedido ?? 0;

            var pedido = new Pedido
            {
                IdCarrinho = idCarrinho,
                DataPedido = DateTime.Now,
                ValorTotalPedido = valorTotal
            };

            return pedido;
        }

        /// <summary>
        /// Obtém os detalhes do pedido para exibição na página FinalizarPedido.
        /// </summary>
        /// <param name="idCarrinho">ID do carrinho.</param>
        /// <returns>Lista de produtos e o valor total do pedido.</returns>
        public async Task<(IEnumerable<dynamic> Produtos, float TotalPedido)> ObterDetalhesPedidoAsync(int idCarrinho)
        {
            // Busca os detalhes do carrinho
            var detalhes = await _repository.ObterDetalhesCarrinhoAsync(idCarrinho);

            // Mapeia os detalhes dos produtos
            var produtos = detalhes.Select(d => new
            {
                Imagem = d.ImagemProduto,
                Nome = d.NomeProduto,
                Quantidade = d.Quantidade,
                PrecoTotal = d.PrecoTotalProduto,
                LinkFornecedor = d.LinkContatoFornecedor
            });

            // Extrai o valor total do pedido
            var totalPedido = detalhes.FirstOrDefault()?.ValorTotalPedido ?? 0;

            return (produtos, totalPedido);
        }

        /// <summary>
        /// Finaliza o pedido e armazena os dados.
        /// </summary>
        /// <param name="pedido">Objeto contendo os dados do pedido.</param>
        public async Task FinalizarPedidoAsync(Pedido pedido)
        {
            if (pedido == null)
            {
                throw new ArgumentNullException(nameof(pedido), "Pedido não pode ser nulo.");
            }

            // Salva o pedido no banco de dados
            await _repository.SalvarPedidoAsync(pedido);
        }
    }
}
