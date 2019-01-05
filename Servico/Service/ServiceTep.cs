using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ModelView;
using Domain.Entities;
using AutoMapper;
using Servico.Consumo;

namespace Servico.Service
{
    public class ServiceTep
    {
        public static void InsertTep(TepModelView model)
        {
            Tep objretorno = new Tep();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepModelView, Tep>();
            var objtpprod = Mapper.Map<Tep>(model);

            TepRepository tpprod = new TepRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateTep(TepModelView model)
        {
            Tep objretorno = new Tep();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepModelView, Tep>();
            var objtpprod = Mapper.Map<Tep>(model);

            objtpprod.Dataincl = DateTime.Now;
            TepRepository tpprod = new TepRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Tep> getTep(bool visivel)
        {
            //busca no banco
            TepRepository tprep = new TepRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Tep> getTep()
        {
            //busca no banco
            TepRepository tprep = new TepRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Tep> getTepCombo()
        {
            //busca no banco
            TepRepository tprep = new TepRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Tep obj = new Tep();
            obj.descricao = "";
            obj.Tepid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static TepModelView GetTepId(Int16 id)
        {
            Tep objretorno = new Tep();

            TepRepository tpprod = new TepRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Tep, TepModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TepModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTepId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Tep objretorno = new Tep();
            TepRepository tpprod = new TepRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
