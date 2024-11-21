using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "O CNPJ é obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O documento deve ter 14 caracteres.")]
        public string DocForn { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string EmailForn { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string SenhaForn { get; set; }

        [Required(ErrorMessage = "O link do Whatsapp é obrigatório para contato.")]
        public string LinkZapForn { get; set; }

        [Required(ErrorMessage = "A razão social é obrigatória.")]
        public string RazaoSocialForn { get; set; }
    }

}
