using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;
using Domain.Entities;

namespace Admin.Controllers
{
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult Usuario(UsuarioModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {

                Domain.Util.Imagem ImgRet = new Domain.Util.Imagem();

                //faz o upload da imagem
                if (model.imagem != null)
                {
                    ImgRet = Domain.Util.Upload.ImagemUpload(model.imagem, "usuario");
                }
                else
                {
                    ImgRet.Ok = true;
                }
                
                String msg = string.Empty;
                if (!ImgRet.Ok)
                {
                    msg = ImgRet.Mensagem;
                    return Redirect(Domain.Util.config.UrlSite + "User/Usuario/" + model.menuid + "/" + model.menusubid + "/" + model.userid + HttpUtility.UrlEncode(msg));
                }
                else
                {
                    model.useralt = User.Identity.Name;
                    model.status = Convert.ToInt16(model.statusb);
                    model.recebeemails = Convert.ToInt16(model.recebeemailb);
                    //verifica se o email usuario já existe
                    ViewBag.msg = getUser(model.email, model.userid);
                    if (!string.IsNullOrEmpty(ViewBag.msg))
                    {
                        return Redirect(Domain.Util.config.UrlSite + "User/Usuario/0/" + model.menuid + "/" + model.menusubid +  HttpUtility.UrlEncode(ViewBag.msg));
                    }
                    else
                    {

                        if (model.userid != 0) //update
                        {
                            ServiceUsuario.UpdateUsuario(model);
                        }
                        else //insert
                        {
                            ServiceUsuario.InsertUsuario(model);
                        }
                    }
                }
                return Redirect(Domain.Util.config.UrlSite + "User/Usuario/" + model.menuid + "/" + model.menusubid);
            }

            //Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);
            //model.Representantes = ServiceRepresentante.getRepresentante(repreid);
            //ViewBag.repreid = repreid;

            model.Usuarios = ServiceUsuario.getUsuarioAll();

            //verifica se o usuário atual é admin
            bool useradmin = GetUserAdmin(User.Identity.Name);
            model.UsuariosTipos = ServiceUsuarioTipo.getUsuarioTipo(useradmin);


            return View(model);
        }

        //verifica se usuário ja existe
        private static string getUser(string email, int userid)
        {
            string msg = "";

            List<User> lst = new List<User>();

            lst = ServiceUsuario.getUsuariobyEmail(email);

            foreach (var item in lst)
            {
                if (userid == 0)
                {
                    msg = "Já existe um usuário com este email cadastrado!";
                }
                else if (item.UserId != userid)
                {
                    msg = "Já existe um usuário com este email cadastrado!";
                }
            }

            return msg;
        }

        [HttpGet]
        public ActionResult Usuario(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            ViewBag.PageTopInformation = "User Form";
            ViewBag.Acao = "User Add";
            var model = new UsuarioModelView();
            
            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceUsuario.GetUsuarioId(id3);
                ViewBag.Acao = "User Edit";
            }

            //verifica se o usuário atual é admin
            bool useradmin = GetUserAdmin(User.Identity.Name);

            model.Usuarios = ServiceUsuario.getUsuarioAll();

            //model.Usuarios = ServiceUsuario.getUsuarioAll(repreid);
            model.UsuariosTipos = ServiceUsuarioTipo.getUsuarioTipo(useradmin);
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;



            return View(model);
        }

        private static bool GetUserAdmin(string user)
        {
            bool ret = false;

            List<User> lst = new List<User>();
            lst = ServiceUsuario.getUsuariobyEmail(user);

            foreach (var item in lst)
            {
                if (item.UsuarioTipo.usuariotipoid == 1)
                    ret = true;
            }

            return ret;

        
        }

        public ActionResult UsuarioDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceUsuario.DeleteUsuarioId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "User/Usuario/" + id + "/" + id2);
        }
    }
}
