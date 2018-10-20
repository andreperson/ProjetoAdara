using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.ModelView
{
    public class IndexModelView
    {
        public Int16 DestaqueId { get; set; }
        public Int16 NovidadeId { get; set; }
        public Int16 ProdutoId { get; set; }
        public string Codigo { get; set; }

        
    }
}
