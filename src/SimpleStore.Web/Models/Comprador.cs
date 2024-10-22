using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Comprador
    {
        [KeyAttribute]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CpfComp { get; set; }

        [Required(ErrorMessage ="Obrigatório inserir o nome.")]
        public string NomeComp { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailComp { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a senha.")]
        public string SenhaComp { get; set; }

    }
}
