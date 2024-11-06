using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    [PrimaryKey(nameof(IdCarrinho), nameof(IdProd))]
    public class ProdutoCarrinho
    {
        [ForeignKey("Carrinho")]   
        public int IdCarrinho { get; set; }

        [ForeignKey("Produto")]
        public int IdProd { get; set; }

        public int QuantProdCarrinho { get; set; }

    }
}
