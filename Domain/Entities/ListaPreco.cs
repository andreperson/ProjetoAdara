using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("listapreco")]
    public class ListaPreco
    {
        [Key]
        public int ListaPrecoid { get; set; }
        public int paridiomaid { get; set; }
        [ForeignKey("paridiomaid")]
        public virtual ParIdioma ParIdioma { get; set; }
        public int moedaid { get; set; }
        [ForeignKey("moedaid")]
        public virtual Moeda Moeda { get; set; }
        public int competenciaid { get; set; }
        [ForeignKey("competenciaid")]
        public virtual Competencia Competencia { get; set; }

        public string Descricao { get; set; }
        public double Precopalavra { get; set; }
        public double Precolinha { get; set; }
        public double Precohora { get; set; }
        public double Precominimo { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
