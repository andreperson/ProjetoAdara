using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("talaoitens")]
    public class TalaoItens
    {
        public Int16 talaoitensid { get; set; }

        public Int16 talaoitensstatusid { get; set; }
        [ForeignKey("talaoitensstatusid")]
        public virtual TalaoItensStatus talaoItensStatus { get; set; }
        
        public Int16 talaoid { get; set; }
        [ForeignKey("talaoid")]
        public virtual Talao talao { get; set; }

        public Int16 representanteid { get; set; }
        [ForeignKey("representanteid")]
        public virtual Representante Representante { get; set; }

        public Int32 Numero { get; set; }
        public string Obs { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
