using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class UsuarioTipoModelView
    {
        public Int16 usuariotipoid { get; set; }

        [Required(ErrorMessage = "Descricao")]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        [Display(Name = "Ativo")]
        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }
        public int menuid { get; set; }
        public int menusubid { get; set; }

        public List<UsuarioTipo> UsuarioTipos { get; set; }
    }
}
