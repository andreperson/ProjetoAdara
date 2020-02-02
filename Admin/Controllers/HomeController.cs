using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.ModelView;
using Domain.Entities;
using Servico.Service;
using System.Linq;
using System.Globalization;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id = 0, int id2 = 0, string id3 = "")
        {
            IndexModelView model = new IndexModelView();
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account", null);
            }

            Int16 UserId = ServiceUsuario.GetUserIdByEmail(User.Identity.Name);
            List<Job> lstJobs = BuscaJobs(UserId, User.Identity.Name);


            //busca todos os status
            List<JobStatus> lstSt = ServiceJobStatus.getJobStatus();
            int i = 0;
            double porc = 0;
            double vporc = 0;
            int vtotal = lstJobs.Count();
            foreach (var item in lstSt)
            {
                porc = 0;
                vporc = 0;
                if (i == 0)
                {
                    ViewBag.Descr0 = item.descricao + " Jobs";
                    var lst0 = (from b0 in lstJobs where (b0.jobstatusid == item.jobstatusid) select b0).ToList();
                    ViewBag.Total0 = lst0.Count();
                    vporc = lst0.Count();
                    porc = Convert.ToDouble((vporc / vtotal));
                    ViewBag.Porc0 = (porc * 100).ToString().Substring(0, 2) + "%";
                    ViewBag.Img0 = "ico-status-" + item.jobstatusid + ".png";
                }
                else if (i == 1)
                {
                    ViewBag.Descr1 = item.descricao + " Jobs";
                    var lst1 = (from b1 in lstJobs where (b1.jobstatusid == item.jobstatusid) select b1).ToList();
                    ViewBag.Total1 = lst1.Count();
                    vporc = lst1.Count();
                    porc = Convert.ToDouble((vporc / vtotal));
                    ViewBag.Porc1 = (porc * 100).ToString().Substring(0, 2) + "%";
                    ViewBag.Img1 = "ico-status-" + item.jobstatusid + ".png";
                }

                else if (i == 2)
                {
                    ViewBag.Descr2 = item.descricao + " Jobs";
                    var lst2 = (from b2 in lstJobs where (b2.jobstatusid == item.jobstatusid) select b2).ToList();
                    ViewBag.Total2 = lst2.Count();
                    vporc = lst2.Count();
                    porc = Convert.ToDouble((vporc / vtotal));
                    ViewBag.Porc2 = (porc * 100).ToString().Substring(0, 2) + "%";
                    ViewBag.Img2 = "ico-status-" + item.jobstatusid + ".png";

                }
                else if (i == 3)
                {
                    ViewBag.Descr3 = item.descricao + " Jobs";
                    var lst3 = (from b3 in lstJobs where (b3.jobstatusid == item.jobstatusid) select b3).ToList();
                    ViewBag.Total3 = lst3.Count();
                    vporc = lst3.Count();
                    porc = Convert.ToDouble((vporc / vtotal));
                    ViewBag.Porc3 = (porc * 100).ToString().Substring(0, 2) + "%";
                    ViewBag.Img3 = "ico-status-" + item.jobstatusid + ".png";

                }
                //else if (i == 4)
                //{
                //    ViewBag.Descr4 = "My " + item.descricao + " Jobs";
                //    var lst4 = (from b4 in lst where (b4.jobstatusid == item.jobstatusid) select b4).ToList();
                //    ViewBag.Total4 = lst4.Count();
                //}

                i += 1;

            }

            ViewBag.Descr3 = "Total Jobs";
            ViewBag.Total3 = lstJobs.Count();
            ViewBag.Porc3 = "100%";
            ViewBag.Img3 = "ico-job5.png";

            ListaJobsGrafico(UserId, User.Identity.Name);
            //lista ultimas jobs
            //pega somente as ultimas 10 jobs
            model.Jobs = lstJobs.Take(10).OrderByDescending(x=>x.Dataalt).ToList();

            ViewBag.mes = System.Globalization.DateTimeFormatInfo.CurrentInfo.GetMonthName(DateTime.Now.Month);
            ViewBag.MenuId = id;
            ViewBag.MenuSubId = id2;

            //BUSCA O MENUID E SUBMENUID PARA JOBS E PROFILE - ELES ESTÃO NO MENUZINHO DO PERFIL
            GetMenuSubIds();

            ViewBag.msg = id3;

            return View(model);
        }


        private static UsuarioModelView VerificaRecurso(string email)
        {
            UsuarioModelView model = new UsuarioModelView();
            model.statusb = false;
            List<User> lst = ServiceUsuario.getUsuariobyEmail(email);
            foreach (var item in lst)
            {
                model.userid = item.UserId;
                model.nome = item.Nome;
                model.apelido = item.Apelido;
            }

            //verifica se esse usuário é um recurso
            List<Recurso> lstRec = ServiceRecurso.getRecurso(model.userid);
            if (lstRec.Count > 0)
                model.statusb = true;


            return model;
        }


        //busca os ids para formar o link do menuzinho do perfil.
        private void GetMenuSubIds()
        {
            List<MenuSub> lst = new List<MenuSub>();
            lst = ServiceMenuSub.getMenuSubAll();

            foreach (var item in lst)
            {
                if (item.controller.Equals("WorkProfile") || item.controller.Equals("Profile"))
                {
                    ViewBag.menuprofileid = item.menuid;
                    if (item.controller.Equals("WorkProfile"))
                    {
                        ViewBag.subprofile = item.menusubid;
                    }
                    else if (item.controller.Equals("Profile"))
                    {
                        ViewBag.subjob = item.menusubid;
                    }
                }
            }
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


        //busca as jobs do usuário ou em geral.
        private static List<Job> BuscaJobs(int userid, string email)
        {
            UsuarioModelView MdUser = new UsuarioModelView();
            MdUser = VerificaRecurso(email);
            List<Job> lst = new List<Job>();
            if (MdUser.statusb)
            {
                lst = ServiceJob.getJobByUserid(userid);
            }
            else
            {
                lst = ServiceJob.getJob();
            }


            return lst;
        }



        public JsonResult GetVendas(Int16 id = 0)
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


        public void ListaJobsGrafico(int userid, string email)
        {
            DateTime Agora = DateTime.Now;
            int Ano = Agora.Year;

            List<DadosJobs> lstRet = new List<DadosJobs>();
            DadosJobs obj = new DadosJobs();

            List<Job> lst = BuscaJobs(userid,email);

            string month = string.Empty;
            for (int i = 1; i < 13; i++)
            {
                month = new CultureInfo("pt-BR").DateTimeFormat.GetMonthName(i);

                obj = new DadosJobs();
                obj.Mes = month;
                obj.Valor = (from j in lst where (j.dataentrega.Value.Year == Ano & j.dataentrega.Value.Month == i) select j).Count();
                lstRet.Add(obj);
            }

            foreach (var item in lstRet)
            {
                if (item.Mes == "janeiro")
                {
                    ViewBag.Jan = item.Valor;
                }
                if (item.Mes == "fevereiro")
                {
                    ViewBag.Fev = item.Valor;
                }
                if (item.Mes == "marco")
                {
                    ViewBag.Mar = item.Valor;
                }
                if (item.Mes == "abril")
                {
                    ViewBag.Abr = item.Valor;
                }
                if (item.Mes == "maio")
                {
                    ViewBag.Mai = item.Valor;
                }
                if (item.Mes == "junho")
                {
                    ViewBag.Jun = item.Valor;
                }
                if (item.Mes == "julho")
                {
                    ViewBag.Jul = item.Valor;
                }
                if (item.Mes == "agosto")
                {
                    ViewBag.Ago = item.Valor;
                }
                if (item.Mes == "setembro")
                {
                    ViewBag.Set = item.Valor;
                }
                if (item.Mes == "outubro")
                {
                    ViewBag.Out = item.Valor;
                }
                if (item.Mes == "novembro")
                {
                    ViewBag.Nov = item.Valor;
                }
                if (item.Mes == "dezembro")
                {
                    ViewBag.Dez = item.Valor;
                }


            }


        }

        public ActionResult Logout()
        {
            CustomMembershipProvider auth = new CustomMembershipProvider();
            auth.Logout();
            return Redirect(Domain.Util.config.UrlSite + "Home/Index");
        }
    }


    public class DadosJobs
    {
        public string Mes { get; set; }
        public int Valor { get; set; }
    }

}

