using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class FoneComprador
    {
        [ForeignKey("Comprador")]
        public string CpfComp { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string FoneComp { get; set; }
    }
}
