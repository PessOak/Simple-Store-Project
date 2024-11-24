using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Perfil
    {
        [Key]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CpfComp { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        public string NomeComp { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailComp { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha obrigatório.")]
        public string SenhaComp { get; set; }

        [Required]
        [Compare("SenhaComp", ErrorMessage = "Senhas não coincidem.")]
        public string ConfirmarSenhaComp { get; set; }
    }
}