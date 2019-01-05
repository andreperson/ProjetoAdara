using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Domain.Entities;
using Servico.Service;
using Domain.ModelView;
using Servico.Consumo;

namespace Admin.Controllers
{
    public class UserMeniController : Controller
    {
        [HttpPost]
        public ActionResult UsuarioMenu(UsuarioMenuModelView model)
        {
            //insere via ajaxa, não faz nada por aqui
            return Redirect(Domain.Util.config.UrlSite + "UserMeni/UsuarioMenu/" + model.menuid + "/" + model.menusubid);
        }

        [HttpGet]
        public ActionResult UsuarioMenu(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new UsuarioMenuModelView();
            ViewBag.PageTopInformation = "Permission Form";
            ViewBag.Acao = "Permissions Control";
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceUsuarioMenu.GetUsuarioMenuId(id3);
            }

            model.UsuariosTipos = ServiceUsuarioTipo.getUsuarioTipo();
            model.Menus = ServiceMenu.getMenu();
            model.UsuariosMenus = ServiceUsuarioMenu.getUsuarioMenu();
            model.MenusSubs = ServiceMenuSub.getMenuSubAll();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult UsuarioMenuDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceUsuarioMenu.DeleteUsuarioMenuId(id);
            }

            return Redirect(Domain.Util.config.UrlSite + "UserMeni/UsuarioMenu/" + id + "/" + id2);
        }


        //insere as atividades do participante
        public void InsertAjax(List<string> data)
        {
            //posição 0 = tipoid - admin, padrão, etc
            //posição 1 = menuid
            UsuarioMenuModelView model = new UsuarioMenuModelView();
            string usuario = User.Identity.Name;
            //apaga todos
            ServiceUsuarioMenu.DeleteUsuarioMenuAll();
            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.usuariotipoid = Convert.ToInt16(menuarray[0]);
                model.menuid = Convert.ToInt16(menuarray[1]);
                model.status = 1;
                model.user = usuario;
                //insere um de cada vez.
                ServiceUsuarioMenu.InsertUsuarioMenu(model);
            }
        }

        //busca as permissoes 
        public JsonResult ListaPermissoes()
        {
            return Json(ServiceUsuarioMenu.getUsuarioMenu(), JsonRequestBehavior.AllowGet);
        }



       
        public string GetMenuSub(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0) 
        {


            ViewBag.MenuSubQtde = "2";


            return "";
        }

    }
}
