using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("help")]
    public class Help
    {
        [Key]
        public Int16 helpid { get; set; }

        public int menuid { get; set; }
        [ForeignKey("menuid")]
        public virtual Menu Menus { get; set; }

        public int menusubid { get; set; }
        [ForeignKey("menusubid")]
        public virtual MenuSub MenusSub { get; set; }


        public string titulo { get; set; }
        public string descricao { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
