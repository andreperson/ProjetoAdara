using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class ActivityController : Controller
    {
        [HttpPost]
        public ActionResult Atividade(AtividadeModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.atividadeid != 0) //update
                {
                    ServiceAtividade.UpdateAtividade(model);
                }
                else //insert
                {
                    ServiceAtividade.InsertAtividade(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Activity/Atividade/" + model.menuid + "/" + model.menusubid);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Atividade(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new AtividadeModelView();

            ViewBag.PageTopInformation = "Activity Form";
            ViewBag.Acao = "Activity Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceAtividade.GetAtividadeId(id3);
                ViewBag.Acao = "Activity Edit";
            }

            model.Atividades = ServiceAtividade.getAtividade();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult AtividadeDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceAtividade.DeleteAtividadeId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Activity/Atividade/" + id + "/" + id2);
        }
    }
}
