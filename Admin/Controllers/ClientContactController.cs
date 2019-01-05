using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Domain.Entities;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class ClientContactController : Controller
    {
        [HttpPost]
        public ActionResult ClienteContato(ClienteContatoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.clientecontatoid != 0) //update
                {
                    ServiceClienteContato.UpdateClienteContato(model);
                }
                else //insert
                {
                    ServiceClienteContato.InsertClienteContato(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "ClientContact/ClienteContato/" + model.menuid + "/" + model.menusubid);

            }
            model.Clientes = ServiceCliente.getClienteCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult ClienteContato(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ClienteContatoModelView();

            ViewBag.PageTopInformation = "Client Contact Form";
            ViewBag.Acao = "Client Contact Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceClienteContato.GetClienteContatoId(id3);
                ViewBag.Acao = "Client Contact Edit";
            }
            model.Clientes = ServiceCliente.getClienteCombo();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }

        public JsonResult ListaContatos(Int16 id = 0)
        {
            return Json(ServiceClienteContato.getClienteContatoByClientId(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult ClienteContatoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceClienteContato.DeleteClienteContatoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "ClientContact/ClienteContato/" + id + "/" + id2);
        }
    }
}
