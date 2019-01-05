using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("tepbreke")]
    public class TepBreke
    {
        [Key]
        public int tepbrekeid { get; set; }
        
        public int tepid { get; set; }
        [ForeignKey("tepid")]
        public virtual Tep Tep { get; set; }
        
        public int brekedownid { get; set; }
        [ForeignKey("brekedownid")]
        public virtual Brekedown Brekedown { get; set; }

        public DateTime? Dataincl { get; set; }
        public string User { get; set; }
    }
}
