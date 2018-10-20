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
    public class FabricaTipoModelView
    {
        public Int16 Fabricatipoid { get; set; }

        [Required(ErrorMessage = "Descricao")]
        [Display(Name = "Descricao")]
        public string descricao { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public List<FabricaTipo> FabricaTipos { get; set; }
    }
}
