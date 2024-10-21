using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Produto
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdForn { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome do produto.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição do produto.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade disponível do produto.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço do produto.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria do produto.")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "Obrigatório enviar uma imagem do produto.")]
        public string ImgUrl { get; set; }  // Caminho ou URL da imagem
    }
}
