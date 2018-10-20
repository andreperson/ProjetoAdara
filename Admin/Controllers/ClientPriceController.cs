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
    public class ClientPriceController : Controller
    {
        [HttpPost]
        public ActionResult ClientePreco(ClientePrecoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                model.Precopalavra = model.Precopalavra.Replace(".", "");
                model.Precolinha = model.Precolinha.Replace(".", "");
                model.Precohora = model.Precohora.Replace(".", "");
                model.Precominimo = model.Precominimo.Replace(".", "");

                if (model.ClientePrecoid != 0) //update
                {
                    ServiceClientePreco.UpdateClientePreco(model);
                }
                else //insert
                {
                    ServiceClientePreco.InsertClientePreco(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "ClientPrice/ClientePreco/" + model.menuid + "/" + model.menusubid);

            }
           
            //model.ClientePrecos = ServiceClientePreco.getClientePrecoCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult ClientePreco(Int16 id = 0, Int16 id2=0, Int16 id3 =0)
        {
            var model = new ClientePrecoModelView();
            
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceClientePreco.GetClientePrecoId(id3);  
            }

            //model.ClientePrecosTipos = ServiceClientePrecoTipo.getClientePrecoTipoCombo();
            model.ClientePrecos = ServiceClientePreco.getClientePreco();
            model.ParIdiomas = ServiceParIdioma.getParIdiomaCombo();
            model.Competencias = ServiceCompetencia.getCompetenciaCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            model.Precopalavra = Domain.Util.formata.FormataMoeda(model.Precopalavra);
            model.Precolinha = Domain.Util.formata.FormataMoeda(model.Precolinha);
            model.Precohora = Domain.Util.formata.FormataMoeda(model.Precohora);
            model.Precominimo = Domain.Util.formata.FormataMoeda(model.Precominimo);


            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult ClientePrecoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceClientePreco.DeleteClientePrecoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "ClientPrice/ClientePreco/" + id + "/" + id2 + "/" + id3);
        }
    }
} 
