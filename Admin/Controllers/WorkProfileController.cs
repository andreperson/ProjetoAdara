using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Domain.Entities;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class WorkProfileController : Controller
    {
        [HttpPost]
        public ActionResult JobProfile(JobModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.jobstatusid = 1;
                if (model.jobid != 0) //update
                {
                    ServiceJob.UpdateJob(model);
                }
                else //insert
                {
                    ServiceJob.InsertGet(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Work/Job/" + model.menuid + "/" + model.menusubid);

            }
            model.Jobs = ServiceJob.getJob();

            return View(model);
        }

        [HttpGet]
        public ActionResult JobProfile(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            var model = new JobModelView();
            model.projetoid = id3;
            ViewBag.PageTopInformation = "Your Activities";
            ViewBag.Acao = "Job View";

            int UserId = GetUsuario(User.Identity.Name.ToString());
            //busca todas as jobs desse usuário
            model.Jobs = ServiceJob.getJobByUserid(UserId);
            model.JobStatus = ServiceJobStatus.getJobStatus();

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }

        private int GetUsuario(string email)
        {
            int userid = 0;
            List<User> lst = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            foreach (var item in lst)
            {
                userid = item.UserId;
            }

            return userid;
        }



        [HttpGet]
        public ActionResult JobProfileHome(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new JobModelView();
            model.projetoid = id3;
            ViewBag.PageTopInformation = "Profile and Activities";
            ViewBag.Acao = "Job View";

            ViewBag.Apelido = GetUserName(User.Identity.Name);

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }


        private String GetUserName(string email)
        {
            String Apelido = "-";
            List<User> lst = ServiceUsuario.getUsuariobyEmail(email);

            foreach (var item in lst)
            {
                Apelido = item.Apelido;
            }

            return Apelido;
        }


        //salva o job status e retorna o status novo para ser setado no html
        public JsonResult SaveJobAjax(int id, Int16 id2)
        {
            //posição 0 = statusid
            //posição 1 = jobid
            
            int stid = id;
            Int16 jobid = id2;


            //busca o jobid;
            JobModelView model = new JobModelView();
            model = ServiceJob.GetJobId(jobid);

            //set novo id 
            model.jobstatusid = stid;
            //salva
            ServiceJob.UpdateJob(model);
           

            //insere o novo status
            JobStatusHistoricoModelView modelhist = new JobStatusHistoricoModelView();
            modelhist.user = User.Identity.Name;
            modelhist.jobid = jobid;
            modelhist.jobstatusid = model.jobstatusid;
            modelhist.dataincl = DateTime.Now;
            ServiceJobStatusHistorico.InsertJobStatusHistorico(modelhist);

            //busca a descrição do status
            JobStatusModelView MdSt = ServiceJobStatus.GetJobStatusId(Convert.ToInt16(stid));
            String StatusDescricao = MdSt.descricao;

            //pega o apelido do usuário
            String UserName = GetUsuarioName(User.Identity.Name.ToString());

            //manda email avisando o manager.
            //busca o manager
            List<User> lst = new List<Domain.Entities.User>();
            lst = ServiceUsuario.getUsuarioRecebeEmails(1);

            foreach (var item in lst)
            {
                //manda emails
                if(!String.IsNullOrEmpty(item.Email))
                {
                    String EmailCopia = Domain.Util.Email.EmailCopiaOculta.ToString();
                    String Assunto = "Job Update | Adara Translations";
                    String Texto = "Dear " + item.Apelido + ",<br> our " + UserName + " resource, updated job id " + id + " to " + StatusDescricao + " <br><br> Best Regarts <br> Adara Team.";
                    String DisplayMail = "Job Mail | Adara Translations";
                    Domain.Util.Email mail = new Domain.Util.Email();
                    mail.SendMail(item.Email, EmailCopia, Assunto, Texto, DisplayMail);
                }
                
            }

            //retorna a busca com o novo id
            return Json(ServiceJob.getJobByJobId(Convert.ToInt16(jobid)), JsonRequestBehavior.AllowGet);

        }

        private String GetUsuarioName(string email)
        {
            String Nome = String.Empty;
            List<User> lst = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            foreach (var item in lst)
            {
                Nome = item.Apelido;
            }

            return Nome;
        }


    }

}
