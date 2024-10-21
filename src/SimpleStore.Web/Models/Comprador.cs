using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class Comprador
    {
        [KeyAttribute]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="Obrigatório inserir o nome.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir o e-mail.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório inserir a senha.")]
        public string Senha { get; set; }

    }
}
