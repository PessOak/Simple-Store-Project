using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Comprador 
    {
        [Key]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CPF deve ter 14 caracteres.")]
        public string CpfComp { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        public string NomeComp { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailComp { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha obrigatória.")]
        public string SenhaComp { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirme a senha.")]
        [Compare("SenhaComp", ErrorMessage = "Senhas não coincidem.")]
        public string ConfirmarSenhaComp { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório.")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{2}\) (\d \d{4}|\d{4})-\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string FoneComp { get; set; }

        public string LogradouroComp { get; set; }

        public int NumeroComp { get; set; }

        public string BairroComp { get; set; }

        public string CidadeComp { get; set; }

        public string EstadoComp { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 99999-999.")]
        public string CepComp { get; set; }

    }
}
