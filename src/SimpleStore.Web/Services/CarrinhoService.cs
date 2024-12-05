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

        public async Task<Carrinho> ObterCarrinhoOuCriarAsync(string cpfComp)
        {
            // Tenta obter o carrinho do usuário
            var carrinho = await _carrinhoRepository.ObterCarrinhoPorCpfAsync(cpfComp);

            // Se o carrinho não existir, cria um novo
            if (carrinho == null)
            {
                carrinho = new Carrinho
                {
                    CpfComp = cpfComp,
                    Produtos = new List<ProdutoCarrinho>()
                };

                // Cria o novo carrinho no banco de dados
                await _carrinhoRepository.CriarCarrinhoAsync(carrinho);
            }

            return carrinho;
        }
    }
}
