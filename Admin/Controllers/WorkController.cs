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
    public class WorkController : Controller
    {
        [HttpPost]
        public ActionResult Job(JobModelView model)
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
        public ActionResult Job(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new JobModelView();
            model.projetoid = id3;
            ViewBag.PageTopInformation = "Job Information";
            ViewBag.Acao = "Job View";

            if (id3 != 0)
            {
                model = GetInfoJob(id3, model);
            }

            model.Jobs = ServiceJob.getJob();

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            model.Usuarios = ServiceUsuario.GetUsuariosRecursos();
            model.Fuzzies = ServiceFuzzie.getFuzzieCombo();


            return View(model);
        }

        public JobModelView GetInfoJob(Int16 projetoid, JobModelView model)
        {
            ProjetoModelView ProjetoModel = ServiceProjeto.GetProjetoId(projetoid);

            //VERIFICA SE EXISTE UM JOB PARA ESSE PROJETO.
            //SE EXISTIR LISTA OS JOBS ABAIXO.
            model.Jobs = ServiceJob.getJobByProjetoid(projetoid);
            ViewBag.Acao = "Project ID ";

            model.idiomaidfrom = ProjetoModel.idiomaidfrom;
            model.idiomaidto = ProjetoModel.idiomaidto;

            //pega a descrição do idiomafrom e to
            ViewBag.IdiomaFrom = "From";
            ViewBag.IdiomaTo = "To";

            //busca a descrição do projeto
            ViewBag.ProjetoDescr = ProjetoModel.numeroprojeto;

            //busca os idiomas
            IdiomaModelView IdiomaModel = ServiceIdioma.GetIdiomaId(ProjetoModel.idiomaidfrom);
            ViewBag.IdiomaFrom = IdiomaModel.Sigla;

            IdiomaModel = ServiceIdioma.GetIdiomaId(ProjetoModel.idiomaidto);
            ViewBag.IdiomaTo = IdiomaModel.Sigla;


            //busca a moeda
            MoedaModelView MoedaModel = ServiceMoeda.GetMoedaId(ProjetoModel.moedaidrecebe);
            ViewBag.Moeda = MoedaModel.Descricao;


            //busca o cliente cadastrado nesse projeto
            ClienteModelView ClienteModel = ServiceCliente.GetClienteId(ProjetoModel.clienteid);
            ViewBag.Cliente = ClienteModel.Fantasia;
            model.clienteid = ProjetoModel.clienteid;


            List<ClientePrecoProjeto> LstPreco = ListaPrecos(ProjetoModel.clienteid, model.projetoid);
            model.ClientePrecoProjetos = LstPreco;


            return model;
        }


        public List<ClientePrecoProjeto> ListaPrecos(Int16 clienteid = 0, Int16 projetoid = 0)
        {
            ClientePrecoProjeto Obj = new ClientePrecoProjeto();
            List<ClientePrecoProjeto> LstRet = new List<ClientePrecoProjeto>();
            List<ClientePreco> LstPrecos = ServiceClientePreco.getClientePrecoByClienteId(clienteid);
            foreach (var item in LstPrecos)
            {
                //verifica se o preço foi escohido
                Obj = new ClientePrecoProjeto();
                Obj.fuzzieid = item.fuzzieid;
                Obj.clienteid = item.clienteid;
                Obj.clienteprecoid = item.clienteprecoid;
                Obj.Fuzzie = item.Fuzzie;
                Obj.valorperc = item.Valor;

                Obj.status = VerificaSelecaoPreco(item.clienteid, projetoid, item.clienteprecoid, item.fuzzieid);
                if (Obj.status == 1)
                {
                    Obj.qtdepalavra = GetSelecaoQtde(item.clienteid, projetoid, item.clienteprecoid, item.fuzzieid);
                    LstRet.Add(Obj);
                }
            }
            return LstRet;
        }


        private static int VerificaSelecaoPreco(Int16 clienteid, Int16 projetoid, int clienteprecoid, int fuzzieid)
        {
            return ServiceClientePrecoProjeto.GetVerificaSelecao(clienteid, projetoid, clienteprecoid, fuzzieid).Count;
        }

        private static int GetSelecaoQtde(Int16 clienteid, Int16 projetoid, int clienteprecoid, int fuzzieid)
        {
            return ServiceClientePrecoProjeto.GetSelecaoQtde(clienteid, projetoid, clienteprecoid, fuzzieid);
        }


        private static int VerificaSelecao(Int16 clienteid, Int16 projetoid, Int16 clientecontatoid)
        {
            return ServiceClienteContatoProjeto.GetVerificaSelecao(clienteid, projetoid, clientecontatoid).Count;
        }

        public ActionResult JobDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceJob.DeleteJobId(id3);
            }

            return Redirect(Domain.Util.config.UrlSite + "Work/Job/" + id + "/" + id2);
        }


        public void SaveJobAjax(List<string> data)
        {
            //posição 0 = fuzzieid
            //posição 1 = qtdepalavrajob
            //posicao 2 = valorpalavrajob
            //posição 3 = userid
            JobModelView model = new JobModelView();

            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.fuzzieid = Convert.ToInt16(menuarray[0]);
                model.qtdepalavrajob = Convert.ToInt16(menuarray[1]);
                model.valorporpalavrajob = Convert.ToDouble(menuarray[2]);
                model.userid = Convert.ToInt16(menuarray[3]);
                model.dataprazo = Convert.ToDateTime(menuarray[4]);
                model.projetoid = Convert.ToInt16(menuarray[5]);
                model.idiomaidfrom = Convert.ToInt16(menuarray[6]);
                model.idiomaidto = Convert.ToInt16(menuarray[7]);
                model.clienteid = Convert.ToInt16(menuarray[8]);
                model.user = User.Identity.Name;
                model.jobstatusid = 1; //sempre cria como 1

                ServiceJob.InsertGet(model);

            }
        }

        public JsonResult ListaJobs(int id)
        {
            return Json(ServiceJob.getJobByProjetoid(Convert.ToInt16(id)), JsonRequestBehavior.AllowGet);
        }

        public JsonResult SendEmail(int id, int id2, Int16 id3) //jobid, projetoid, userid
        {
            //informações do email
            UsuarioModelView modelUSU = ServiceUsuario.GetUsuarioId(id3);
            String EmailCopia = Domain.Util.Email.EmailCopiaOculta.ToString();
            String Assunto = "You Have Job | Adara Translations";
            String Texto = "Dear " + modelUSU.apelido + ",<br> we are forwarding your job id " + id + ".<br> Remember to always update your job status. <br><br> Best Regarts <br> Adara Team.";
            String DisplayMail = "Job Mail | Adara Translations";
            Domain.Util.Email mail = new Domain.Util.Email();

            return Json(mail.SendMail(modelUSU.email, EmailCopia, Assunto, Texto, DisplayMail), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteJobs(int id)
        {
            return Json(ServiceJob.DeleteJobId(Convert.ToInt16(id)), JsonRequestBehavior.AllowGet);
        }

      

        [ChildActionOnly]
        public ActionResult GetIdioma(String param)
        {
            IdiomaModelView ModelIdioma = new IdiomaModelView();
            int idiomaid = Convert.ToInt16(param);
            ViewBag.Idioma = "-";
            ModelIdioma = ServiceIdioma.GetIdiomaId(idiomaid);

            if (ModelIdioma != null)
            ViewBag.Idioma = ModelIdioma.Sigla;

            return PartialView("GetIdioma");
        }

        [ChildActionOnly]
        public ActionResult GetHistorico(String param)
        {
            Int16 id = Convert.ToInt16(param);
            List<JobStatusHistorico> lst = ServiceJobStatusHistorico.getJobStatusHistoricoByJobId(id);

            ViewData["result"] = lst;

            return PartialView("GetHistorico");
        }



        [HttpPost]
        public ActionResult JobProgress(JobModelView model)
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
        public ActionResult JobProgress(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0, string str="")
        {
            var model = new JobModelView();
            String JobsBy = "";
            Int16 Projetoid = 0;
            if (str == "j")
            {
                model.jobid = id3;
                model.Jobs = ServiceJob.getJobByJobId(id3);
                Projetoid = GetProjetoId(model.Jobs);
                model = GetInfoJob(Projetoid, model);
                JobsBy = "Project ID " + Projetoid;
            }
            if (str == "p")
            {
                Projetoid = id3;
                model = GetInfoJob(Projetoid, model);
                model.Jobs = ServiceJob.getJobByProjetoid(id3);
                JobsBy = "Project ID " + Projetoid;
            }
            if (str == "u")
            {
                model.userid = id3;
                model.Jobs = ServiceJob.getJobByUserid(id3);
                Projetoid = GetProjetoId(model.Jobs);
                model = GetInfoJob(Projetoid, model);
                model.Jobs = ServiceJob.getJobByUserid(id3);
                JobsBy = "User ID";
            }

            ViewBag.PageTopInformation = "Progress Information";
            ViewBag.Acao = "Job View";

            

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            ViewBag.JobsBy = JobsBy;



            return View(model);
        }


        private Int16 GetProjetoId(List<Job> lst)
        {
            Int16 id = 0;

            foreach (var item in lst)
            {
                id = item.projetoid;
            }

            return id;

        }


    }

}
