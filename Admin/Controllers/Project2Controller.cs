using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Routing;
using Data.Entities;
using Data.Repository;
using Domain.ModelView;
using Domain.Service;

namespace Admin.Controllers
{
    public class Project2Controller : Controller
    {
        [HttpPost]
        public ActionResult Projeto2(ProjetoModelView model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                Domain.Util.Imagem ImgRet = new Domain.Util.Imagem();
                //faz o upload da imagem



                model.usu = User.Identity.Name;
                model.status = Convert.ToInt16(model.statusb);
                if (model.projetoid != 0) //update
                {
                    ServiceProjeto.UpdateProjeto(model);
                }
                else //insert
                {
                    ServiceProjeto.InsertProjeto(model);
                }

                return Redirect(Domain.Util.config.UrlSite + "Project/Projeto/" + model.menuid + "/" + model.menusubid);

            }

            model.Projetos = ServiceProjeto.getProjeto();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.ParIdiomas = ServiceParIdioma.getParIdiomaCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();

            model.Usuarios = GetGerente();

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


        [HttpGet]
        public ActionResult Projeto2(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new ProjetoModelView();

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceProjeto.GetProjetoId(id3);
            }
            else
            {
                return Redirect(Domain.Util.config.UrlSite + "Project/Projeto/" + model.menuid + "/" + model.menusubid + "/" + model.projetoid);
            }

            //VERIFICA SE EXISTE UMA LISTA DE PREÇOS POR CLIENTES
            model.ClientePrecos = ServiceClientePreco.getClientePreco(model.clienteid, model.paridiomaid);
            string cliente = string.Empty;
            string paridioma = string.Empty;

            if (model.ClientePrecos.Count > 0)
            {
                foreach (var item in model.ClientePrecos)
                {
                    cliente = item.Cliente.Fantasia;
                    paridioma = item.ParIdioma.Descricao;
                }

                ViewBag.Cliente = "Lista de Preços por Cliente: " + cliente + " " + paridioma;

            }

            model.Usuarios = GetGerente();
            model.Projetos = ServiceProjeto.getProjeto();
            model.Clientes = ServiceCliente.getClienteCombo();
            model.ParIdiomas = ServiceParIdioma.getParIdiomaCombo();
            model.Moedas = ServiceMoeda.getMoedaCombo();
            model.Competencias = ServiceCompetencia.getCompetencia();

            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.projetoid = model.projetoid;

            return View(model);
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


        public JsonResult GetAtividade(string id, string id2, string id3)
        {
            Int16 projetoid = Convert.ToInt16(id);
            Int16 atvid = Convert.ToInt16(id2);


            if (!string.IsNullOrEmpty(id3))
            {
                //apaga a atividade escolhida
                ServiceProjetoCompetencia.DeleteProjetoCompetenciaId(projetoid, atvid);

                InsereCompetencia(projetoid, atvid);
            }


            //busca todas desse projeto
            Domain.Consumo.ProjetoCompetenciaRepository rep = new Domain.Consumo.ProjetoCompetenciaRepository();
            return Json(rep.getProjetoCompetenciaDescricao(projetoid), JsonRequestBehavior.AllowGet);
        }


        public JsonResult ExcluirAtividade(string id, string id2)
        {
            Int16 projetoid = Convert.ToInt16(id);
            Int16 atvid = Convert.ToInt16(id2);


            ServiceProjetoCompetencia.DeleteProjetoCompetenciaId(projetoid, atvid);


            //busca todas desse projeto
            Domain.Consumo.ProjetoCompetenciaRepository rep = new Domain.Consumo.ProjetoCompetenciaRepository();
            return Json(rep.getProjetoCompetenciaDescricao(projetoid), JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetCompetencias(string id, string id2)
        //{
        //    Int16 projetoid = Convert.ToInt16(id);
        //    Int16 atvid = Convert.ToInt16(id2);


        //    //busca todas desse projeto
        //    //busca todas desse projeto
        //    Domain.Consumo.ProjetoCompetenciaRepository rep = new Domain.Consumo.ProjetoCompetenciaRepository();
        //    return Json(rep.getProjetoCompetenciaDescricao(projetoid), JsonRequestBehavior.AllowGet);
        //}


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
