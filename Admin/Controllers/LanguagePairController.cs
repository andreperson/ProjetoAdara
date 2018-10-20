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
                model.status = Convert.ToInt16(model.statusb);
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
            
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceParIdioma.GetParIdiomaId(id3);  
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