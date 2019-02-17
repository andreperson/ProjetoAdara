using System;
using System.Collections.Generic;
using System.Linq;
using Domain.ModelView;
using Domain.Entities;
using AutoMapper;
using Servico.Consumo;

namespace Servico.Service
{
    public class ServiceFuzzie
    {
        public static void InsertFuzzie(FuzzieModelView model)
        {
            Fuzzie objretorno = new Fuzzie();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<FuzzieModelView, Fuzzie>();
            var objtpprod = Mapper.Map<Fuzzie>(model);

            FuzzieRepository tpprod = new FuzzieRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateFuzzie(FuzzieModelView model)
        {
            Fuzzie objretorno = new Fuzzie();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<FuzzieModelView, Fuzzie>();
            var objtpprod = Mapper.Map<Fuzzie>(model);

            objtpprod.Dataalt = DateTime.Now;
            FuzzieRepository tpprod = new FuzzieRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Fuzzie> getFuzzie(bool visivel)
        {
            //busca no banco
            FuzzieRepository tprep = new FuzzieRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Fuzzie> getFuzzie()
        {
            //busca no banco
            FuzzieRepository tprep = new FuzzieRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Fuzzie> getFuzzieCombo()
        {
            //busca no banco
            FuzzieRepository tprep = new FuzzieRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Fuzzie obj = new Fuzzie();
            obj.descricao = "";
            obj.fuzzieid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static FuzzieModelView GetFuzzieId(Int16 id)
        {
            Fuzzie objretorno = new Fuzzie();

            FuzzieRepository tpprod = new FuzzieRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Fuzzie, FuzzieModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<FuzzieModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteFuzzieId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Fuzzie objretorno = new Fuzzie();
            FuzzieRepository tpprod = new FuzzieRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
