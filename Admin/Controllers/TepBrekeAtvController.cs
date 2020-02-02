using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;

namespace Admin.Controllers
{
    public class TepBrekeAtvController : Controller
    {
        [HttpPost]
        public ActionResult TepBrekedownActivity(TepBrekeModelView model)
        {
            //SALVA APENAS O TÍTULO POR AQUI, O CONTROLE DE SELECT É FEITO POR AJAX - FINAL DO FORM ;p

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Login", "Account", null);
            //}

            //if (ModelState.IsValid)
            //{
            //    model.user = User.Identity.Name;
            //    if (model.tepbrekeid != 0) //update
            //    {
            //        ServiceTepBreke.UpdateTepBreke(model);
            //    }
            //    else //insert
            //    {
            //        ServiceTepBreke.InsertTepBreke(model);
            //    }
            //    return Redirect(Domain.Util.config.UrlSite + "TransTepBreke/TepBreke/" + model.menuid + "/" + model.menusubid);

            //}

            return View(model);
        }

        [HttpGet]
        public ActionResult TepBrekedownActivity(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {

            if (id3 == 0)
            {
                //é obrigatorio ter a tep
                return Redirect(Domain.Util.config.UrlSite + "TransTep/Tep/" + id + "/" + id2);
            }

            var model = new TepBrekeModelView();
            TepModelView tepmodel = ServiceTep.GetTepId(id3);
            ViewBag.TEP = tepmodel.descricao;

            ViewBag.PageTopInformation = "Tep Options Form";
            ViewBag.Acao = "Tep Options Management";

            model.tepid = id3;
            model.Teps = ServiceTep.getTep();
            model.TepBrekes = ServiceTepBreke.getTepBreke(id3);
            model.Brekedowns = ServiceBrekedown.getBrekedown();
            model.Atividades = ServiceAtividade.getAtividade();
            model.BrekeAtvs = GetBrekeAtv(model);

            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }

        private List<BrekeAtvModelView> GetBrekeAtv(TepBrekeModelView model)
        {
            List<BrekeAtvModelView> lst = new List<BrekeAtvModelView>();
            BrekeAtvModelView obj = new BrekeAtvModelView();

            int qtde = model.Atividades.Count;

            if (model.Brekedowns.Count > model.Atividades.Count)
            {
                qtde = model.Brekedowns.Count;
            }

            for (int i = 0; i < qtde; i++)
            {
                obj = new BrekeAtvModelView();
                if (model.Brekedowns.Count > i)
                {
                    obj.brekedownid = model.Brekedowns[i].brekedownid;
                    obj.breke = model.Brekedowns[i].descricao;
                    obj.perc = model.Brekedowns[i].valor;
                }
                else
                {
                    obj.brekedownid = 0;
                    obj.breke = "";
                    obj.perc = 0;
                }
                if (model.Atividades.Count > i)
                {
                    obj.atividadeid = model.Atividades[i].atividadeid;
                    obj.atv = model.Atividades[i].descricao;
                    obj.valor = model.Atividades[i].valor;
                }
                else
                {
                    obj.atividadeid = 0;
                    obj.atv = "";
                    obj.valor = 0;
                }


                lst.Add(obj);
            }

            return lst;

        }


        public void InsertAjax(List<string> data)
        {
            //posição 0 = TEPID
            //posição 1 = BREKEID
            TepBrekeModelView modelbre =new TepBrekeModelView();
            TepAtvModelView modelatv = new TepAtvModelView();
            string usuario = User.Identity.Name;
            //apaga todos
            var tipo = string.Empty;
            int tepid = 0;
            bool first = true;
            for (int i = 0; i < data.Count; i++)
            {
                string[] teparray = data[i].Split(new Char[] { ':' });
                tepid = Convert.ToInt16(teparray[1]);
                //APAGA TODOS QDO PASSAR A PRIMEIRA VEZ
                if (first)
                {
                    ServiceTepBreke.DeleteTepBrekeByTepID(tepid);
                    first = false;
                }

                tipo = teparray[0].ToString();


                if (tipo == "b")
                {
                    modelbre = new TepBrekeModelView();
                    modelbre.tepid = Convert.ToInt16(teparray[1]);
                    modelbre.Brekedownid = Convert.ToInt16(teparray[2]);
                    modelbre.dataincl = DateTime.Now;
                    modelbre.user = usuario;
                    //INSERE
                    ServiceTepBreke.InsertTepBreke(modelbre);
                }
                else
                {
                    modelatv.tepid = Convert.ToInt16(teparray[1]);
                    modelatv.atividadeid = Convert.ToInt16(teparray[2]);
                    modelatv.dataincl = DateTime.Now;
                    modelatv.user = usuario;
                    //INSERE
                    ServiceTepAtv.InsertTepAtv(modelatv);
                }





            }
        }

  
        //busca as permissoes 
        public JsonResult ListaSelBreke(int id)
        {
            return Json(ServiceTepBreke.getTepBreke(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListaSelAtv(int id)
        {
            return Json(ServiceTepAtv.getTepAtv(id), JsonRequestBehavior.AllowGet);
        }


        public ActionResult InsertOut(TepModelView model)
        {
            return View();
        }
    }
}
