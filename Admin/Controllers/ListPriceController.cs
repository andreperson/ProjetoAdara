using System;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;


namespace Admin.Controllers
{
    public class ListPriceController : Controller
    {
        [HttpPost]
        public ActionResult ListaPreco(ListaPrecoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                model.Precohora = model.Precohora.Replace(".", "");
                model.Precolinha = model.Precolinha.Replace(".", "");
                model.Precominimo = model.Precominimo.Replace(".", "");
                model.Precopalavra = model.Precopalavra.Replace(".", "");
                if (model.listaprecoid != 0) //update
                {
                    ServiceListaPreco.UpdateListaPreco(model);
                }
                else //insert
                {
                    ServiceListaPreco.InsertListaPreco(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "ListPrice/ListaPreco/" + model.menuid + "/" + model.menusubid);

            }

            //model.ListaPrecos = ServiceListaPreco.getListaPrecoCombo();
            //model.Moedas = ServiceMoeda.getMoedaCombo();
            //model.Competencias = ServiceCompetencia.getCompetenciaCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult ListaPreco(Int16 id = 0, Int16 id2=0, Int16 id3 =0)
        {
            var model = new ListaPrecoModelView();
            ViewBag.PageTopInformation = "Client Price Form";
            ViewBag.Acao = "Price Type Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceListaPreco.GetListaPrecoId(id3);
                ViewBag.Acao = "Client Price Edit";

            }

            model.ListaPrecos = ServiceListaPreco.getListaPreco();
            model.Moedas = ServiceMoeda.getMoedaCombo();
            model.Competencias = ServiceCompetencia.getCompetenciaCombo();
            model.ParIdiomas = ServiceParIdioma.getParIdiomaCombo();
            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            model.Precopalavra = Domain.Util.formata.FormataMoeda(model.Precopalavra);
            model.Precolinha = Domain.Util.formata.FormataMoeda(model.Precolinha);
            model.Precohora = Domain.Util.formata.FormataMoeda(model.Precohora);
            model.Precominimo = Domain.Util.formata.FormataMoeda(model.Precominimo);

            return View(model);
        }

      

        public ActionResult ListaPrecoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceListaPreco.DeleteListaPrecoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "ListPrice/ListaPreco/" + id + "/" + id2);
        }
    }
}
