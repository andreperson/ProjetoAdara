using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("talao")]
    public class Talao
    {
        public Int16 talaoid { get; set; }

        public Int16 representanteid { get; set; }
        [ForeignKey("representanteid")]
        public virtual Representante Representante { get; set; }
        
        public string descricao { get; set; }
        public Int32 ini { get; set; }
        public Int32 fin { get; set; }
        public string Obs { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
