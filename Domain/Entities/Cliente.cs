using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("cliente")]
    public class Cliente
    {
        [Key]
        public Int16 clienteid { get; set; }
        public int clientetipoid { get; set; }
        [ForeignKey("clientetipoid")]
        public virtual ClienteTipo ClienteTipo { get; set; }

        public string RazaoSocial { get; set; }
        public string Fantasia { get; set; }
        public string Email { get; set; }
        public string DDD { get; set; }
        public string Fone { get; set; }
        public string Nome { get; set; }
        public string obs { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string user { get; set; }
    }
}
