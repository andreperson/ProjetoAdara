using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("menusub")]
    public class MenuSub
    {
        [Key]
        public int menusubid { get; set; }
        public int menuid { get; set; }
        [ForeignKey("menuid")]
        public virtual Menu Menu { get; set; }
        public string menuact { get; set; }
        public string descricao { get; set; }
        public string descricaomenu { get; set; }
        public string controller { get; set; }
        public string icone { get; set; }
        public string view { get; set; }
        public int ordem { get; set; }
        public int status { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }
    }
}
