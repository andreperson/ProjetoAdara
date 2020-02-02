using System;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;


namespace Admin.Controllers
{
    public class LanguagePairController : Controller
    {
        [HttpPost]
        public ActionResult ParIdioma(ParIdiomaModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                model.Descricao = model.Descricaode + " - " + model.Descricaopara;
                if (model.paridiomaid != 0) //update
                {
                    ServiceParIdioma.UpdateParIdioma(model);
                }
                else //insert
                {
                    ServiceParIdioma.InsertParIdioma(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "LanguagePair/ParIdioma/" + model.menuid + "/" + model.menusubid);

            }

            model.Idiomas = ServiceIdioma.getIdiomaCombo();
            model.ParIdiomas = ServiceParIdioma.getParIdiomaCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult ParIdioma(Int16 id = 0, Int16 id2=0, Int16 id3 =0)
        {
            var model = new ParIdiomaModelView();
            ViewBag.PageTopInformation = "Language Pair Form";
            ViewBag.Acao = "Language Pair Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceParIdioma.GetParIdiomaId(id3);
                ViewBag.Acao = "Language Pair Edit";
            }

            model.ParIdiomas = ServiceParIdioma.getParIdioma();
            model.Idiomas = ServiceIdioma.getIdiomaCombo();
            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }

      

        public ActionResult ParIdiomaDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceParIdioma.DeleteParIdiomaId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "LanguagePair/ParIdioma/" + id + "/" + id2);
        }
    }
}
