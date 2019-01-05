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
                model.status = 0;
                if (model.projetoid != 0) //update
                {
                    ServiceProjeto.UpdateProjeto(model);
                }
                else //insert
                {
                    model.projetoid = ServiceProjeto.InsertGetProjeto(model);
                    return Redirect(Domain.Util.config.UrlSite + "Project/Projeto2/" + model.menuid + "/" + model.menusubid + "/" + model.projetoid);
                }
            }

            model.Projetos = ServiceProjeto.getProjeto();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();

            model.Usuarios = GetGerente();

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
            model.ListaPrecos = ServiceListaPreco.getListaPrecoCombo();

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

        public JsonResult ListaContatos(Int16 id = 0)
        {
            return Json(ServiceClienteContato.getClienteContatoByClientId(id), JsonRequestBehavior.AllowGet);
        }

        public void InsertAjax(List<string> data)
        {
            //posição 0 = PROJETOID
            //posição 1 = CLIENTEID
            //posicao 2 = CLIENTECONTATOID
            ClienteContatoProjetoModelView model = new ClienteContatoProjetoModelView();
            for (int i = 0; i < data.Count; i++)
            {
                string[] menuarray = data[i].Split(new Char[] { ':' });
                model.projetoid = Convert.ToInt16(menuarray[0]);
                model.clienteid = Convert.ToInt16(menuarray[1]);
                model.clientecontatoid = Convert.ToInt16(menuarray[2]);

                //verifica se ja existe


                //ServiceUsuarioMenuSub.InsertUsuarioMenuSub(model);
            }
        }


        /// <summary>
        /// INSERE ATIVIDADE EM PROJETO ATIVIDADE
        /// </summary>
        /// <param name="projetoid"></param>
        /// <param name="competenciaid"></param>
        private void InsereCompetencia(Int16 projetoid, Int16 competenciaid)
        {

            ProjetoCompetenciaModelView model = new ProjetoCompetenciaModelView();
            model.projetoid = projetoid;
            model.competenciaid = competenciaid;
            model.status = 1;
            model.user = User.Identity.ToString();

            ServiceProjetoCompetencia.InsertProjetoCompetencia(model);
        }

    }
}
