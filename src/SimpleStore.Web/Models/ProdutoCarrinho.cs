using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class ProdutoCarrinho
    {
        [ForeignKey("Carrinho")]   
        public int IdCarrinho { get; set; }

        [ForeignKey("Produto")]
        public int IdProduto { get; set; }

        public int QuantProdCarrinho { get; set; }

    }
}
