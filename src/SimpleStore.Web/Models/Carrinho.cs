using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace SimpleStore.Web.Models
{
    public class Carrinho
    {
        [Key]
        public int IdCarrinho { get; set; }

        [ForeignKey("Comprador")]
        public string CpfComp { get; set; }

        // Propriedade que armazenará o valor total calculado
        public decimal ValorTotalCarrinho
        {
            get
            {
                // Garantir que o resultado seja um decimal
                return Produtos.Sum(p => (decimal)(p.QuantProdCarrinho * p.Produto.PrecoProd));
            }
        }

        // Propriedade para armazenar os produtos no carrinho
        public ICollection<ProdutoCarrinho> Produtos { get; set; } = new List<ProdutoCarrinho>();

        // A propriedade de navegação não precisa ser duplicada, então a lista adicional foi removida

        public Comprador comprador { get; set; }
    }
}
