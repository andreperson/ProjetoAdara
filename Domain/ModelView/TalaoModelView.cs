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
    public class TalaoModelView
    {
        public Int16 talaoid { get; set; }

        [Required(ErrorMessage = "Informe o Representante")]
        [Display(Name = "Representante")]
        public Int16 representanteid { get; set; }

        [Display(Name = "Obs")]
        public string obs { get; set; }

        [Required(ErrorMessage = "Informe o Número Inicial")]
        [Display(Name = "Número Inicial")]
        public Int32 ini { get; set; }

        [Required(ErrorMessage = "Informe o Número Final")]
        [Display(Name = "Número Final")]
        public Int32 fin { get; set; }

        public string descricao { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string user { get; set; }

        public List<Talao> Taloes { get; set; }
        public List<Representante> Representantes { get; set; }
    }
}
