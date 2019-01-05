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
    public class UsuarioModelView
    {
        public int userid { get; set; }
        public int usuariotipoid { get; set; }

        [Required(ErrorMessage = "Senha")]
        [Display(Name = "Senha")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Nome")]
        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Apelido")]
        [Display(Name = "Apelido")]
        public string apelido { get; set; }

        [Display(Name = "Imagem")]
        public HttpPostedFileBase imagem { get; set; }

        [Display(Name = "Arquivo Imagem")]
        public string arquivoimagem { get; set; }

        [Required(ErrorMessage = "E-mail")]
        [Display(Name = "E-mail")]
        public string email { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public int status { get; set; }
        public bool statusb { get; set; }

        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string useralt { get; set; }

        public List<User> Usuarios { get; set; }
        public List<UsuarioTipo> UsuariosTipos { get; set; }
        
    }
}
