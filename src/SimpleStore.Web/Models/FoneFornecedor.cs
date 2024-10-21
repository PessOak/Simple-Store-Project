using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class FoneFornecedor
    {
        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Fone { get; set; }
    }
}
