using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Produto
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Id_Forn")]
        public int IdForn { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome do produto.")]
        public string Nome_prod { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a descrição do produto.")]
        public string Desc_Prod { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a quantidade disponível do produto.")]
        public int Quant_Prod { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o preço do produto.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a categoria do produto.")]
        public string Categ_Prod { get; set; }

        [Required(ErrorMessage = "Obrigatório enviar uma imagem do produto.")]
        public string Img_Prod { get; set; }  // Caminho ou URL da imagem
    }
}
