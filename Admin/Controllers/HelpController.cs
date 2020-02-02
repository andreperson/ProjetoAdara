using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;

namespace Admin.Controllers
{
    public class HelpController : Controller
    {
        [HttpPost]
        public ActionResult Ajuda(AjudaModelView model)
        {

            return View(model);
        }

        [HttpGet]
        public ActionResult Ajuda(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            AjudaModelView model = new AjudaModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                /// model = ServiceAjuda.GetAjudaId(id3);  
            }

            model.Menus = ServiceMenu.getMenu();
            model.MenuSubs = GetMenuSUb();
            model.Ajudas = ServiceHelp.getHelp(true);
            model.menuid_click = id;
            model.menusubid_click = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }

        //pega a lista de menus para montar o view 
        private List<Domain.Entities.MenuSub> GetMenuSUb()
        {
            List<Domain.Entities.MenuSub> lst = ServiceMenuSub.getMenuSub();
            List<Domain.Entities.MenuSub> newLst = new List<Domain.Entities.MenuSub>();
            Domain.Entities.MenuSub obj = new Domain.Entities.MenuSub();

            foreach (var item in lst)
            {
                obj = new Domain.Entities.MenuSub();
                obj = item;
                obj.view = "hidden";
                //verifica se esse item possui help cadastrado
                List<Domain.Entities.Help> lstH= ServiceHelp.getHelByMenuSubId(item.menusubid);
                if (lstH.Count > 0)
                {
                    obj.view = "visible";
                }
                newLst.Add(obj);
            }

            return newLst;
        }


        [HttpPost]
        public ActionResult AjudaEdit(AjudaModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

           

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.helpid != 0) //update
                {
                    ServiceHelp.UpdateHelp(model);
                }
                else
                {
                    ServiceHelp.InsertHelp(model);
                }
            }

            model.Ajudas = ServiceHelp.getHelp();

            return Redirect(Domain.Util.config.UrlSite + "Help/Ajuda/" + model.menuid_click + "/" + model.menusubid_click);



        }

        [HttpGet]
        public ActionResult AjudaEdit(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            AjudaModelView model = new AjudaModelView();
            List<Domain.Entities.Help> lst = new List<Domain.Entities.Help>();

            ViewBag.PageTopInformation = "Help Form";
            ViewBag.Acao = "Help Edit";

            if (id3 != 0)
            {
                //busca as informações para edição
                lst = ServiceHelp.getHelByMenuSubId(id3);

                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        model.menuid = item.menuid;
                        model.menusubid = item.menusubid;
                        model.helpid = item.helpid;
                        model.descricao = item.descricao;
                        model.titulo = item.titulo;
                    }
                }


                //nao encontrou registros para editar
                List<Domain.Entities.MenuSub> lstSub= ServiceMenuSub.getMenuSubId(id3);
                foreach (var item in lstSub)
                {
                    model.menusubid = item.menusubid;
                    model.menuid = item.menuid;
                    ViewBag.MenuSubDescricao = item.descricao;
                    ViewBag.MenuDescricao = item.menuact;
                }

            }


            model.Ajudas = ServiceHelp.getHelp(true);
            model.menuid_click = id;
            model.menusubid_click= id2;

            return View(model);
        }

        [HttpGet]
        public ActionResult AjudaView(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            AjudaModelView model = new AjudaModelView();

            ViewBag.PageTopInformation = "Help Info";
            ViewBag.Acao = "Help View";

            if (id3 != 0)
            {
                //busca as informações para visualizar
                List<Domain.Entities.Help> lst = ServiceHelp.getHelByMenuSubId(id3);

                if (lst.Count > 0)
                {
                    foreach (var item in lst)
                    {
                        model.helpid = item.helpid;
                        model.menuid = item.menuid;
                        model.menusubid = item.menusubid;
                        model.titulo = item.titulo;
                        model.descricao = item.descricao;
                        model.descricao = item.descricao;
                        model.menuid_click = id;
                        model.menusubid_click = id2;
                    }
                }
                else
                {
                    model.titulo = "This item has no help yet";
                }
            }

            return View(model);
        }


        public ActionResult AjudaDelete(Int16 id = 0)
        {
            if (id != 0)
            {
                //exclui registro
                // ServiceAjuda.DeleteAjudaId(id); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Help/Ajuda");
        }




    }
}
