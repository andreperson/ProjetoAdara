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
    public class ClientePrecoProjetoModelView
    {
        public Int16 clienteprecoprojetoid { get; set; }
        public Int16 clienteid { get; set; }
        public Int16 projetoid { get; set; }
        public Int16 clienteprecoid { get; set; }
        public Int16 fuzzieid { get; set; }
        public double valorperc { get; set; }
        public int qtdepalavra { get; set; }

    }
}
