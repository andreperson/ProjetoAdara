using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("clienteprecoprojeto")]
    public class ClientePrecoProjeto
    {
        [Key]
        public Int16 clienteprecoprojetoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }

        public int clienteprecoid { get; set; }
        [ForeignKey("clienteprecoid")]
        public virtual ClientePreco ClientePreco { get; set; }

        public Int16 projetoid { get; set; }
        [ForeignKey("projetoid")]
        public virtual Projeto Projeto { get; set; }

        public Int16 fuzzieid { get; set; }
        [ForeignKey("fuzzieid")]
        public virtual Fuzzie Fuzzie { get; set; }

        public double valorperc { get; set; }
        public int qtdepalavra { get; set; }
        public int status { get; set; }
    }
}
