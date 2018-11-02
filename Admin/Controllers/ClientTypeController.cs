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
    public class ClientTypeController : Controller
    {
        [HttpPost]
        public ActionResult ClienteTipo(ClienteTipoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.clientetipoid != 0) //update
                {
                    ServiceClienteTipo.UpdateClienteTipo(model);
                }
                else //insert
                {
                    ServiceClienteTipo.InsertClienteTipo(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "ClientType/ClienteTipo/" + model.menuid + "/" + model.menusubid);

            }
            model.ClienteTipos = ServiceClienteTipo.getClienteTipo();

            return View(model);
        }

        [HttpGet]
        public ActionResult ClienteTipo(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ClienteTipoModelView();

            ViewBag.PageTopInformation = "Client Type Form";
            ViewBag.Acao = "Client Type Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceClienteTipo.GetClienteTipoId(id3);
                ViewBag.Acao = "Client Type Edit";
            }

            model.ClienteTipos = ServiceClienteTipo.getClienteTipo();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult ClienteTipoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceClienteTipo.DeleteClienteTipoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "ClientType/ClienteTipo/" + id + "/" + id2);
        }
    }
}
