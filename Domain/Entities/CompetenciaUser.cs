using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("competenciauser")]
    public class CompetenciaUser
    {
        [Key]
        public int competenciauserid { get; set; }

        public int competenciaid { get; set; }
        [ForeignKey("competenciaid")]
        public virtual Competencia Competencia { get; set; }

        public int userid { get; set; }
        [ForeignKey("userid")]
        public virtual User User { get; set; }
 
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string useralt { get; set; }
    }
}
