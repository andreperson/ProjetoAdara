using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Entities;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class MeniController : Controller
    {
        [HttpPost]
        public ActionResult Menu(MenuModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                int menuid = model.menuid;
                if (model.menuidedit != 0) //update
                {
                    model.menuid = model.menuidedit;
                    ServiceMenu.UpdateMenu(model);
                }
                else //insert
                {
                    ServiceMenu.InsertMenu(model);
                }


                return Redirect(Domain.Util.config.UrlSite + "Meni/Menu/" + menuid + "/" + model.menusubid);

            }

            model.menus = ServiceMenu.getMenu();

            return View(model);
        }

        [HttpGet]
        public ActionResult Menu(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new MenuModelView();
            ViewBag.PageTopInformation = "Menu";
            ViewBag.Acao = "Menu Add";
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceMenu.GetMenuId(id3);
                model.menuidedit = id3;
                ViewBag.Acao = "Menu Edit";
            }

            model.menus = ServiceMenu.getMenu("Delete");
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            return View(model);
        }


        public ActionResult MenuDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            //busca o menu admin
            int menuadmin = GetMenuAdmin();

            if (id3 != 0 & id3 != menuadmin)
            {
                //exclui registro
                ServiceMenu.DeleteMenuId(id3);
            }

            return Redirect(Domain.Util.config.UrlSite + "Meni/Menu/" + menuadmin + "/0/0");
        }


        private int GetMenuAdmin()
        {
            int id = 0;

            List<Menu> lst = new List<Menu>();

            lst = ServiceMenu.getMenuStr("Admin");

            foreach (var item in lst)
            {
                id = item.menuid;
            }


            return id;

        }


    }
}
