using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("relatorio")]
    public class Relatorio
    {
        public Int16 relatorioid { get; set; }

        public Int16 representanteid { get; set; }
        [ForeignKey("representanteid")]
        public virtual Representante Representante { get; set; }

        public Int16 boletoid { get; set; }
        [ForeignKey("boletoid")]
        public virtual Boleto Boleto { get; set; }
        
        public Int16 fabricaid { get; set; }
        [ForeignKey("fabricaid")]
        public virtual Fabrica Fabrica { get; set; }

        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }

        public Int16 assessorid { get; set; }
        [ForeignKey("assessorid")]
        public virtual Assessor Assessor { get; set; }

        public Int16 talaoitensid { get; set; }
        [ForeignKey("talaoitensid")]
        public virtual TalaoItens TalaoItens { get; set; }

        public int relatoriostatusid { get; set; }
        [ForeignKey("relatoriostatusid")]
        public virtual RelatorioStatus RelatorioStatus { get; set; }

        public double ValorTotal { get; set; }
        public double ValorComissao { get; set; }
        public double ValorPago { get; set; }

        public DateTime dataRecebto { get; set; }
        public DateTime datapagto { get; set; }

        public string Obs { get; set; }

        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
