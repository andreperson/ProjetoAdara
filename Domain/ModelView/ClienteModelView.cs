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
    public class ClienteModelView
    {
        public Int16 clienteid { get; set; }

        [Required(ErrorMessage = "Client Type")]
        [Display(Name = "Client Type")]
        public Int16 clientetipoid { get; set; }

        [Required(ErrorMessage = "Contact Name")]
        [Display(Name = "Contact Name")]
        public string Nome { get; set; }

        [Display(Name = "DDD")]
        public string DDD { get; set; }

        [Display(Name = "Telefone")]
        public string Fone { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Fantasia")]
        [Display(Name = "Fantasia")]
        public string Fantasia { get; set; }

        [Display(Name = "Obs")]
        public string obs { get; set; }

        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<ClienteTipo> ClientesTipos { get; set; }
        public List<UF> UFs { get; set; }
        
    }
}
