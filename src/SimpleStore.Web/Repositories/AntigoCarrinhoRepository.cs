//using Microsoft.EntityFrameworkCore;
//using SimpleStore.Web.Data;
//using SimpleStore.Web.Models;
//using SimpleStore.Web.Data;


//namespace SimpleStore.Web.Repositories
//{
//    public class CarrinhoRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public CarrinhoRepository(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // Método para obter o carrinho e seus produtos para um comprador específico
//        public Carrinho ObterCarrinho(string cpfComprador)
//        {
//            return _context.Carrinho
//                .Include(c => c.Produto)          // Carrega a lista de produtos no carrinho
//                .ThenInclude(pc => pc.Produto)     // Carrega os detalhes de cada produto
//                .FirstOrDefault(c => c.CpfComp == cpfComprador);
//        }

//        // Método para salvar as alterações no carrinho
//        public void SalvarCarrinho(Carrinho carrinho)
//        {
//            _context.Carrinho.Update(carrinho);
//            _context.SaveChanges();
//        }

//        // Método para criar um novo carrinho caso o comprador ainda não tenha um
//        public Carrinho CriarCarrinho(string cpfComprador)
//        {
//            var novoCarrinho = new Carrinho
//            {
//                CpfComp = cpfComprador,
//                ValorTotalCarrinho = 0
//            };

//            _context.Carrinho.Add(novoCarrinho);
//            _context.SaveChanges();

//            return novoCarrinho;
//        }
//    }
//}
