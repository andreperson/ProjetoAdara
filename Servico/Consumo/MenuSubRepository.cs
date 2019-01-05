using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data.DataContext;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class MenuSubRepository : GenericRepository<MenuSub>  
    {
        public MenuSub GetMenuSub(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }

        public List<MenuSub> GetMenuSubAll()
        {
            //primeiro pega todos os menus cadastrados
            var lst = Search(x => x.status == 1).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }



        public virtual IQueryable GetMenuSub()
        {

            UsuarioMenuSub objretorno = new UsuarioMenuSub();
            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            ConnDataContext db = new ConnDataContext();


            var lst = from sub in db.MenuSub
                      join menu in db.Menu on sub.menuid equals menu.menuid
                      //where menu.menuid == menuid
                      orderby menu.ordem, sub.ordem
                      select new
                      {
                          DESCRICAOSUB = sub.descricao,
                          ICONE = sub.icone,
                          SUBMENUID = sub.menusubid,
                          MENUID = sub.menuid,
                          DESCRICAOMENU = menu.descricao,
                          CONTROLLER = sub.controller.Trim(),
                          VIEW = sub.view.Trim(),
                          MENUACT = sub.menuact.Trim()

                      };
            return lst;
        }


        public virtual IQueryable GetSubMenuPermitido(int usuariotipoid, int menuid)
        {

            UsuarioMenuSub objretorno = new UsuarioMenuSub();
            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            ConnDataContext db = new ConnDataContext();


            var lst = from sub in db.MenuSub
                      join UsuarioMenuSub us in db.UsuarioMenuSub on sub.menusubid equals us.menusubid
                      where us.usuariotipoid == usuariotipoid & sub.menuid == menuid
                      orderby sub.ordem, sub.descricao
                      select new
                      {
                          DESCRICAOSUB = sub.descricao,
                          ICONE = "",
                          SUBMENUID = sub.menusubid,
                          MENUID = sub.menuid,
                          DESCRICAOMENU = "",
                          CONTROLLER = sub.controller.Trim(),
                          VIEW = sub.view.Trim(),
                          MENUACT = sub.menuact.Trim()
                      };
            return lst;
        }

        public virtual IQueryable GetSubMenuPermitido(int usuariotipoid, string action)
        {

            UsuarioMenuSub objretorno = new UsuarioMenuSub();
            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            ConnDataContext db = new ConnDataContext();


            var lst = from sub in db.MenuSub
                      join UsuarioMenuSub us in db.UsuarioMenuSub on sub.menusubid equals us.menusubid
                      where us.usuariotipoid == usuariotipoid & sub.controller == action
                      orderby sub.ordem, sub.descricao
                      select new
                      {
                          DESCRICAOSUB = sub.descricao,
                          ICONE = "",
                          SUBMENUID = sub.menusubid,
                          MENUID = sub.menuid,
                          DESCRICAOMENU = "",
                          CONTROLLER = sub.controller.Trim(),
                          VIEW = sub.view.Trim(),
                          MENUACT = sub.menuact.Trim()
                      };
            return lst;
        }


        //public virtual IQueryable<MenuSub> GetMenuSub()
        //{
        //    ConnDataContext db = new ConnDataContext();
        //    IQueryable<MenuSub> lst = from sub in db.MenuSub
        //                                       join menu in db.Menu on sub.menuid equals menu.menuid

        //                                       select sub;
        //    return lst;
        //}
    }
}
