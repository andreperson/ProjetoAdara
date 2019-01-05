using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("clientepreco")]
    public class ClientePreco
    {
        [Key]
        public int clienteprecoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }
        public int paridiomaid { get; set; }
        [ForeignKey("paridiomaid")]
        public virtual ParIdioma ParIdioma { get; set; }
        public int moedaid { get; set; }
        [ForeignKey("moedaid")]
        public virtual Moeda Moeda { get; set; }
        public int competenciaid { get; set; }
        [ForeignKey("competenciaid")]
        public virtual Competencia Competencia { get; set; }
        public double PrecoPalavra { get; set; }
        public double PrecoLinha { get; set; }
        public double PrecoHora { get; set; }
        public double PrecoMinimo { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
