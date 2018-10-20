﻿using System;
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
                model.status = Convert.ToInt16(model.statusb);
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
        public ActionResult Cliente(Int16 id = 0, Int16 id2=0, Int16 id3 =0)
        {
            var model = new ClienteModelView();
            
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceCliente.GetClienteId(id3);  
            }

            model.ClientesTipos = ServiceClienteTipo.getClienteTipoCombo();
            model.Clientes = ServiceCliente.getCliente();

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

            return Redirect(Domain.Util.config.UrlSite + "Client/Cliente/" + id + "/" + id2 + "/" + id3);
        }
    }
}
