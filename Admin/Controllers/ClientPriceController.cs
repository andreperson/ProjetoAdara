using System;
using System.Web.Mvc;
using Domain.ModelView;
using Servico.Service;

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
                model.status = 1;

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
            ViewBag.PageTopInformation = "Client Price Form";
            ViewBag.Acao = "Cliente Price Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceClientePreco.GetClientePrecoId(id3);
                ViewBag.Acao = "Client Price Edit";
            }

            //model.ClientePrecosTipos = ServiceClientePrecoTipo.getClientePrecoTipoCombo();
            model.ClientePrecos = ServiceClientePreco.getClientePreco();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.Fuzzies = ServiceFuzzie.getFuzzieCombo();
            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

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

            return Redirect(Domain.Util.config.UrlSite + "ClientPrice/ClientePreco/" + id + "/" + id2 + "/");
        }
    }
} 
