﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class UsuarioMenuModelView
    {
        public Int16 usuariomenuid { get; set; }
        public Int16 usuariotipoid { get; set; }
        public Int16 menuid { get; set; }

        public int status { get; set; }
        public DateTime? dataalt { get; set; }
        public string user { get; set; }
        public Int16 menusubid { get; set; }
        public List<Menu> Menus { get; set; }
        public List<MenuSub> MenusSubs { get; set; }
        public List<UsuarioTipo> UsuariosTipos { get; set; }
        public List<UsuarioMenu> UsuariosMenus { get; set; }

    }
}
