using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("tepatv")]
    public class TepAtv
    {
        [Key]
        public int tepatvid { get; set; }
        
        public int tepid { get; set; }
        [ForeignKey("tepid")]
        public virtual Tep Tep { get; set; }
        
        public int atividadeid { get; set; }
        [ForeignKey("atividadeid")]
        public virtual Atividade Atividade { get; set; }

        public DateTime? Dataincl { get; set; }
        public string User { get; set; }
    }
}
