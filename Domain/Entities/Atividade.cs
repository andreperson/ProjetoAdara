﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("atividade")]
    public class Atividade
    {
        [Key]
        public int atividadeid { get; set; }
        public string descricao { get; set; }
        public int valor { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public string User { get; set; }
    }
}
