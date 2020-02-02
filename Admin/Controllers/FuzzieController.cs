using System;
using System.Web.Mvc;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class DiffuseController : Controller
    {
        [HttpPost]
        public ActionResult Fuzzie(FuzzieModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.fuzzieid != 0) //update
                {
                    ServiceFuzzie.UpdateFuzzie(model);
                }
                else //insert
                {
                    ServiceFuzzie.InsertFuzzie(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Diffuse/Fuzzie/" + model.menuid + "/" + model.menusubid);

            }
            model.Fuzzies = ServiceFuzzie.getFuzzie();

            return View(model);
        }

        [HttpGet]
        public ActionResult Fuzzie(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new FuzzieModelView();

            ViewBag.PageTopInformation = "Fuzzie Form";
            ViewBag.Acao = "Fuzzie Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceFuzzie.GetFuzzieId(id3);
                ViewBag.Acao = "Client Type Edit";
            }

            model.Fuzzies = ServiceFuzzie.getFuzzie();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult FuzzieDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceFuzzie.DeleteFuzzieId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Diffuse/Fuzzie/" + id + "/" + id2);
        }
    }
}
