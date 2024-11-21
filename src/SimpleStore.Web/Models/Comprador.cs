using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Comprador
    {
        [Key]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CpfComp { get; set; }

        [Required(ErrorMessage ="Obrigatório inserir o nome.")]
        public string NomeComp { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailComp { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Obrigatório inserir a senha.")]
        public string SenhaComp { get; set; }

        [Required]
        [Compare("SenhaComp", ErrorMessage = "As senhas não se coincidem.")]
        public string ConfirmarSenhaComp { get; set; }



    }
}
