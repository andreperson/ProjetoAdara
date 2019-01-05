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
    public class ServiceTepBreke
    {
        public static void InsertTepBreke(TepBrekeModelView model)
        {
            TepBreke objretorno = new TepBreke();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepBrekeModelView, TepBreke>();
            var objtpprod = Mapper.Map<TepBreke>(model);

            TepBrekeRepository tpprod = new TepBrekeRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }
      

        public static void UpdateTepBreke(TepBrekeModelView model)
        {
            TepBreke objretorno = new TepBreke();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepBrekeModelView, TepBreke>();
            var objtpprod = Mapper.Map<TepBreke>(model);

            objtpprod.Dataincl = DateTime.Now;
            TepBrekeRepository tpprod = new TepBrekeRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<TepBreke> getTepBreke()
        {
            //busca no banco
            TepBrekeRepository tprep = new TepBrekeRepository();
            var lst = tprep.ListAll().ToList();

            return lst;
        }

        public static List<TepBreke> getTepBreke(int tepid)
        {
            //busca no banco
            TepBrekeRepository tprep = new TepBrekeRepository();
            var lst = tprep.Search(x=> x.tepid == tepid).ToList();

            return lst;
        }


        //get produto ID
        public static TepBrekeModelView GetTepBrekeId(Int16 id)
        {
            TepBreke objretorno = new TepBreke();

            TepBrekeRepository tpprod = new TepBrekeRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<TepBreke, TepBrekeModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TepBrekeModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTepBrekeId(Int16 id)
        {
            //busca o arquivo q sera apagado
            TepBreke objretorno = new TepBreke();
            TepBrekeRepository tpprod = new TepBrekeRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }


        public static void DeleteTepBrekeByTepID(int tepid)
        {
            //busca o arquivo q sera apagado
            Consumo.TepBrekeRepository tep = new TepBrekeRepository();
            tep.DeleteTepBrekeByTepID(tepid);

        }


        

    }
}
