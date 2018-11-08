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
    public class TranstepController : Controller
    {
        [HttpPost]
        public ActionResult Tep(TepModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.Tepid != 0) //update
                {
                    ServiceTep.UpdateTep(model);
                }
                else //insert
                {
                    ServiceTep.InsertTep(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Transtep/Tep/" + model.menuid + "/" + model.menusubid);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Tep(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new TepModelView();

            ViewBag.PageTopInformation = "Transtep Form";
            ViewBag.Acao = "Transtep Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceTep.GetTepId(id3);
                ViewBag.Acao = "Transtep Edit";
            }

            model.Teps = ServiceTep.getTep();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }


        public ActionResult TepDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceTep.DeleteTepId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Transtep/Tep/" + id + "/" + id2);
        }
    }
}
