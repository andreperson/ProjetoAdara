using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.ModelView
{
    public class DeleteModelView
    {
        public Int16 Id { get; set; }
        public string Id1 { get; set; }
        public string Id2 { get; set; }
        public string Id3 { get; set; }
        public string Id4 { get; set; }
        public Int16 MenuId { get; set; }
        public Int16 MenuSubId { get; set; }
        public string Descricao { get; set; }
        public string Control { get; set; }
        public string Act { get; set; }
        public string Param { get; set; }
    }
}
