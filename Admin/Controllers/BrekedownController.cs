using System;
using System.Web.Mvc;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class BrekedownController : Controller
    {
        [HttpPost]
        public ActionResult Breke(BrekeModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.brekedownid != 0) //update
                {
                    ServiceBrekedown.UpdateBrekedown(model);
                }
                else //insert
                {
                    ServiceBrekedown.InsertBrekedown(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Brekedown/Breke/" + model.menuid + "/" + model.menusubid);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Breke(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new BrekeModelView();

            ViewBag.PageTopInformation = "Brekedown Form";
            ViewBag.Acao = "Brekedown Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceBrekedown.GetBrekedownId(id3);
                ViewBag.Acao = "Brekedown Edit";
            }

            model.Brekedowns = ServiceBrekedown.getBrekedown();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult BrekeDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceBrekedown.DeleteBrekedownId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Brekedown/Breke/" + id + "/" + id2);
        }
    }
}
