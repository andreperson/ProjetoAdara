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
    public class TalaoItensModelView
    {
        public Int16 talaoitensid { get; set; }
        public Int16 talaoid { get; set; }
        public Int16 talaoitensstatusid { get; set; }

        [Required(ErrorMessage = "Representante")]
        [Display(Name = "Representante")]
        public Int16 representanteid { get; set; }

        [Display(Name = "Número")]
        public Int32 numero { get; set; }

        [Display(Name = "Obs")]
        public string obs { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string user { get; set; }

        public List<Talao> Taloes { get; set; }
        public List<TalaoItens> TaloesItens { get; set; }
        public List<TalaoItensStatus> TaloesItensStatus { get; set; }
        public List<Representante> Representantes { get; set; }
    }
}
