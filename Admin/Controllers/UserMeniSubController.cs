using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;

namespace Admin.Controllers
{
    public class UserMeniSubController : Controller
    {
        [HttpPost]
        public ActionResult UsuarioMenuSub(UsuarioMenuSubModelView model)
        {
            //insere via ajaxa, não faz nada por aqui
            return Redirect(Domain.Util.config.UrlSite + "MeniSub/MenuSub/" + model.menuid + "/" + model.menusubid + "/");
        }

        [HttpGet]
        public ActionResult UsuarioMenuSub(Int16 id = 0, Int16 id2=0, Int16 id3= 0)
        {
            UsuarioMenuSubModelView model = new UsuarioMenuSubModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceUsuarioMenuSub.GetUsuarioMenuSubId(id3);  
            }

            model.UsuariosTipos = ServiceUsuarioTipo.getUsuarioTipo();
            model.Menus = ServiceMenu.getMenu();
            //model.MenusSubs = ServiceMenuSub.getMenuSubAll();
            model.UsuariosMenusSubs = ServiceUsuarioMenuSub.getUsuarioMenuSub();
            model.MenusSubs = ServiceMenuSub.getMenuSub();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }


        public ActionResult UsuarioMenuSubDelete(Int16 id = 0)
        {
            if (id != 0)
            {
                //exclui registro
                ServiceUsuarioMenuSub.DeleteUsuarioMenuSubId(id); 
            }

            return Redirect(Domain.Util.config.UrlSite + "UserMeniSub/UsuarioMenuSub");
        }


        //insere as atividades do participante
        public void InsertAjax(List<string> data)
        {
            //posição 0 = tipoid - admin, padrão, etc
            //posição 1 = menuid
            UsuarioMenuSubModelView model = new UsuarioMenuSubModelView();
            string usuario = User.Identity.Name;
            //apaga todos
            ServiceUsuarioMenuSub.DeleteUsuarioMenuSubAll();
            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.usuariotipoid = Convert.ToInt16(menuarray[0]);
                model.menuid = Convert.ToInt16(menuarray[1]);
                model.menusubid = Convert.ToInt16(menuarray[2]);
                model.status = 1;
                model.user = usuario;
                //insere um de cada vez.
                ServiceUsuarioMenuSub.InsertUsuarioMenuSub(model);
            }
        }

        //busca as permissoes 
        public JsonResult ListaPermissoes()
        {
            return Json(ServiceUsuarioMenuSub.getUsuarioMenuSub(), JsonRequestBehavior.AllowGet);
        }

    }
}
