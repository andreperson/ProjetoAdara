using System;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;


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
                model.status = 1;
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
            ViewBag.PageTopInformation = "User Type";
            ViewBag.Acao = "User Type Add";
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceUsuarioTipo.GetUsuarioTipoId(Convert.ToInt16(id3));
                ViewBag.Acao = "User Type Edit";
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
