using SimpleStore.Web.Models;
using SimpleStore.Web.Repositories;

namespace SimpleStore.Web.Services
{
    public class CarrinhoService
    {
        private readonly CarrinhoRepository _carrinhoRepository;

        public CarrinhoService(CarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        // Obter o carrinho específico de um comprador
        public Carrinho ObterCarrinho(string cpfComprador)
        {
            
            if (string.IsNullOrEmpty(cpfComprador))
            {
                throw new ArgumentException("CPF do comprador é obrigatório", nameof(cpfComprador));
            }
            var carrinho = _carrinhoRepository.ObterCarrinho(cpfComprador);

            if (carrinho == null)
            {
                carrinho = _carrinhoRepository.CriarCarrinho(cpfComprador);
            }

            return carrinho;
        }

        // Adicionar produto ao carrinho
        public void AdicionarProduto(string cpfComprador, int idProduto, int quantidade)
        {
            var carrinho = ObterCarrinho(cpfComprador);

            var produtoCarrinho = carrinho.Produtos.FirstOrDefault(p => p.IdProd == idProduto);

            if (produtoCarrinho != null)
            {
                produtoCarrinho.QuantProdCarrinho += quantidade;
            }
            else
            {
                produtoCarrinho = new ProdutoCarrinho
                {
                    IdCarrinho = carrinho.IdCarrinho,
                    IdProd = idProduto,
                    QuantProdCarrinho = quantidade
                };
                carrinho.Produtos.Add(produtoCarrinho);
            }

            AtualizarValorTotal(carrinho);
            _carrinhoRepository.SalvarCarrinho(carrinho);
        }

        // Remover produto do carrinho
        public void RemoverProduto(string cpfComprador, int idProduto)
        {
            var carrinho = ObterCarrinho(cpfComprador);
            var produtoCarrinho = carrinho.Produtos.FirstOrDefault(p => p.IdProd == idProduto);

            if (produtoCarrinho != null)
            {
                carrinho.Produtos.Remove(produtoCarrinho);
                AtualizarValorTotal(carrinho);
                _carrinhoRepository.SalvarCarrinho(carrinho);
            }
        }

        // Atualizar quantidade de um produto no carrinho
        public void AtualizarQuantidade(string cpfComprador, int idProduto, int quantidade)
        {
            var carrinho = ObterCarrinho(cpfComprador);
            var produtoCarrinho = carrinho.Produtos.FirstOrDefault(p => p.IdProd == idProduto);

            if (produtoCarrinho != null)
            {
                produtoCarrinho.QuantProdCarrinho = quantidade;
                AtualizarValorTotal(carrinho);
                _carrinhoRepository.SalvarCarrinho(carrinho);
            }
        }

        // Atualizar o valor total do carrinho
        private void AtualizarValorTotal(Carrinho carrinho)
        {
            carrinho.ValorTotalCarrinho = carrinho.Produtos.Sum(p => p.QuantProdCarrinho * p.Produto.PrecoProd);
        }
    }
}
