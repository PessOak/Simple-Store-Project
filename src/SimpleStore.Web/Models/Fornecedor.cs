using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Fornecedor
    {
        [KeyAttribute]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o documento.")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "O documento deve ter entre 11 (cpf) e 14 (cnpj) caracteres.")]
        public string Doc { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar a senha.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o link do Whatsapp para contato.")]
        public string LinkZap { get; set; }
    }

}
