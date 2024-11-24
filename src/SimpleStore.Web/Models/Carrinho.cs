using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Carrinho
    {
        [Key]
        public int IdCarrinho { get; set; }

        [ForeignKey("Comprador")]
        public string CpfComp { get; set; }

        public float ValorTotalCarrinho { get; set; }

        // Propriedade para armazenar os produtos no carrinho
        public ICollection<ProdutoCarrinho> Produto { get; set; } = new List<ProdutoCarrinho>();
    }
}
