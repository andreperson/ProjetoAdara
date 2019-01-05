using System.Web.Mvc;
using System.Web.Security;
using Domain.Entities;
using Domain.ModelView;
using Servico.Service;

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
                model =  CustomMembershipProvider.GetUser(model.Email, model.Senha);
                registralogin(model);
                ViewBag.msg = "";
            }
            else
            {
                ViewBag.msg = "User not found!";
            }

            return View();
        }


        private void registralogin(User model)
        { 
         //guarda login
            LoginModelView login = new LoginModelView();
            login.apelido = User.Identity.Name;
            login.email = model.Email;
            login.origem = "Admin";
            login.apelido = model.Apelido;
            login.userid = model.UserId;
            ServiceLogin.InsertLogin(login);
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
