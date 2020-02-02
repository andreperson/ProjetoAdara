using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("login")]
    public class Login
    {
        [Key]
        public int loginid { get; set; }
        public Int16 userid { get; set; }
        [ForeignKey("userid")]
        public virtual User User { get; set; }
        public string apelido { get; set; }
        public string email { get; set; }
        public string origem { get; set; }
        public DateTime? Dataalt { get; set; }
    }
}
