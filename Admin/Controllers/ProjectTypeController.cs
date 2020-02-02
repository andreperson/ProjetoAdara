using System;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;


namespace Admin.Controllers
{
    public class ProjectTypeController : Controller
    {
        [HttpPost]
        public ActionResult ProjetoTipo(ProjetoTipoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.Projetotipoid != 0) //update
                {
                    ServiceProjetoTipo.UpdateProjetoTipo(model);
                }
                else //insert
                {
                    ServiceProjetoTipo.InsertProjetoTipo(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "ProjectType/ProjetoTipo/" + model.menuid + "/" + model.menusubid);

            }
            model.ProjetosTipos = ServiceProjetoTipo.getProjetoTipo();

            return View(model);
        }

        [HttpGet]
        public ActionResult ProjetoTipo(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ProjetoTipoModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceProjetoTipo.GetProjetoTipoId(id3);  
            }

            model.ProjetosTipos = ServiceProjetoTipo.getProjetoTipo();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult ProjetoTipoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceProjetoTipo.DeleteProjetoTipoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "ProjectType/ProjetoTipo" + id + "/" + id2 + "/" + id3);
        }
    }
}
