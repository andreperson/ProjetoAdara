using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("clientecontato")]
    public class ClienteContato
    {
        [Key]
        public Int16 clientecontatoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string dddcelular { get; set; }
        public string celular { get; set; }
        public string dddfone { get; set; }
        public string fone { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
