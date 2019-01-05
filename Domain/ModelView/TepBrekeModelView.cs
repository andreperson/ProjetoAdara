using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Domain.Entities;

namespace Domain.ModelView
{
    public class TepBrekeModelView
    {
        public int tepbrekeid { get; set; }

        [Required(ErrorMessage = "Tep")]
        [Display(Name = "Tep")]
        public int tepid { get; set; }

        [Required(ErrorMessage = "Brekedown")]
        [Display(Name = "Brekedown")]
        public int Brekedownid { get; set; }

        public DateTime? dataincl { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<TepBreke> TepBrekes { get; set; }
        public List<Brekedown> Brekedowns { get; set; }
        public List<Atividade> Atividades { get; set; }
        public List<Tep> Teps { get; set; }
        public List<BrekeAtvModelView> BrekeAtvs { get; set; }
    }
}
