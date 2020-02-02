using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Entities;


namespace Domain.ModelView
{
    public class AjudaModelView
    {
        public Int16 helpid { get; set; }

        [Required(ErrorMessage = "Titulo")]
        [Display(Name = "Titulo")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Description")]
        [Display(Name = "Description")]
        public string descricao { get; set; }

        public int menuid { get; set; }
        public int menusubid { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        public int menuid_click { get; set; }
        public int menusubid_click { get; set; }

        public List<Help> Ajudas { get; set; }
        public List<Menu> Menus { get; set; }
        public List<MenuSub> MenuSubs { get; set; }
    }
}
