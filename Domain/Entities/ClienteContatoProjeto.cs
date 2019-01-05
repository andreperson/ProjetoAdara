using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("clientecontatoprojeto")]
    public class ClienteContatoProjeto
    {
        [Key]
        public Int16 clientecontatoprojetoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }

        public Int16 clientecontatoid { get; set; }
        [ForeignKey("clientecontatoid")]
        public virtual ClienteContato ClienteContato { get; set; }

        public Int16 projetoid { get; set; }
        [ForeignKey("projetoid")]
        public virtual Projeto Projeto { get; set; }

    }
}
