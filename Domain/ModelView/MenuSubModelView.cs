using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;

namespace Domain.ModelView
{
    public class MenuSubModelView
    {
        public int menusubid { get; set; }
        public int menuid { get; set; }

        public int menuid_click { get; set; }
        public int menusubid_click { get; set; }
        public string menuact { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor informe a Descrição.")]
        public string descricao { get; set; }

        public string descricaomenu { get; set; }

        [Display(Name = "Controller")]
        [Required(ErrorMessage = "Por favor informe o Controller.")]
        public string controller { get; set; }

        [Display(Name = "View")]
        [Required(ErrorMessage = "Por favor informe a View.")]
        public string view { get; set; }

        [Display(Name = "Ordem")]
        [Required(ErrorMessage = "Por favor informe a Ordem.")]
        public int ordem { get; set; }

        [Display(Name = "Ícone")]
        [Required(ErrorMessage = "Por favor informe o Ícone.")]
        public string icone { get; set; }

        public int status { get; set; }
        public bool statusb { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }

        [Display(Name = "Menus")]
        public List<Menu> menus { get; set; }

        [Display(Name = "MenusSubs")]
        public List<MenuSub> menussubs { get; set; }

    }
}
