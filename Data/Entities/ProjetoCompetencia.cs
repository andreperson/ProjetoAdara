using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("projetocompetencia")]
    public class ProjetoCompetencia
    {
        [Key]
        public int projetocompetenciaid { get; set; }

        public Int16 projetoid { get; set; }
        [ForeignKey("projetoid")]
        public virtual Projeto Projeto { get; set; }
        public int competenciaid { get; set; }
        [ForeignKey("competenciaid")]
        public virtual Competencia Competencia { get; set; }

        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
