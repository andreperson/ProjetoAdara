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
    public class JobModelView
    {
        public Int16 jobid { get; set; }
        public Int16 projetoid { get; set; }
        public Int16 userid { get; set; }
        public Int16 clienteid { get; set; }
        public Int16 clienteprecoprojetoid { get; set; }
        public Int16 fuzzieid { get; set; }
        public int idiomaidfrom { get; set; }
        public int idiomaidto { get; set; }
        public int qtdepalavrajob { get; set; }
        public double valorporpalavrajob { get; set; }
        public DateTime? dataprazo { get; set; }
        public DateTime? dataentrega { get; set; }
        [Required(ErrorMessage = "Descricao")]
        [Display(Name = "Descricao")]
        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }


        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<Job> Jobs { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Recurso> Recursos { get; set; }
        public List<ClientePrecoProjeto> ClientePrecoProjetos { get; set; }
        public List<Fuzzie> Fuzzies { get; set; }
        public List<User> Usuarios { get; set; }

    }
}
