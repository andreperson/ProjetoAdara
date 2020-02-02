using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Entities;
using Domain.ModelView;
using Servico.Service;

namespace Admin.Controllers
{
    public class ProfileController : Controller
    {
        [HttpPost]
        public ActionResult Perfil(UsuarioModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            List<User> lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            UsuarioModelView modelBD = GetUser(lstUser);

            //pega as informações da tela e atualizar o model que veio do banco para salvar
            modelBD.apelido = model.apelido;
            modelBD.nome = model.nome;
            modelBD.sobrenome = model.sobrenome;
            modelBD.endereco = model.endereco;
            modelBD.cidade = model.cidade;
            modelBD.pais = model.pais;
            modelBD.CEP = model.CEP;
            modelBD.about = model.about;
            modelBD.dtnasc = model.dtnasc;
            modelBD.curso = model.curso;
            modelBD.instituicao = model.instituicao;
            modelBD.formacao = model.formacao;
            modelBD.recebeemails = model.recebeemails;
            ServiceUsuario.UpdateUsuario(modelBD);

            return Redirect(Domain.Util.config.UrlSite + "Profile/Perfil/" + model.menuid + "/" + model.menusubid);


            //modelBD.JobStatus = MontaQtdesJobs(model.userid);

            //return View(modelBD);
        }

        [HttpGet]
        public ActionResult Perfil(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new UsuarioModelView();
            ViewBag.PageTopInformation = "Your Profile";
            ViewBag.Acao = "Profile View";
            List<User> lstUser = ServiceUsuario.getUsuariobyEmail(User.Identity.Name);
            model = GetUser(lstUser);

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;



            model.JobStatus = MontaQtdesJobs(model.userid); 
            return View(model);
        }


        private List<JobStatus> MontaQtdesJobs(int userid)
        {

            //monta as qtdades de jobs de acordo com o status.
            List<JobStatus> lst = GetJobStatusAll(); //pego todos os status cadastrados para não faltar nenhum
            List<Job> lstJob = new List<Job>();
            List<JobStatus> lstShow = new List<JobStatus>();
            JobStatus ObjShow = new JobStatus();
            foreach (var item in lst)
            {
                //para cada um dos status eu pego a qtde atribuída para esse usuário
                lstJob = new List<Job>();
                lstJob = GetJobStatusByUserId(item.jobstatusid, userid);
                ObjShow = new JobStatus();
                ObjShow.descricao = item.descricao;
                ObjShow.Status = lstJob.Count;
                lstShow.Add(ObjShow);
            }

            return lstShow;

        }

        private static List<JobStatus> GetJobStatusAll()
        {
            return ServiceJobStatus.getJobStatus(true);
        }

        //busca o que o usuário tem de job por status
        private static List<Job> GetJobStatusByUserId(int jobstatusid, int userid)
        {
            List<Job> lstJob = ServiceJob.getJobByStatusUserid(jobstatusid, userid);

            return lstJob;
        }



        private UsuarioModelView GetUser(List<User> lst)
        {
            UsuarioModelView model = new UsuarioModelView();

            foreach (var item in lst)
            {
                model.about = item.About;
                model.apelido = item.Apelido;
                model.arquivoimagem = item.imagem;
                model.CEP = item.CEP;
                model.cidade = item.Cidade;
                model.dataalt = DateTime.Now;
                model.dataincl = item.DataIncl;
                model.email = item.Email;
                model.endereco = item.Endereco;
                model.nome = item.Nome;
                model.pais = item.Pais;
                model.sobrenome = item.SobreNome;
                model.dtnasc = item.dtnasc.ToString().Substring(0,10);
                model.curso = item.curso;
                model.instituicao = item.instituicao;
                model.status = item.Status;
                model.userid = item.UserId;
                model.senha = item.Senha;
                model.usuariotipoid = item.usuariotipoid;
                model.formacao = item.formacao;
                model.useralt = User.Identity.Name;
                model.recebeemails = item.recebeemails;
                int anonasc = Convert.ToDateTime(item.dtnasc).Year;
                int dtshow = DateTime.Now.Year - anonasc -1;


                if(DateTime.Today.Month >= Convert.ToDateTime(item.dtnasc).Month)
                {
                    if (DateTime.Today.Day >= Convert.ToDateTime(item.dtnasc).Day)
                    {
                        dtshow += 1;
                    }
                }
                ViewBag.Niver = dtshow;
            }

            return model;
        }


    }

}
