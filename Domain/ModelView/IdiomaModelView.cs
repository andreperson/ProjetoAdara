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
    public class IdiomaModelView
    {
        public Int16 idiomaid { get; set; }

        [Required(ErrorMessage = "Descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Sigla")]
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<Idioma> Idiomas { get; set; }

    }
}
