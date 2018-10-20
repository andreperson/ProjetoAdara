using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("uf")]
    public class UF
    {
        [Key]
        public int id { get; set; }
        public string uf { get; set; }
        public string estado { get; set; }
    }
}
