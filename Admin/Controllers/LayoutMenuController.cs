using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Domain.Entities;
using Servico.Service;

namespace Admin.Controllers
{
    public class LayoutMenuController : Controller
    {

        private int GetUsuaroiTipoId(string user)
        {

            List<User> lstUser = new List<User>();
            lstUser = ServiceUsuario.getUsuariobyEmail(user);
            int tipoid = 0;

            if (lstUser.Count == 1)
            {
                foreach (var item in lstUser)
                {
                    tipoid = item.usuariotipoid;
                }
            }

            return tipoid;
        }


        [ChildActionOnly]
        public ActionResult MenuHeader(Int16 id = 0, Int16 id2 = 0)
        {
            bool passagemok = false;
            var msg = "10";

            LayoutMenuController layout = new LayoutMenuController();
            int tipoid = layout.GetUsuaroiTipoId(User.Identity.Name);

            //List<User> lstUser = new List<User>();
            //lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);


            string path = Request.Path;
            int posic = path.IndexOf("/", 1);
            if (posic > 0)
            {
                string actSolic = path.Substring(1, posic - 1);


                //se nao tem nem menu e nem submenu só libera se for nome
                if (id == 0 & id2 == 0 & actSolic == "Home")
                {
                    //pode passar
                    passagemok = true;

                }

                else if (id != 0 & id2 == 0)//verificando somente o menu
                {
                    //verifica se esse tipo tem acesso ao menu solicitado
                    List<UsuarioMenu> lstUserMenu = ServiceUsuarioMenu.getUsuarioMenuByTipoMenu(tipoid, id);

                    if (lstUserMenu.Count > 0)
                    {
                        //pode passar
                        passagemok = true;
                    }
                }
                else if (id != 0 & id2 != 0) //qdo tem o menu e o submenu
                {
                    //verifica se esse tipo tem acesso ao menu solicitado
                    List<UsuarioMenu> lstUserMenu = ServiceUsuarioMenu.getUsuarioMenuByTipoMenu(tipoid, id);

                    if (lstUserMenu.Count > 0)
                    {
                        //pode passar
                        passagemok = true;
                    }


                    if (passagemok)
                    {
                        //SE CHEGOU AQUI TEM ACESSO AO MENU
                        //VERIFICA SE TEM ACESSO AO SUBMENU
                        List<UsuarioMenuSub> lstUserMenuSub = ServiceUsuarioMenuSub.getUsuarioMenuSubByTipoMenu(tipoid, id2);
                        if (lstUserMenuSub.Count == 0)
                        {
                            //nao pode passar
                            passagemok = false;
                        }

                    }

                }

            }
            else
            {
                if (id == 0 & id2 == 0)
                {
                    //pode passar
                    passagemok = true;
                }

            }

            //CARREGA OS MENUS E SUB QUE PODEM SER VISTOS CONFORME A PERMISSÃO
            //busca o menu
            List<Menu> lstMn = new List<Menu>();
            lstMn = ServiceMenu.getMenu("Delete");

            //busca os usuariostipos que contém os menus permitidos
            List<UsuarioMenu> lstTp = new List<UsuarioMenu>();
            lstTp = ServiceUsuarioMenu.getUsuarioMenuByTipoId(tipoid);

            //pega somente os ids validos
            var lstMenuIdValido = from idmenu in lstTp select idmenu.menuid;


            //compara os ids permitidos com os todos o menus e pega somente os permitidos
            var lstFinal = (from c in lstMn where lstMenuIdValido.Contains(c.menuid) select c).ToList();

            ViewData["result"] = lstFinal;

            ////verifica se o usuário pode acessar esta página ou se está forçando na mão
            //var permissao = from lst in lstFinal where lst.controller == actSolic select lst;

            if (!passagemok)
            {

                Response.Redirect(@Domain.Util.config.UrlSite + "Home/Erro/" + msg);

            }



            return PartialView("MenuHeader");
        }


        //[ChildActionOnly]
        //public ActionResult MenuHeader()
        //{
        //    var msg = "10";
        //    List<User> lstUser = new List<User>();
        //    lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
        //    Int16 tipoid = 0;

        //    if (lstUser.Count == 1)
        //    {
        //        foreach (var item in lstUser)
        //        {
        //            tipoid = item.usuariotipoid;
        //        }
        //    }

        //    //busca o menu
        //    List<Menu> lstMn = new List<Menu>();
        //    lstMn = Domain.Services.ServiceMenu.getMenu();

        //    string path = Request.Path;
        //    int posic = path.IndexOf("/", 1);
        //    if (posic > 0)
        //    {
        //        string actSolic = path.Substring(1, posic - 1);
        //        //busca os usuariostipos que contém os menus permitidos
        //        List<UsuarioMenu> lstTp = new List<UsuarioMenu>();
        //        lstTp = ServiceUsuarioMenu.getUsuarioMenuByTipoId(tipoid);

        //        //pega somente os ids
        //        var lstMenuIdValido = from id in lstTp select id.menuid;

        //        //compara os ids permitidos com os todos o menus e pega somenteos permitidos
        //        var lstFinal = (from c in lstMn where lstMenuIdValido.Contains(c.menuid) select c).ToList();

        //        ViewData["result"] = lstFinal;

        //        //verifica se o usuário pode acessar esta página ou se está forçando na mão
        //        var permissao = from lst in lstFinal where lst.controller == actSolic select lst;

