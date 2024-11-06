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
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); // Lista inicializada, nesse caso está usando o entity
    }
}
