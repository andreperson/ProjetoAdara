using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("brekedown")]
    public class Brekedown
    {
        [Key]
        public int brekedownid { get; set; }
        public string descricao { get; set; }
        public string valor { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
