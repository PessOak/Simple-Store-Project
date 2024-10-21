using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Carrinho
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Comprador")]
        public string Cpf_Comp { get; set; }

        public decimal ValorTotal_Carrinho { get; set; }

        // Propriedade para armazenar os produtos no carrinho
        public ICollection<Produto> Produtos { get; set; } = new List<Produto>(); // Lista inicializada
    }
}
