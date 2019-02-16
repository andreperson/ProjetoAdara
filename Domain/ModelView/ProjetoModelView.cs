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

        [Required(ErrorMessage = "Inform Client Please")]
        [Display(Name = "Client")]
        public Int16 clienteid { get; set; }

        [Required(ErrorMessage = "Inform Project Type Please")]
        [Range(1, int.MaxValue, ErrorMessage = "Inform Project Type Please")]
        [Display(Name = "Project Type")]
        public int projetotipoid { get; set; }

        [Required(ErrorMessage = "Inform Source Language Please")]
        [Display(Name = "Source Language")]
        public int idiomaidfrom { get; set; }

        [Required(ErrorMessage = "Inform Target Language Please")]
        [Display(Name = "Target Language")]
        public int idiomaidto { get; set; }
        public int idiomaid { get; set; }

        [Display(Name = "Manager")]
        public Int16 userid { get; set; }

        [Required(ErrorMessage = "Inform Project Number Please")]
        [Display(Name = "Project Number")]
        public string numeroprojeto{ get; set; }

        [Required(ErrorMessage = "Inform Title Please")]
        [Display(Name = "Title")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Inform Currency Please")]
        [Display(Name = "Currency")]
        public int moedaidrecebe { get; set; }

        [Required(ErrorMessage = "Inform Partial Term Please")]
        [Display(Name = "Partial Term")]
        public DateTime? dataentregaprev { get; set; }

        [Required(ErrorMessage = "Inform Deadline Please")]
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
    }
}
