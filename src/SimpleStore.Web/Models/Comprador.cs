using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Comprador
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
        [Required(ErrorMessage = "Senha obrigatória.")]
        public string SenhaComp { get; set; }

        [Required(ErrorMessage = "Confirme a senha.")]
        [Compare("SenhaComp", ErrorMessage = "Senhas não coincidem.")]
        public string ConfirmarSenhaComp { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório.")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Telefone inválido.")]
        public string FoneComp { get; set; }

        public string LogradouroComp { get; set; }

        public int NumeroComp { get; set; }

        public string BairroComp { get; set; }

        public string CidadeComp { get; set; }

        public string EstadoComp { get; set; }

        public string CepComp { get; set; }

    }
}
