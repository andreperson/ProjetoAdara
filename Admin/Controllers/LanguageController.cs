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
    public class LanguageController : Controller
    {
        [HttpPost]
        public ActionResult Idioma(IdiomaModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.idiomaid != 0) //update
                {
                    ServiceIdioma.UpdateIdioma(model);
                }
                else //insert
                {
                    ServiceIdioma.InsertIdioma(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Language/Idioma/" + model.menuid + "/" + model.menusubid);

            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Idioma(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new IdiomaModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceIdioma.GetIdiomaId(id3);  
            }
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            model.Idiomas = ServiceIdioma.getIdioma();

            return View(model);
        }


        public ActionResult IdiomaDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceIdioma.DeleteIdiomaId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Language/Idioma/" + id + "/" + id2);
        }
    }
}