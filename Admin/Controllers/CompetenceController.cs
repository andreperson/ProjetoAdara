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
    public class CompetenceController : Controller
    {
        [HttpPost]
        public ActionResult Competencia(CompetenciaModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.competenciaid != 0) //update
                {
                    ServiceCompetencia.UpdateCompetencia(model);
                }
                else //insert
                {
                    ServiceCompetencia.InsertCompetencia(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Competence/Competencia/" + model.menuid + "/" + model.menusubid);

            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Competencia(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new CompetenciaModelView();
            

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceCompetencia.GetCompetenciaId(id3);  
            }
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            model.Competencias = ServiceCompetencia.getCompetencia();
            return View(model);
        }


        public ActionResult CompetenciaDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceCompetencia.DeleteCompetenciaId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Competence/Competencia" + id + "/" + id2 + "/" + id3);
        }
    }
}
