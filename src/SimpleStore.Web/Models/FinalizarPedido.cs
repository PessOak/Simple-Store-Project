using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class FinalizarPedido
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string NomeCliente { get; set; }

        [Required(ErrorMessage = "O endereço de entrega é obrigatório.")]
        [StringLength(200, ErrorMessage = "O endereço não pode exceder 200 caracteres.")]
        public string EnderecoEntrega { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        public string FormaPagamento { get; set; }

        public DateTime DataPedido { get; set; } = DateTime.Now;

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor total deve ser maior que zero.")]
        public float ValorTotalPedido { get; set; }
    }
}
