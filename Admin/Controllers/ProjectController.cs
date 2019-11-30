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
    public class ProjectController : Controller
    {
        [HttpPost]
        public ActionResult Projeto(ProjetoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                Domain.Util.Imagem ImgRet = new Domain.Util.Imagem();
                model.usu = User.Identity.Name;
                if (model.projetoid != 0) //update
                {
                    model.status = 1;
                    ServiceProjeto.UpdateProjeto(model);
                    ViewBag.Acao = "Projeto Salvo Com Sucesso!";
                    return Redirect(Domain.Util.config.UrlSite + "Work/Job/" + model.menuid + "/" + model.menusubid + "/" + model.projetoid);
                }
            }


            model.Usuarios = GetGerente();
            model.Projetos = ServiceProjeto.getProjeto();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.Idiomas = ServiceIdioma.getIdiomaCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();
            model.Competencias = ServiceCompetencia.getCompetencia();
            model.ProjetoTipos = ServiceProjetoTipo.getProjetoTipoCombo();
            model.Projetos = ServiceProjeto.getProjeto();

            ViewBag.MenuId = model.menuid;
            ViewBag.MenuSubId = model.menusubid;
            ViewBag.projetoid = model.projetoid;

            
            return View(model);
        }




        [HttpGet]
        public ActionResult Projeto(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ProjetoModelView();
            ViewBag.PageTopInformation = "Project Form";
            ViewBag.Acao = "Project Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceProjeto.GetProjetoId(id3);
                ViewBag.Acao = "Project Edit";
            }


            model.Usuarios = GetGerente();
            model.Projetos = ServiceProjeto.getProjeto();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.Idiomas= ServiceIdioma.getIdiomaCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();
            model.Competencias = ServiceCompetencia.getCompetencia();
            model.ProjetoTipos = ServiceProjetoTipo.getProjetoTipoCombo();
            model.Projetos = ServiceProjeto.getProjeto();

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.projetoid = model.projetoid;

            return View(model);
        }

       
      


        private List<User> GetGerente()
        {

            List<UsuarioTipo> lstMan = new List<UsuarioTipo>();

            //busca o usuário tipo gerente
            lstMan = ServiceUsuarioTipo.getUsuarioTipo(Domain.Util.config.Gerente.ToString());
            int gerenteid = 0;
            foreach (var item in lstMan)
            {
                gerenteid = item.usuariotipoid;
            }

            return ServiceUsuario.getGerenteCombo(gerenteid);
        }


        public ActionResult ProjetoDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceProjeto.DeleteProjetoId(id);
            }

            return Redirect(Domain.Util.config.UrlSite + "Project/Projeto/" + id + "/" + id2 + "/");
        }

        public JsonResult ListaContatos(Int16 id = 0, Int16 id2=0)
        {
            ClienteContato Obj = new ClienteContato();
            List<ClienteContato> LstRet = new List<ClienteContato>();
            List<ClienteContato> LstContatos = ServiceClienteContato.getClienteContatoByClientId(id);
            foreach (var item in LstContatos)
            {
                //verifica se o contato foi escohido
                Obj = new ClienteContato();
                Obj = item;
                Obj.Status = VerificaSelecao(item.clienteid, id2, item.clientecontatoid);
                LstRet.Add(Obj);
            }
                
            return Json(LstRet, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaPrecos(Int16 id = 0, Int16 id2 = 0)
        {
            ClientePrecoProjeto Obj = new ClientePrecoProjeto();
            List<ClientePrecoProjeto> LstRet = new List<ClientePrecoProjeto>();
            List<ClientePreco> LstPrecos = ServiceClientePreco.getClientePrecoByClienteId(id);
            foreach (var item in LstPrecos)
            {
                //verifica se o preço foi escohido
                Obj = new ClientePrecoProjeto();
                Obj.fuzzieid = item.fuzzieid;
                Obj.clienteid = item.clienteid;
                Obj.clienteprecoid = item.clienteprecoid;
                Obj.Fuzzie = item.Fuzzie;
                Obj.valorperc = item.Valor;

                Obj.status = VerificaSelecaoPreco(item.clienteid, id2, item.clienteprecoid, item.fuzzieid);
                if (Obj.status == 1)
                {
                    Obj.qtdepalavra = GetSelecaoQtde(item.clienteid, id2, item.clienteprecoid, item.fuzzieid);
                }
                LstRet.Add(Obj);
            }

            return Json(LstRet, JsonRequestBehavior.AllowGet);
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

        public void InsertClienteContatoAjax(List<string> data)
        {
            //posição 0 = PROJETOID
            //posição 1 = CLIENTEID
            //posicao 2 = CLIENTECONTATOID
            //posição 3 = TRUE/FALSE
            ClienteContatoProjetoModelView model = new ClienteContatoProjetoModelView();
            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.projetoid = Convert.ToInt16(menuarray[0]);
                model.clienteid = Convert.ToInt16(menuarray[1]);
                model.clientecontatoid = Convert.ToInt16(menuarray[2]);
                bool value = Convert.ToBoolean(menuarray[3]);


                //sempre apaga
                ServiceClienteContatoProjeto.DeleteClienteContatoProjetoId(model.clienteid, model.projetoid, model.clientecontatoid);

                if (value)
                {
                    //verifica se ja existe
                    List<ClienteContatoProjeto> lst = ServiceClienteContatoProjeto.GetVerificaSelecao(model.clienteid, model.projetoid, model.clientecontatoid);
                    if (lst.Count == 0)
                    {
                        ServiceClienteContatoProjeto.InsertClienteContatoProjeto(model);
                    }

                }

            }
        }

        public void InsertClientePrecoAjax(List<string> data)
        {
            //posição 0 = PROJETOID
            //posição 1 = CLIENTEID
            //posicao 2 = CLIENTECONTATOID
            //posição 3 = TRUE/FALSE
            ClientePrecoProjetoModelView model = new ClientePrecoProjetoModelView();
            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.projetoid = Convert.ToInt16(menuarray[0]);
                model.clienteid = Convert.ToInt16(menuarray[1]);
                model.clienteprecoid = Convert.ToInt16(menuarray[2]);
                bool value = Convert.ToBoolean(menuarray[3]);
                model.valorperc = Convert.ToDouble(menuarray[4].Replace(".",","));
                model.qtdepalavra = Convert.ToInt16(menuarray[5]);
                model.fuzzieid = Convert.ToInt16(menuarray[6]);

                //sempre apaga
                ServiceClientePrecoProjeto.DeleteClientePrecoProjetoId(model.clienteid, model.projetoid, model.clienteprecoid);

                if (value)
                {
                    //verifica se ja existe
                    List<ClientePrecoProjeto> lst = ServiceClientePrecoProjeto.GetVerificaSelecao(model.clienteid, model.projetoid, model.clienteprecoid, model.fuzzieid);
                    if (lst.Count == 0)
                    {
                        ServiceClientePrecoProjeto.InsertClientePrecoProjeto(model);
                    }

                }

            }
        }



        public JsonResult CreateProjectAjax(int data)
        {
            ProjetoModelView model = new ProjetoModelView();
            model.menuid = Convert.ToInt16(data);
            model.status = 0;
            model.DataIncl = DateTime.Now;
            model.usu = User.Identity.Name;
            model.projetoid = ServiceProjeto.InsertGetProjeto(model);

            //monta o numero do projeto
            model.numeroprojeto = GetProjectNumber(model.projetoid);
            ServiceProjeto.UpdateProjeto(model);

            return Json(model.projetoid, JsonRequestBehavior.AllowGet);
        }


        private string GetProjectNumber(Int16 id)
        {
            string idformatado = string.Empty;
            int QtdeZeros = id.ToString().Length;
            string zeros = string.Empty;
            for (int i = QtdeZeros; i < 5; i++)
            {
                zeros += "0";
            }

            idformatado = "P" + zeros + id.ToString() + DateTime.Now.Year.ToString().Substring(2);

            return idformatado;
        }

        public ActionResult Lista(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            ProjetoModelView model = new ProjetoModelView();
            model.Projetos = ServiceProjeto.getProjeto();
            model.menuid = id;
            model.menusubid = 0;

            model.menuid = id;
            model.menusubid = id2;

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            return View(model);
        }

    }
}
