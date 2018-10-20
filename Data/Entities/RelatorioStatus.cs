using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("relatoriostatus")]
    public class RelatorioStatus
    {
        public int relatoriostatusid { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string user { get; set; }
    }
}
