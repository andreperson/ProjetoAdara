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
                model.status = Convert.ToInt16(model.statusb);
                if (model.menuidedit != 0) //update
                {
                    ServiceMenu.UpdateMenu(model);
                }
                else //insert
                {
                    ServiceMenu.InsertMenu(model);
                }

                //pega o menuid para o redirectd
                int menuclique = 0;
                List<Menu> lstmn = ServiceMenu.getMenuStr("Admin");
                foreach (Menu item in lstmn)
                {
                    menuclique = item.menuid;
                }


                return Redirect(Domain.Util.config.UrlSite + "Meni/Menu/" + menuclique + "/" + model.menusubid);

            }

            model.menus = ServiceMenu.getMenu();

            return View(model);
        }

        [HttpGet]
        public ActionResult Menu(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new MenuModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceMenu.GetMenuId(id3);
                model.menuidedit = id3;
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

            List<Menu> lst = new List<Data.Entities.Menu>();

            lst = ServiceMenu.getMenuStr("Admin");

            foreach (var item in lst)
            {
                id = item.menuid;
            }


            return id;

        }


    }
}
