using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SimpleStore.Web.Models
{
    public class EnderecoFornecedor
    {
        [KeyAttribute]
        public int IdEndereco { get; set; }

        [ForeignKey("Fornecedor")]
        public int IdForn { get; set; }

        public string LogradouroEndereco { get; set; }

        public int NumeroEndereco { get; set; }

        public string BairroEndereco { get; set; }

        public string CidadeEndereco { get; set; }

        public string EstadoEndereco { get; set; }

        public string CepEndereco { get; set; }

        public string ComplementoEndereco { get; set; }
    }
}
