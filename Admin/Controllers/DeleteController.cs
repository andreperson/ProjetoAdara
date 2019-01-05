﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing; 
using Domain.Entities;

using Domain.ModelView;
 

namespace Admin.Controllers
{
    public class DeleteController : Controller
    {
        [HttpPost]
        public ActionResult Deletar(DeleteModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                return Redirect(Domain.Util.config.UrlSite + model.Control + "/" + model.Act + "/" + model.Id + "/" + model.Id2);
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Deletar(Int16 id = 0, Int16 id2=0, Int16 id3=0, string id4= "")
        {
            var model = new DeleteModelView();
            model.Id = id;
            model.Id2 = id2.ToString();
            model.Id3 = id3.ToString();
            model.Descricao = id4.ToString();
            model.MenuId = id;
            model.MenuSubId = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            ViewBag.PageTopInformation = "Delete Form";
            ViewBag.Acao = "Removing Record";


            return View(model);
        }

    }
}
