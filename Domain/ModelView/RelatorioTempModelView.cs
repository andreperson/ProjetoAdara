using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class RelatorioTempModelView
    {
        public Int16 relatoriotempid { get; set; }
        public Int16 representanteid { get; set; }
        public Int16 boletoid { get; set; }
        public DateTime dtvencimento { get; set; }

        public DateTime dataincl { get; set; }
        public string user { get; set; }

        public List<RelatorioTemp> RelatoriosTemps { get; set; }
        public List<Representante> Representantes { get; set; }
        public List<Boleto> Boletos { get; set; }
    }
}
