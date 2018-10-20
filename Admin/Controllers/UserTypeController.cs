using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing; 
using Data.Entities;
using Data.Repository;
using Domain.ModelView;
using Domain.Service; 

namespace Admin.Controllers
{
    public class UserTypeController : Controller
    {
        [HttpPost]
        public ActionResult UsuarioTipo(UsuarioTipoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.usuariotipoid != 0) //update
                {
                    ServiceUsuarioTipo.UpdateUsuarioTipo(model);
                }
                else //insert
                {
                    ServiceUsuarioTipo.InsertUsuarioTipo(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "UserType/UsuarioTipo/" + model.menuid + "/" + model.menusubid);

            }
            model.UsuarioTipos = ServiceUsuarioTipo.getUsuarioTipo();

            return View(model);
        }

        [HttpGet]
        public ActionResult UsuarioTipo(Int16 id = 0, Int16 id2 = 0, Int16 id3=0)
        {
            var model = new UsuarioTipoModelView();
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceUsuarioTipo.GetUsuarioTipoId(Convert.ToInt16(id3));  
            }

            model.UsuarioTipos = ServiceUsuarioTipo.getUsuarioTipo();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult UsuarioTipoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceUsuarioTipo.DeleteUsuarioTipoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "UserType/UsuarioTipo/" + id + "/" + id2);
        }
    }
}
