using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Data.Entities;
using Data.Repository;
using Domain; 

namespace Admin.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public ActionResult Login(User model)
        {
            if (Membership.ValidateUser(model.Email, model.Senha))
            {
                FormsAuthentication.RedirectFromLoginPage(model.Email, true);
                //quando  loga, guarda a informação na tabela login
                model = Domain.Service.CustomMembershipProvider.GetUser(model.Email, model.Senha);
                registralogin(model);
                ViewBag.msg = "";
            }
            else
            {
                ViewBag.msg = "Usuário não encontrado!";
            }

            return View();
        }


        private void registralogin(User model)
        { 
         //guarda login
            Domain.ModelView.LoginModelView login = new Domain.ModelView.LoginModelView();
            login.apelido = User.Identity.Name;
            login.email = model.Email;
            login.origem = "Admin";
            login.apelido = model.Apelido;
            login.userid = model.UserId;
            Domain.Service.ServiceLogin.InsertLogin(login);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Manage()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}
