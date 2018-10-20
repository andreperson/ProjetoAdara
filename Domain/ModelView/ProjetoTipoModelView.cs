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
    public class ProjetoTipoModelView
    {
        public Int16 Projetotipoid { get; set; }

        [Required(ErrorMessage = "Descricao")]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<ProjetoTipo> ProjetosTipos { get; set; }
    }
}
