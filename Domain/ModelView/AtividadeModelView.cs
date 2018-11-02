﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class AtividadeModelView
    {
        public Int16 atividadeid { get; set; }

        [Required(ErrorMessage = "Description")]
        [Display(Name = "Description")]
        public string descricao { get; set; }

        [Required(ErrorMessage = "Value")]
        [Display(Name = "Value")]
        public int valor { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }

        public List<Data.Entities.Atividade> Atividades { get; set; }
    }
}
