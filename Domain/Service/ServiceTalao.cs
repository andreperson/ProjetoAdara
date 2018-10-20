using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ModelView;
using Data.Entities;
using Domain.Consumo;
using AutoMapper;


namespace Domain.Service
{
    public class ServiceTalao
    {
        public static void InsertTalao(TalaoModelView model)
        {
            Talao objretorno = new Talao();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoModelView, Talao>();
            var objtpprod = Mapper.Map<Talao>(model);

            objtpprod.DataIncl = DateTime.Now;
            TalaoRepository tpprod = new TalaoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateTalao(TalaoModelView model)
        {
            Talao objretorno = new Talao();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoModelView, Talao>();
            var objtpprod = Mapper.Map<Talao>(model);

            objtpprod.Dataalt = DateTime.Now;
            TalaoRepository tpprod = new TalaoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }

        public static Int16 getTalaoMax(Int16 repreid)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();

            var bol = tprep.Search(x => x.representanteid == repreid).OrderByDescending(x => x.talaoid).FirstOrDefault();

            return bol.talaoid;
        }
        
        public static List<Talao> getTalao(bool visivel)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        
        public static List<Talao> getTalao()
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            var lst = tprep.Search(x => x.talaoid != 0).ToList();

            return lst;
        }

        public static List<Talao> getTalaoid(Int16 Talaoid)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            var lst = tprep.Search(x => x.talaoid == Talaoid).ToList();

            return lst;
        }

        /// <summary>
        /// ativo:- true:somente os ativo, false:todos
        /// </summary>
        /// <param name="repreid"></param>
        /// <param name="ativo"></param>
        /// <returns></returns>
        public static List<Talao> getTalao(Int16 repreid, bool ativo)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            List<Talao> lst = new List<Talao>();

            if (ativo)
            {
                if (repreid != 0)
                {
                    lst = tprep.Search(x => x.representanteid == repreid & x.Status == 1).ToList();
                }
                else
                {
                    lst = tprep.Search(x => x.representanteid != repreid & x.Status == 1).ToList();
                }

            }
            else
            {
                if (repreid != 0)
                {
                    lst = tprep.Search(x => x.representanteid == repreid).ToList();
                }
                else
                {
                    lst = tprep.Search(x => x.representanteid != repreid).ToList();
                }
            }

            return lst;
        }


        public static List<Talao> getTalao(Int16 repreid, Int32 ini, Int32 fin)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.ini == ini & x.fin == fin).ToList();

            return lst;
        }

        //public static List<Talao> getTalaoAgrupado(Int16 repreid)
        //{
        //    //busca no banco
        //    TalaoRepository tprep = new TalaoRepository();
        //    var lst = tprep.Search(x => x.representanteid == repreid).OrderBy(x => x.ini).ToList();

        //    var query = from p in lst group p by p.ini into g select new { descr = g.Key, qtde = g.Count(), todos = g.ToList()};

        //    List<Talao> lstbol = new List<Talao>();
        //    Talao obj = new Talao();

        //    foreach (var item in query)
        //    {
        //        obj = new Talao();
        //        obj.ini = item.todos[0].ini;
        //        obj.fin = item.todos[0].fin;
        //        obj.representanteid = item.todos[0].representanteid;
        //        obj.Numero = item.qtde;
        //        obj.Status = item.todos[0].Status;
        //        lstbol.Add(obj);
        //    }

        //    return lstbol;

        //}

        public static List<Talao> getTalaoCombo(Int16 repreid)
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.Status==1).OrderBy(x => x.ini).ToList();

            foreach (var item in lst)
            {
                item.descricao = item.ini + " - " + item.fin;
            }

            Talao obj = new Talao();
            obj.descricao = "-";
            obj.talaoid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }


        public static List<Talao> getTalaoCombo()
        {
            //busca no banco
            TalaoRepository tprep = new TalaoRepository();
            List<Talao> lst = new List<Talao>();
            Talao obj = new Talao();
            obj.descricao = "-";
            lst.Add(obj);

            return lst;

        }


        //get produto ID
        public static TalaoModelView GetTalaoId(Int16 id)
        {
            Talao objretorno = new Talao();

            TalaoRepository tpprod = new TalaoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Talao, TalaoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TalaoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTalaoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Talao objretorno = new Talao();
            TalaoRepository tpprod = new TalaoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
