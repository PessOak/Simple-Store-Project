using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class Administrador
    {
        [KeyAttribute]
        public int Id { get; set; }

        [Required(ErrorMessage ="Obrigatório informar o nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o nome")]
        public string Senha { get; set; }

    }
}
