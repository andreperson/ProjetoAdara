using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("clientepreco")]
    public class ClientePreco
    {
        [Key]
        public int clienteprecoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }
        public Int16 fuzzieid { get; set; }
        [ForeignKey("fuzzieid")]
        public virtual Fuzzie Fuzzie { get; set; }
        public double Valor { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
