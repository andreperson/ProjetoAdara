using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("tep")]
    public class Tep
    {
        [Key]
        public int Tepid { get; set; }
        public string descricao { get; set; }
        public int Status { get; set; }
        public DateTime? Dataincl { get; set; }
        public string User { get; set; }
    }
}
