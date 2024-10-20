using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Id_Forn")]
        public int IdForn { get; set; }

        public string Nome_prod { get; set; }

        public string Desc_Prod { get; set; }

        public int Quant_Prod { get; set; }

        public decimal Preco { get; set; }

        public string Categ_Prod { get; set; }

        public string Img_Prod { get; set; }  // Caminho ou URL da imagem
    }
}
