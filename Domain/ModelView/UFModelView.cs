using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class UFModelView
    {
        public Int16 id { get; set; }
        [Display(Name = "UF")]
        public string uf { get; set; }

        [Display(Name = "Estado")]
        public string estado { get; set; }

        public List<UF> UFs { get; set; }
    }
}
