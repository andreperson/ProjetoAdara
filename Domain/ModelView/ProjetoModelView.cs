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
    public class ProjetoModelView
    {
        public Int16 projetoid { get; set; }

        [Required(ErrorMessage = "Client")]
        [Display(Name = "Client")]
        public Int16 clienteid { get; set; }

        [Display(Name = "Project Type")]
        public int projetotipoid { get; set; }

        [Display(Name = "Price List")]
        public int listaprecoid { get; set; }

        [Display(Name = "Source laguage")]
        public int idiomaidfrom { get; set; }

        [Display(Name = "Target language")]
        public int idiomaidto { get; set; }
        public int idiomaid { get; set; }

        [Display(Name = "Manager")]
        public Int16 userid { get; set; }

        [Required(ErrorMessage = "Project Number")]
        [Display(Name = "Project Number")]
        public string numeroprojeto{ get; set; }

        [Required(ErrorMessage = "Title")]
        [Display(Name = "Title")]
        public string titulo { get; set; }

        [Display(Name = "Currency")]
        public int moedaidrecebe { get; set; }

        [Display(Name = "Partial Term")]
        public DateTime? dataentregaprev { get; set; }

        [Display(Name = "Deadline")]
        public DateTime? dataentrega { get; set; }

        [Display(Name = "Description")]
        public string descricao { get; set; }

        [Display(Name = "Obs")]
        public string obs { get; set; }

        [Display(Name = "Attachment")]
        public HttpPostedFileBase documento { get; set; }

        [Display(Name = "Attachment")]
        public string documentoanexo { get; set; }

        public bool statusb { get; set; }
        public int status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string usu { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Projeto> Projetos { get; set; }
        public List<ProjetoTipo> ProjetoTipos { get; set; }
        public List<User> Usuarios { get; set; }
        public List<Moeda> Moedas { get; set; }
        public List<Competencia> Competencias { get; set; }
        public List<Idioma> Idiomas { get; set; }
        public List<ClientePreco> ClientePrecos { get; set; }
        public List<ListaPreco> ListaPrecos { get; set; }

    }
}
