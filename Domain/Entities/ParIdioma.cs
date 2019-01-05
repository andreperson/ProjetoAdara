using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("paridioma")]
    public class ParIdioma
    {
        [Key]
        public int paridiomaid { get; set; }
        public int idiomaid { get; set; }
        [ForeignKey("idiomaid")]
        public virtual Idioma Idioma { get; set; }
        public int Idiomaidfrom { get; set; }
        public int Idiomaidto { get; set; }
        public string Descricao { get; set; }
        public string Descricaode { get; set; }
        public string Descricaopara { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
