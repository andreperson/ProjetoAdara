using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("usuariomenu")]
    public class UsuarioMenu
    {
        [Key]
        public int usuariomenuid { get; set; }

        public int usuariotipoid { get; set; }
        [ForeignKey("usuariotipoid")]
        public virtual UsuarioTipo UsuarioTipo { get; set; }

        public int menuid { get; set; }
        [ForeignKey("menuid")]
        public virtual Menu Menu { get; set; }

        public int status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string user { get; set; }
    }
}
