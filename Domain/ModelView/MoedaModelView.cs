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
    public class MoedaModelView
    {
        public Int16 Moedaid { get; set; }

        [Required(ErrorMessage = "Descrição")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<Moeda> Moedas { get; set; }

    }
}
