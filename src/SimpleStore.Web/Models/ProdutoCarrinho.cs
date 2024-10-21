using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class ProdutoCarrinho
    {
        [ForeignKey("Carrinho")]   
        public int Id_Carrinho { get; set; }

        [ForeignKey("Produto")]
        public int Id_Prod { get; set; }

        public int QuantProd_Carrinho { get; set; }

    }
}