        //        //se não tem permissao, verifica se é um submenu 
        //        if (!permissao.Any())
        //        {
        //            //verifica se é um submenu e se tem permissão
        //            List<MenuSub> lstSub = new List<MenuSub>();
        //            lstSub = ServiceMenuSub.getMenuSubByController(actSolic);
        //            if (lstSub.Count == 0)
        //            {
        //                //se não encontrar aquele submenu não tem acesso
        //                Response.Redirect(@Domain.Util.config.UrlSite + "Home/Erro/" + msg);
        //            }
        //        }
        //    }
        //    else
        //    {
        //        Response.Redirect(@Domain.Util.config.UrlSite + "Home/Erro/" + msg);
        //    }
        //    return PartialView("MenuHeader");
        //}


        [ChildActionOnly]
        public ActionResult MenuSubHeader(Int16 id = 0)
        {
            //VAI MOSTRAR APENAS OS SUBMENUS PERMITIDOS.
            LayoutMenuController layout = new LayoutMenuController();

            int tipoid = layout.GetUsuaroiTipoId(User.Identity.Name);
            //VAI MOSTRAR APENAS OS SUBMENUS PERMITIDOS.
            List<MenuSub> lstFinal = ServiceMenuSub.GetSubMenuPermitido(tipoid, id);

            ViewData["result"] = lstFinal;

            return PartialView("MenuSubHeader");
        }

        [ChildActionOnly]
        public ActionResult VencimentoBuyHeader()
        {
            //List<Compra> lst = new List<Compra>();
            //Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);
            //lst = ServiceCompra.getCompra(repreid,"a");

            //string dthj = Convert.ToString(DateTime.Now).Substring(0, 10);
            //var lsthj = (from x in lst where Convert.ToString(x.DtVencimento).Substring(0,10) == dthj select x.DtVencimento).ToList();

            //ViewBag.Vencimento = lst.Count;
            //ViewBag.VencimentoHoje = lsthj.Count;
            //ViewBag.repreid = repreid;

            return PartialView("VencimentoBuyHeader");
        }

        [ChildActionOnly]
        public ActionResult VencimentoClosingHeader()
        {
            //List<Fechamento> lst = new List<Fechamento>();
            //Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);
            //lst = ServiceFechamento.getFechamento(repreid,"a");

            //string dthj = Convert.ToString(DateTime.Now).Substring(0, 10);
            //var lsthj = (from x in lst where Convert.ToString(x.dataRecebto).Substring(0, 10) == dthj select x.dataRecebto).ToList();

            //ViewBag.Vencimento = lst.Count;
            //ViewBag.VencimentoHoje = lsthj.Count;
            //ViewBag.repreid = repreid;

            return PartialView("VencimentoClosingHeader");
        }

        [ChildActionOnly]
        public ActionResult ApelidoHeader()
        {

            List<User> lstUser = new List<User>();
            lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            string user = "";

            if (lstUser.Count == 1)
            {
                foreach (var item in lstUser)
                {
                    user = item.Apelido;
                }
            }

            ViewBag.Apelido = user;

            return PartialView("ApelidoHeader");
        }

        [ChildActionOnly]
        public ActionResult UserTipoHeader()
        {

            List<User> lstUser = new List<User>();
            lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            string user = "";

            if (lstUser.Count == 1)
            {
                foreach (var item in lstUser)
                {
                    user = item.UsuarioTipo.descricao;
                }
            }

            ViewBag.UserTipoHeader = user;

            return PartialView("UserTipoHeader");
        }

        [ChildActionOnly]
        public ActionResult ImagemHeader()
        {
            List<User> lstUser = new List<User>();
            lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            string img = "";
       

            if (lstUser.Count == 1)
            {
                foreach (var item in lstUser)
                {
                    img = item.imagem;
                }
            }

            if (string.IsNullOrEmpty(img))
            {
                img = "user-default.jpg";
            }

            ViewBag.Img = img;

            return PartialView("ImagemHeader");
        }

        [ChildActionOnly]
        public ActionResult DataInclHeader()
        {

            List<User> lstUser = new List<User>();
            lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            string dataincl = "";
            string mes = "";
            int userid = 0;
            if (lstUser.Count == 1)
            {
                foreach (var item in lstUser)
                {
                    mes = Convert.ToString(item.DataIncl.ToString("MMMM"));
                    mes = (char.ToUpper(mes[0]) + mes.Substring(1));
                    dataincl = Convert.ToString(mes + " de " + item.DataIncl.Year);

                    userid = item.UserId;
                }
            }

            ViewBag.dataincl = dataincl;

            return PartialView("DataInclHeader");
        }

        //pega o usuárioid logado
        [ChildActionOnly]
        public ActionResult UserIdHeader()
        {
            List<User> lst = new List<User>();

            lst = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            int userid = 0;

            foreach (var item in lst)
            {
                userid = item.UserId;
            }


            List<Menu> lstmn = new List<Menu>();

            lstmn = ServiceMenu.getMenuStr("Admin");
            int menuid = 0;

            foreach (var item in lstmn)
            {
                menuid = item.menuid;
            }

            ViewBag.userid = userid;
            ViewBag.menuid = menuid;
            ViewBag.menusubid = 0;

            return PartialView("UserIdHeader");
        }


        //pega o usuárioid logado
        [ChildActionOnly]
        public ActionResult MenuIdHeader()
        {
           

            return PartialView("MenuIdHeader");
        }
    }
}
