using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Fornecedor
    {
        [Key]
        public int IdForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o documento.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O documento deve ter 14 caracteres.")]
        public string DocForn { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome.")]
        public string NomeForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string EmailForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha.")]
        public string SenhaForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o link do Whatsapp para contato.")]
        public string LinkZapForn { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a razão social.")]
        public string RazaoSocialForn { get; set; }
    }

}
