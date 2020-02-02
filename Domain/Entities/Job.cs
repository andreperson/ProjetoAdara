using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("job")]
    public class Job
    {
        [Key]
        public Int16 jobid { get; set; }

        public Int16 projetoid { get; set; }
        [ForeignKey("projetoid")]
        public virtual Projeto Projeto { get; set; }

        public Int16 userid { get; set; }
        [ForeignKey("userid")]
        public virtual User Usuario { get; set; }

        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }

        public Int16 fuzzieid { get; set; }
        [ForeignKey("fuzzieid")]
        public virtual Fuzzie Fuzzie { get; set; }

        public int jobstatusid { get; set; }
        [ForeignKey("jobstatusid")]
        public virtual JobStatus JobStatus { get; set; }

        public int qtdepalavrajob { get; set; }
        public int idiomaidfrom { get; set; }
        public int idiomaidto { get; set; }

        public double valorporpalavrajob { get; set; }
        public DateTime? dataprazo{ get; set; }
        public DateTime? dataentrega { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
