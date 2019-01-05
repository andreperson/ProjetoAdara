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
    public class ClienteContatoProjetoModelView
    {
        public Int16 clientecontatoprojetoid { get; set; }
        public Int16 clienteid { get; set; }
        public Int16 projetoid { get; set; }
        public Int16 clientecontatoid { get; set; }
    }
}
