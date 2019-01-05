using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;

namespace Domain.ModelView
{
    public class TepAtvModelView
    {
        public int tepatvid { get; set; }

        [Required(ErrorMessage = "Tep")]
        [Display(Name = "Tep")]
        public int tepid { get; set; }

        [Required(ErrorMessage = "Brekedown")]
        [Display(Name = "Brekedown")]
        public int atividadeid { get; set; }

        public DateTime? dataincl { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<Atividade> Atividades { get; set; }
        public List<Tep> Teps { get; set; }
        public List<BrekeAtvModelView> BrekeAtvs { get; set; }
    }
}
