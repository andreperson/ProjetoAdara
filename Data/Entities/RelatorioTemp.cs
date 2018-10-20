using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("relatoriotemp")]
    public class RelatorioTemp
    {
        public Int16 relatoriotempid { get; set; }

        public Int16 representanteid { get; set; }
        [ForeignKey("representanteid")]
        public virtual Representante Representante { get; set; }

        public Int16 boletoid { get; set; }
        [ForeignKey("boletoid")]
        public virtual Boleto Boleto { get; set; }

        public DateTime DtVencimento { get; set; }

        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
