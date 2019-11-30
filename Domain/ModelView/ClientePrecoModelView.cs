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
    public class ClientePrecoModelView
    {
        public int ClientePrecoid { get; set; }
        [Display(Name = "Client")]
        public Int16 clienteid { get; set; }
        [Display(Name = "Fuzzie")]
        public Int16 fuzzieid { get; set; }
        [Display(Name = "Value")]
        public double Valor { get; set; }
        public int QtdePalavra { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<ClientePreco> ClientePrecos { get; set; }

        [Display(Name = "Cliente")]
        public List<Cliente> Clientes { get; set; }

        [Display(Name = "Fuzzie")]
        public List<Fuzzie> Fuzzies { get; set; }

    }
}

