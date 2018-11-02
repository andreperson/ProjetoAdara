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
    public class ResourceController : Controller
    {
        [HttpPost]
        public ActionResult Recurso(RecursoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.useralt = User.Identity.Name;
                model.status = 1;
                if (model.recursoid != 0) //update
                {
                    ServiceRecurso.UpdateRecurso(model);
                }
                else //insert
                {
                    ServiceRecurso.InsertRecurso(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Resource/Recurso/" + model.menuid + "/" + model.menusubid);

            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Recurso(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new RecursoModelView();
            ViewBag.PageTopInformation = "Resource Form";
            ViewBag.Acao = "Resource Add";
            List<Recurso> lst = new List<Data.Entities.Recurso>();

            if (id3 != 0)
            {
                //busca as informações do usuario
                lst = ServiceRecurso.getRecurso(id3);

                foreach (var item in lst)
                {
                    model.competenciaid = item.competenciaid;
                    model.recursoid = item.RecursoId;
                    model.userid = item.userid;
                }

                ViewBag.Acao = "Resource Edit";
            }

            ViewBag.userid = id3;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            model.Recursos = ServiceRecurso.getRecurso();
            model.Usuarios = ServiceUsuario.getUsuarioCombo();
            model.Competencias = ServiceCompetencia.getCompetencia();

            return View(model);
        }


        public ActionResult RecursoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceRecurso.DeleteRecursoId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Resource/Recurso/" + id + "/" + id2);
        }


        public JsonResult ListaRecursosPorUser(string id)
        {
            return Json(ServiceRecurso.getRecurso(Convert.ToInt16(id)), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ExcluirRecurso(string id, string id2)
        {
            ServiceRecurso.DeleteRecurso(Convert.ToInt16(id), Convert.ToInt16(id2));
            return Json(ServiceRecurso.getRecurso(Convert.ToInt16(id)), JsonRequestBehavior.AllowGet);
        }


    }
}
