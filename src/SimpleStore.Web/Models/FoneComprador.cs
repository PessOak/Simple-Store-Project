using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class FoneComprador
    {
        [ForeignKey("Comprador")]
        public string CpfComprador { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string Fone { get; set; }
    }
}
