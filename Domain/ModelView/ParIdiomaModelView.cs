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
    public class ParIdiomaModelView
    {
        public int paridiomaid { get; set; }
        public int idiomaid { get; set; }

        [Required(ErrorMessage = "Idioma De")]
        [Display(Name = "Idioma De")]
        public int idiomaidfrom { get; set; }

        [Required(ErrorMessage = "Idioma Para")]
        [Display(Name = "Idioma Para")]
        public int idiomaidto { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public string Descricaode { get; set; }
        public string Descricaopara { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
        public int status { get; set; }
        public bool statusb { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public List<Idioma> Idiomas { get; set; }
        public List<ParIdioma> ParIdiomas { get; set; }
    }
}
