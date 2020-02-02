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
        public Int16 userid { get; set; }
        public int usuariotipoid { get; set; }

        [Required(ErrorMessage = "Password")]
        [Display(Name = "Password")]
        public string senha { get; set; }

        [Required(ErrorMessage = "Firlst Name")]
        [Display(Name = "First Name")]
        public string nome { get; set; }

        [Required(ErrorMessage = "Last Nome")]
        [Display(Name = "Last Nome")]
        public string sobrenome { get; set; }

        [Required(ErrorMessage = "Nick Name")]
        [Display(Name = "Nick Name")]
        public string apelido { get; set; }

        [Display(Name = "Birth Date")]
        public string dtnasc { get; set; }

        [Display(Name = "Course")]
        public string curso { get; set; }

        [Display(Name = "Institution")]
        public string instituicao{ get; set; }

        [Display(Name = "Formation")]
        public string formacao { get; set; }

        [Display(Name = "Adress")]
        public string endereco { get; set; }

        [Display(Name = "City")]
        public string cidade { get; set; }

        [Required(ErrorMessage = "Country")]
        [Display(Name = "Country")]
        public string pais { get; set; }

        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Display(Name = "About me")]
        public string about { get; set; }


        [Display(Name = "Image")]
        public HttpPostedFileBase imagem { get; set; }

        [Display(Name = "Image File")]
        public string arquivoimagem { get; set; }

        [Required(ErrorMessage = "E-mail")]
        [Display(Name = "E-mail")]
        public string email { get; set; }

        [Display(Name = "Receive E-mails")]
        public int recebeemails { get; set; }
        public bool recebeemailb { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public int status { get; set; }
        public bool statusb { get; set; }

        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string useralt { get; set; }

        public List<User> Usuarios { get; set; }
        public List<UsuarioTipo> UsuariosTipos { get; set; }
        public List<JobStatus> JobStatus { get; set; }

    }
}
