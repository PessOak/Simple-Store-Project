using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Pedido
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Carrinho")]
        public int IdCarrinho { get; set; }

        public DateTime Data { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser positivo.")]
        public decimal ValorTotal { get; set; }

    }
}
