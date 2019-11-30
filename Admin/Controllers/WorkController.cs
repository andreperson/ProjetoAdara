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
                model.status = 1;
                if (model.jobid != 0) //update
                {
                    ServiceJob.UpdateJob(model);
                }
                else //insert
                {
                    ServiceJob.InsertJob(model);
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
            ViewBag.PageTopInformation = "Project Information";
            ViewBag.Acao = "Job View";

            if (id3 != 0)
            {
                ProjetoModelView ProjetoModel = ServiceProjeto.GetProjetoId(id3);

                

                //VERIFICA SE EXISTE UM JOB PARA ESSE PROJETO.
                //SE EXISTIR LISTA OS JOBS ABAIXO.
                model.Jobs = ServiceJob.getJobByProjetoid(id3);
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

                ServiceJob.InsertJob(model);

            }
        }
    }
}
