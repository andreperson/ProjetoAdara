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
    public class ClienteContatoModelView
    {
        public Int16 clientecontatoid { get; set; }
        public Int16 clienteid { get; set; }

        [Required(ErrorMessage = "Fill Name")]
        [Display(Name = "Name")]
        public string nome { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Cod")]
        public string dddcelular { get; set; }

        [Display(Name = "Cod")]
        public string dddfone { get; set; }

        [Display(Name = "Mobile")]
        public string celular { get; set; }

        [Display(Name = "Phone")]
        public string fone { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<ClienteContato> ClienteContatos { get; set; }
        public List<Cliente> Clientes { get; set; }
    }
}
