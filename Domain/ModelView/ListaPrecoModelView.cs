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
    public class ListaPrecoModelView
    {

        public int listaprecoid { get; set; }
        [Display(Name = "Par de Idioma")]
        public int paridiomaid { get; set; }
        [Display(Name = "Moeda")]
        public int moedaid { get; set; }
        [Display(Name = "Competência")]
        public int competenciaid { get; set; }

        [Display(Name = "Preço Palavra")]
        public string Precopalavra { get; set; }

        [Display(Name = "Preço Linha")]
        public string Precolinha { get; set; }

        [Display(Name = "Preço Hora")]
        public string Precohora { get; set; }

        [Display(Name = "Preço Mínimo")]
        public string Precominimo { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
        public int status { get; set; }
        public bool statusb { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        [Display(Name = "Par de Idioma")]
        public List<ParIdioma> ParIdiomas { get; set; }

        [Display(Name = "Moeda")]
        public List<Moeda> Moedas { get; set; }

        [Display(Name = "Competência")]
        public List<Competencia> Competencias { get; set; }

        [Display(Name = "Lista Preço")]
        public List<ListaPreco> ListaPrecos { get; set; }

    }
}
