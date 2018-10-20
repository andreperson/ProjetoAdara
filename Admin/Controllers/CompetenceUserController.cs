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
    public class CompetenceUserController : Controller
    {
        [HttpPost]
        public ActionResult Competencia_Usuario(CompetenciaUsuarioModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.useralt = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.competenciauserid != 0) //update
                {
                    ServiceCompetenciaUsuario.UpdateCompetenciaUser(model);
                }
                else //insert
                {
                    ServiceCompetenciaUsuario.InsertCompetenciaUser(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "CompetenceUser/CompetenciaUsuario/" + model.menuid + "/" + model.menusubid + "/" + model.competenciaid);

            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Competencia_Usuario(Int16 id = 0, Int16 id2=0, Int16 id3=0)
        {
            var model = new CompetenciaUsuarioModelView();
            model.Competencias_Usuarios = ServiceCompetenciaUsuario.getCompetenciaUser();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceCompetenciaUsuario.GetCompetenciaUserId(id3);  
            }
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }

        public JsonResult GetUsuarioFind(string id, string id2)
        {
            return Json(ServiceUsuario.getUsuarioByName(id.ToString()), JsonRequestBehavior.AllowGet);
        }


        public ActionResult Competencia_UsuarioDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id != 0)
            {
                //exclui registro
                ServiceCompetenciaUsuario.DeleteCompetenciaUserId(id); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Competence_User/Competencia_User/" + id + "/" + id2 + "/" + id3);
        }
    }
}
