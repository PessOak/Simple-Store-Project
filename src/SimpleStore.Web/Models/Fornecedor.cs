using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "CNPJ obrigatório")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O documento deve ter 14 caracteres.")]
        public string DocForn { get; set; }

        [Required(ErrorMessage = "Nome obrigatório.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "E-mail obrigatório.")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido")]
        public string EmailForn { get; set; }

        [Required(ErrorMessage = "Senha obrigatória.")]
        public string SenhaForn { get; set; }

        [Required(ErrorMessage = "Link do Whatsapp obrigatório para contato.")]
        public string LinkZapForn { get; set; }

        [Required(ErrorMessage = "Razão social obrigatória.")]
        public string RazaoSocialForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o telefone.")]
        [Phone(ErrorMessage = "Número de telefone inválido.")]
        public string FoneForn { get; set; }

        public string LogradouroForn { get; set; }

        public int NumeroForn { get; set; }

        public string BairroForn { get; set; }

        public string CidadeForn { get; set; }

        public string EstadoForn { get; set; }

        public string CepForn { get; set; }
    }

}
