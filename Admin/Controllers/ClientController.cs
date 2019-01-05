using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.ModelView;
using Domain.Entities;
using Servico.Service;



namespace Admin.Controllers
{
    public class ClientController : Controller
    {
        [HttpPost]
        public ActionResult Cliente(ClienteModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.clienteid != 0) //update
                {
                    ServiceCliente.UpdateCliente(model);
                }
                else //insert
                {
                    ServiceCliente.InsertCliente(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Client/Cliente/" + model.menuid + "/" + model.menusubid);

            }

            model.ClientesTipos = ServiceClienteTipo.getClienteTipoCombo();
            return View(model);
        }

        [HttpGet]
        public ActionResult Cliente(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ClienteModelView();
            ViewBag.PageTopInformation = "Client Form";
            ViewBag.Acao = "Client Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceCliente.GetClienteId(id3);
                ViewBag.Acao = "Client Edit";
            }

            model.ClientesTipos = ServiceClienteTipo.getClienteTipoCombo();
            model.Clientes = ServiceCliente.getCliente();

            //model.Clientes = Pages(model);


            model.menuid = id;
            model.menusubid = id2;


            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult ClienteDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceCliente.DeleteClienteId(id3);
            }

            return Redirect(Domain.Util.config.UrlSite + "Client/Cliente/" + id + "/" + id2);
        }

        public List<Cliente> Pages(ClienteModelView model)
        {
            int skip = 0;
            int take = 10;
            //for (int i = 0; i < 5; i++)
            //{
                var rows = (from x in model.Clientes
                            select x).OrderBy(x => x.clienteid).Skip(skip).Take(take).ToList();

                //do some update stuff with rows
                model.Clientes = rows;
                skip += 10;
            //}

            return model.Clientes;

        }


    }

}
