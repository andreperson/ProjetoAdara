using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("moeda")]
    public class Moeda
    {
        [Key]
        public int moedaid { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
