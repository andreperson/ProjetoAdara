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
    public class CoinController : Controller
    {
        [HttpPost]
        public ActionResult Moeda(MoedaModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.Moedaid != 0) //update
                {
                    ServiceMoeda.UpdateMoeda(model);
                }
                else //insert
                {
                    ServiceMoeda.InsertMoeda(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Coin/Moeda/" + model.menuid + "/" + model.menusubid);

            }
           
            return View(model);
        }

        [HttpGet]
        public ActionResult Moeda(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new MoedaModelView();
            ViewBag.PageTopInformation = "Coin Form";
            ViewBag.Acao = "Coin Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceMoeda.GetMoedaId(id3);
                ViewBag.Acao = "Coin Edit";
            }
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            model.Moedas = ServiceMoeda.getMoeda();

            return View(model);
        }


        public ActionResult MoedaDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceMoeda.DeleteMoedaId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Coin/Moeda/" + id + "/" + id2);
        }
    }
}
