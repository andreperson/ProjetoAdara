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
    public class CompetenciaUsuarioModelView
    {
        public Int16 competenciauserid { get; set; }
        public Int16 competenciaid { get; set; }
        public Int16 userid { get; set; }

        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string useralt { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public List<User> Users { get; set; }
        public List<Competencia> Competencias { get; set; }

        public List<CompetenciaUser> Competencias_Usuarios { get; set; }

    }
}
