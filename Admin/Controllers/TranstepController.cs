using System;
using System.Web.Mvc;
using Servico.Service;
using Domain.ModelView;


namespace Admin.Controllers
{
    public class TranstepController : Controller
    {
        [HttpPost]
        public ActionResult Tep(TepModelView model)
        {
            //SALVA APENAS O TÍTULO POR AQUI, O CONTROLE DE SELECT É FEITO POR AJAX - FINAL DO FORM ;p

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            if (ModelState.IsValid)
            {
                model.user = User.Identity.Name;
                model.status = 1;
                if (model.Tepid != 0) //update
                {
                    ServiceTep.UpdateTep(model);
                }
                else //insert
                {
                    ServiceTep.InsertTep(model);
                }
                return Redirect(Domain.Util.config.UrlSite + "Transtep/Tep/" + model.menuid + "/" + model.menusubid);

            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Tep(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            var model = new TepModelView();

            ViewBag.PageTopInformation = "Tep Form";
            ViewBag.Acao = "Tep Add";

            if (id3 != 0)
            {
                //busca as informações para edição
                model = ServiceTep.GetTepId(id3);
                ViewBag.Acao = "Tep Edit";
            }

            model.Teps = ServiceTep.getTep();
            model.menuid = id;
            model.menusubid = id2;
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;
            return View(model);
        }

        //public void InsertAjax(List<string> data)
        //{
        //    //posição 0 = BREKEDOWNID
        //    //posição 1 = TEPID
        //    TepBrekeModelView model = new TepBrekeModelView();
        //    string usuario = User.Identity.Name;
        //    //apaga todos
        //    Domain.Consumo.TepBrekeRepository.DeleteUsuarioMenuAll();
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        string[] teparray = data[i].Split(new Char[] { ':' });
        //        model.tepid = Convert.ToInt16(teparray[0]);
        //        model.Brekedownid = Convert.ToInt16(teparray[1]);
        //        model.dataincl = DateTime.Now;
        //        model.user = usuario;
        //        //insere um de cada vez.
        //        ServiceTepBreke.InsertTepBreke(model);
        //    }
        //}

        //public void InsertEditTEP(List<string> data)
        //{
        //    //posição 0 = BREKEDOWNID
        //    //posição 1 = TEPID
        //    TepModelView model = new TepModelView();
        //    string usuario = User.Identity.Name;
        //    //apaga todos
        //    for (int i = 0; i < data.Count; i++)
        //    {
        //        string[] teparray = data[i].Split(new Char[] { ':' });
        //        model.Tepid = Convert.ToInt16(teparray[0]);
        //        model.descricao= teparray[1].ToString();
        //        model.dataincl = DateTime.Now;
        //        model.user = usuario;
        //        model.status = 1;

        //        if (model.Tepid != 0)
        //        {
        //            ServiceTep.UpdateTep(model);
        //        }
        //        else
        //        {
        //            ServiceTep.InsertTep(model);
        //        }
        //    }

        //    Response.Redirect(Domain.Util.config.UrlSite + "Transtep/Tep/11/60");

        //}

        ////busca as permissoes 
        //public JsonResult ListaSelBreke()
        //{
        //    return Json(ServiceTepBreke.getTepBreke(), JsonRequestBehavior.AllowGet);
        //}

        public ActionResult TepDelete(Int16 id = 0, Int16 id2 = 0, Int16 id3 = 0)
        {
            if (id3 != 0)
            {
                //exclui registro
                ServiceTep.DeleteTepId(id3); 
            }

            return Redirect(Domain.Util.config.UrlSite + "Transtep/Tep/" + id + "/" + id2);
        }

       
    }
}
