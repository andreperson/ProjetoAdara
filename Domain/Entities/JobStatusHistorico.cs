using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("jobstatushistorico")]
    public class JobStatusHistorico
    {
        [Key]
        public int jobstatushistoricoid { get; set; }

        public Int16 jobid { get; set; }
        [ForeignKey("jobid")]
        public virtual Job Jobs { get; set; }

        public int jobstatusid { get; set; }
        [ForeignKey("jobstatusid")]
        public virtual JobStatus JobStatus { get; set; }
        
        public DateTime? Dataincl { get; set; }
        public string User { get; set; }
    }
}
