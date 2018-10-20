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
    public class RecursoModelView
    {
        public Int16 recursoid { get; set; }
        [Display(Name = "Recurso")]
        public Int16 userid { get; set; }
        public Int16 competenciaid { get; set; }

        [Display(Name = "Obs")]
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string useralt { get; set; }

        public List<User> Usuarios { get; set; }
        public List<Recurso> Recursos { get; set; }
        public List<Competencia> Competencias { get; set; }

    }
}
