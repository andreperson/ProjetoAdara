using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.ModelView;
using Domain.Entities;
using Servico.Service;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id=0, int id2=0, string id3="" )
        {
            IndexModelView model = new IndexModelView(); 
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            //busca as ultimas compras 
            

            ViewBag.mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            ViewBag.msg = id3;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(int id)
        {
            IndexModelView model = new IndexModelView(); 
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            
            return View(model);
        }

        public ActionResult Erro(int id = 0)
        {
            var msg = "Erro. Por favor verifique a url completa!";

            if (id == 10)
            {
                msg = "Acesso não permitido. Verifique com o administrador.";
            }
            if (id == 9)
            {
                msg = "Erro. Voce possui mais de um cadastro. Por favor envie um email para atendimento@inscricaorapida.com.br ou Pace@Paceeventos.com.br informando seu email de cadastro e telefone que retornaremos! Obrigado";
            }

            if (id == 8)
            {
                msg = "Erro. Usuário não encontrado. Por favor envie um email para atendimento@inscricaorapida.com.br ou Pace@Paceeventos.com.br informando seu email de cadastro e telefone que retornaremos! Obrigado";
            }

            if (id == 7)
            {
                msg = "Pesquisa não encontrada para esse evento. Verifique com o administrador.";
            }

            ViewBag.Message = msg;

            return View();
        }






        public JsonResult GetVendas(Int16 id=0 )
        {
            //pega o representante
           
            
            List<Cliente> lstComp = new List<Cliente>();
            
            List<object> lst2 = new List<object>();
            //agrupa vendas por mes
            //var agfec = from p in lstComp group p by p.DtVencimento.Month into g select new { descr = g.Key, qtde = g.Count(), soma = g.Sum(x=> x.ValorComissao), nome="fec" };
            
            object obj2 = new object();
            //obj2 = agfec;
            lst2.Add(obj2);

            //agrupa vendas por mes
           // var agrec = from p in lstRec group p by p.datapagto.Month into g select new { descr = g.Key, qtde = g.Count(), soma = g.Sum(x => x.ValorPago), nome="rec"};
            obj2 = new object();
            //obj2 = agrec;
            lst2.Add(obj2);

            ////loop no agrupamento pegando somente aquele mes
            //foreach (var item in agmes)
            //{
            //    var lstMes = (from f in lstFec where f.dataRecebto.Month == item.descr select f).ToList();
            //    vl = 0;
            //    //roda por aquele mes para somar;
            //    foreach (var item2 in lstMes)
            //    {
            //        vmes = item2.dataRecebto.Month.ToString();
            //        vl += item2.ValorComissao;

            //    }
            //        obj = new Vendas();
            //        obj.Mes = vmes;
            //        obj.Valor = vl.ToString();
            //        lst.Add(obj);
            //}

            return Json(lst2, JsonRequestBehavior.AllowGet);
        }

        //preenche a tela inicial com informaçoes assicronas
        //public JsonResult GetTotalRecebidas(Int16 id = 0)
        //{
        //    Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);

        //    //busca o total de vendas 
        //    List<Fechamento> lst = new List<Fechamento>();
        //    lst = ServiceFechamento.getFechamentoRecebidasTotal(DateTime.Now.Month, repreid);

        //    var tt = (from x in lst select x.ValorComissao).Sum();

        //    string ttf = String.Format("{0:C}", tt);

        //    return Json(ttf, JsonRequestBehavior.AllowGet);
        //}

        //preenche a tela inicial com informaçoes assicronas
        //public JsonResult GetTotalVendasByClientes(Int16 id = 0)
        //{
        //    //string tt = string.Empty;
        //    Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);

        //    //busca o total de vendas 
        //    List<Compra> lst = new List<Compra>();
        //    lst = ServiceCompra.getComprasTotal(DateTime.Now.Month, repreid);

        //    var agcli = from p in lst group p by p.clienteid into g select new { descr = g.Key, qtde = g.Count()};

        //    var tt = agcli.Count();


        //    return Json(tt, JsonRequestBehavior.AllowGet);
        //}



        //preenche a tela inicial com informaçoes assicronas
        //public JsonResult GetTotalFechadas(Int16 id = 0)
        //{
        //    Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);

        //    //busca o total de vendas 
        //    List<Fechamento> lst = new List<Fechamento>();
        //    lst = ServiceFechamento.getFechamentoTotal(DateTime.Now.Month, repreid);

        //    var tt = (from x in lst select x.ValorComissao).Sum();

        //    string ttf = String.Format("{0:C}", tt);

        //    return Json(ttf, JsonRequestBehavior.AllowGet);
        //}

        ////preenche a tela inicial com informaçoes assicronas
        //public JsonResult GetTotalVendas(Int16 id = 0)
        //{
        //    Int16 repreid = Domain.Util.valida.getRepresentanteID(User.Identity.Name);

        //    //busca o total de vendas 
        //    List<Compra> lst = new List<Compra>();
        //    lst = ServiceCompra.getComprasTotal(DateTime.Now.Month, repreid);

        //    var tt = (from x in lst select x.ValorComissao).Sum();

        //    string ttf = String.Format("{0:C}", tt);

        //    return Json(ttf, JsonRequestBehavior.AllowGet);
        //}


        public ActionResult Logout()
        {
            CustomMembershipProvider auth = new CustomMembershipProvider();
            auth.Logout();
            return Redirect(Domain.Util.config.UrlSite + "Home/Index");
        }
    }


    public class Vendas
    {
        public string Mes { get; set; }
        public string Valor { get; set; }
    }

}

