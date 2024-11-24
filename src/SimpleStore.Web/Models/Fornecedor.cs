using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Fornecedor 
    {
        [Key]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        [StringLength(18, MinimumLength = 18, ErrorMessage = "O documento deve ter 18 caracteres.")]
        public string DocForn { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string EmailForn { get; set; }

        [Required(ErrorMessage = "Senha obrigatória.")]
        public string SenhaForn { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirme a senha.")]
        [Compare("SenhaForn", ErrorMessage = "Senhas não coincidem.")]
        public string ConfirmarSenhaForn { get; set; }

        [Required(ErrorMessage = "Link do Whatsapp obrigatório para contato.")]
        public string LinkZapForn { get; set; }

        [Required(ErrorMessage = "Razão social obrigatória.")]
        public string RazaoSocialForn { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório.")]
        [Display(Name = "Telefone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(\d{2}\) (\d \d{4}|\d{4})-\d{4}$", ErrorMessage = "Telefone inválido.")]
        public string FoneForn { get; set; }

        public string LogradouroForn { get; set; }

        public int NumeroForn { get; set; }

        public string BairroForn { get; set; }

        public string CidadeForn { get; set; }

        public string EstadoForn { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato 99999-999.")]
        public string CepForn { get; set; }
    }

}
