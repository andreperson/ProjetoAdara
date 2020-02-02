using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Entities;
using Servico.Service;
using Domain.ModelView;




namespace Admin.Controllers
{
    public class MeniSubController : Controller
    {
        [HttpPost]
        public ActionResult MenuSub(MenuSubModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                //busca o nome do menu para ser usado na action;
                MenuModelView menumd = ServiceMenu.GetMenuId(model.menuid);
                model.menuact = menumd.descricao;

                if (model.menusubid != 0) //update
                {
                    ServiceMenuSub.UpdateMenuSub(model);
                }
                else //insert
                {
                    ServiceMenuSub.InsertMenuSub(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "MeniSub/MenuSub/" + model.menuid_click + "/" + model.menusubid_click
                    );

            }

            model.menussubs = ServiceMenuSub.getMenuSubAll();
            model.menus = ServiceMenu.getMenu();

            return View(model);
        }

        [HttpGet]
        public ActionResult MenuSub(Int16 id = 0, Int16 id2=0, Int16 id3= 0)
        {
            var model = new MenuSubModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceMenuSub.GetMenuSubId(id3);
               
            }

            model.menus = ServiceMenu.getMenu();
            model.menussubs = GetMenuSubByMenuid(model.menus);
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid_click = id;
            model.menusubid_click = id2;


            //o menu que esta sendo editado fica em model.menuid
            //o submenu que esta sendo editado fica em model.submenuid

            //o menu do click fica em viewbag menuid e submenuid


            return View(model);
        }


        private List<MenuSub> GetMenuSubByMenuid(List<Menu> lstMenu)
        {
            List<MenuSub> lstRet = new List<MenuSub>();
            List<MenuSub> lst = new List<MenuSub>();
            foreach (Menu item in lstMenu)
            {
                //busca os submenus deste menu
                lst = ServiceMenuSub.getMenuSubByMenuId(item.menuid);
                if (lst.Count > 0)
                {
                    foreach (MenuSub itemsb in lst)
                    {
                        itemsb.descricaomenu = item.descricao;
                        itemsb.icone = item.icone;
                    }
                    lstRet.AddRange(lst);
                }
            }
            
            return lstRet;
        }


        private List<MenuSub> GetMenuSubByMenuid(Int16 menuid)
        {
            List<MenuSub> lstRet = new List<MenuSub>();
            List<MenuSub> lst = new List<MenuSub>();
             //busca os submenus deste menu
                lst = ServiceMenuSub.getMenuSubByMenuId(menuid);
                if (lst.Count > 0)
                {
                    foreach (MenuSub itemsb in lst)
                    {
                        itemsb.descricaomenu = itemsb.descricao;
                        itemsb.icone = itemsb.icone;
                    }
                    lstRet.AddRange(lst);
                }
            

            return lstRet;
        }


        public ActionResult MenuSubDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceMenuSub.DeleteMenuSubId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "MeniSub/MenuSub/" + id + "/" + id2);
        }

    }
}

