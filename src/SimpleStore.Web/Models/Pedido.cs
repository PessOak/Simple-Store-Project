using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Pedido
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Carrinho")]
        public int Id_Carrinho { get; set; }

        public DateTime Data { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser positivo.")]
        public decimal Valor_Total { get; set; }

    }
}
