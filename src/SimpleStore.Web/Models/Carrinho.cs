using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Carrinho
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Comprador")]
        public string CpfComprador { get; set; }

        public decimal ValorTotal { get; set; }

        // Propriedade para armazenar os produtos no carrinho
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); // Lista inicializada
    }
}
