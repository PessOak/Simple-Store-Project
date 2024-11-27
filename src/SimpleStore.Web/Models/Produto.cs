using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Produto
    {
        [Key]
        public int IdProd { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome do produto.")]
        public string NomeProd { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição do produto.")]
        public string DescProd { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade disponível do produto.")]
        public int QuantProd { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço do produto.")]
        public float PrecoProd { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria do produto.")]
        public string CategProd { get; set; }

        public byte[] ImgUrl { get; set; }

        [NotMapped]
        public IFormFile ImagemProduto { get; set; } // Recebe o arquivo enviado pelo formulário
    }
}
