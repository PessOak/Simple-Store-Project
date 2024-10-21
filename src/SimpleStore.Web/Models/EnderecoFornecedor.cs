using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class EnderecoFornecedor
    {
        [KeyAttribute]
        public int Id { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdFornecedor { get; set; }

        public string Logradouro { get; set; }

        public int Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Cep { get; set; }

        public string Complemento { get; set; }
    }
}
