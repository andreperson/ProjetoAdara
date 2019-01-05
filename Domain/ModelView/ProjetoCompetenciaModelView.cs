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
    public class ProjetoCompetenciaModelView
    {
        public int projetocompetenciaid { get; set; }

        public Int16 projetoid { get; set; }

        public int competenciaid { get; set; }

        [Required(ErrorMessage = "Competência")]
        [Display(Name = "Competência")]

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<ProjetoCompetencia> ProjetosCompetencias { get; set; }
        public List<Competencia> Competencias { get; set; }
        public List<Projeto> Projetos { get; set; }
    }
}
