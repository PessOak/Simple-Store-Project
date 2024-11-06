using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleStore.Web.Models
{
    public class EnderecoComprador
    {

        [Key]
        public int IdEndereco { get; set; }

        [ForeignKey("Comprador")]
        public string CpfComp { get; set; }

        public string LogradouroEndereco { get; set; }

        public int NumeroEndereco { get; set; }

        public string BairroEndereco { get; set; }

        public string CidadeEndereco { get; set; }

        public string EstadoEndereco { get; set; }

        public string CepEndereco { get; set; }
    }
}
