using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class RecursoModelView
    {
        public int recursoid { get; set; }
        [Display(Name = "Recurso")]
        public int userid { get; set; }
        public int competenciaid { get; set; }

        [Display(Name = "Recurso")]
        public string Recurso { get; set; }

        [Display(Name = "Obs")]
        public int menuid { get; set; }
        public int menusubid { get; set; }
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
