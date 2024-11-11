using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class LoginFornecedor
    {
        [Required(ErrorMessage = "Obrigatório inserir o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a senha.")]
        public string Senha { get; set; }
    }
}
