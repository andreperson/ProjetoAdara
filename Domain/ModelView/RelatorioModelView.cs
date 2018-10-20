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
    public class RelatorioModelView
    {
        public Int16 relatorioid { get; set; }
        public Int16 representanteid { get; set; }
        public Int16 boletoid { get; set; }
        public Int16 fabricaid { get; set; }
        public Int16 talaoitensid { get; set; }
        public Int16 clienteid { get; set; }
        public Int16 assessorid { get; set; }
        public int relatoriostatusid { get; set; }

        [Display(Name = "Valor Total")]
        public double valortotal { get; set; }

        [Display(Name = "Valor Comissão")]
        public double valorcomissao { get; set; }

        [Display(Name = "Valor Pago")]
        public double valorpago { get; set; }

        [Display(Name = "Data Pagamento")]
        public DateTime datapagto { get; set; }

        [Display(Name = "Data Recebimento")]
        public DateTime datarecebto { get; set; }

        [Display(Name = "Obs")]
        public double obs { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string user { get; set; }


        public DateTime dtboletode { get; set; }
        public DateTime dtboletoate { get; set; }
        public DateTime dtvencimentode { get; set; }
        public DateTime dtvencimentoate { get; set; }

        public DateTime dtrecebimentode { get; set; }
        public DateTime dtrecebimentoate { get; set; }
        public DateTime dtpagamentode { get; set; }
        public DateTime dtpagamentoate { get; set; }
        public double nrboletode { get; set; }
        public double nrboletoate { get; set; }

        public List<Relatorio> Relatorios { get; set; }
        public List<Representante> Representantes { get; set; }
        public List<Fabrica> Fabricas { get; set; }
        public List<Boleto> Boletos { get; set; }
        public List<TalaoItens> BoletosItens { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Assessor> Assessores { get; set; }
        public List<RelatorioStatus> RelatoriosStatus { get; set; }
    }
}
