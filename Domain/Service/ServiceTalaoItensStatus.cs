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
    public class ServiceTalaoItensStatus
    {
        public static void InsertTalaoItensStatus(TalaoItensStatusModelView model)
        {
            TalaoItensStatus objretorno = new TalaoItensStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoItensStatusModelView, TalaoItensStatus>();
            var objtpprod = Mapper.Map<TalaoItensStatus>(model);

            TalaoItensStatusRepository tpprod = new TalaoItensStatusRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateTalaoItensStatus(TalaoItensStatusModelView model)
        {
            TalaoItensStatus objretorno = new TalaoItensStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoItensStatusModelView, TalaoItensStatus>();
            var objtpprod = Mapper.Map<TalaoItensStatus>(model);

            objtpprod.Dataalt = DateTime.Now;
            TalaoItensStatusRepository tpprod = new TalaoItensStatusRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<TalaoItensStatus> getTalaoItensStatus(bool visivel)
        {
            //busca no banco
            TalaoItensStatusRepository tprep = new TalaoItensStatusRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<TalaoItensStatus> getTalaoItensStatusCombo()
        {
            //busca no banco
            TalaoItensStatusRepository tprep = new TalaoItensStatusRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            TalaoItensStatus obj = new TalaoItensStatus();
            obj.Descricao = "_";
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.Descricao).ToList();

            return lstorder;
        }
        
        public static List<TalaoItensStatus> getTalaoItensStatus(Int16 statusid)
        {
            //busca no banco
            TalaoItensStatusRepository tprep = new TalaoItensStatusRepository();
            var lst = tprep.Search(x => x.talaoitensstatusid == statusid).ToList();

            return lst;
        }

        public static List<TalaoItensStatus> getTalaoItensStatus()
        {
            //busca no banco
            TalaoItensStatusRepository tprep = new TalaoItensStatusRepository();
            var lst = tprep.Search(x => x.talaoitensstatusid != 0).ToList();

            return lst;
        }


        //get produto ID
        public static TalaoItensStatusModelView GetTalaoItensStatusId(Int16 id)
        {
            TalaoItensStatus objretorno = new TalaoItensStatus();

            TalaoItensStatusRepository tpprod = new TalaoItensStatusRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<TalaoItensStatus, TalaoItensStatusModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TalaoItensStatusModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTalaoItensStatusId(Int16 id)
        {
            //busca o arquivo q sera apagado
            TalaoItensStatus objretorno = new TalaoItensStatus();
            TalaoItensStatusRepository tpprod = new TalaoItensStatusRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
