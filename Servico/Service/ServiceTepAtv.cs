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
    public class ServiceTepAtv
    {
        public static void InsertTepAtv(TepAtvModelView model)
        {
            TepAtv objretorno = new TepAtv();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepAtvModelView, TepAtv>();
            var objtpprod = Mapper.Map<TepAtv>(model);

            TepAtvRepository tpprod = new TepAtvRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }
      

        public static void UpdateTepAtv(TepAtvModelView model)
        {
            TepAtv objretorno = new TepAtv();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TepAtvModelView, TepAtv>();
            var objtpprod = Mapper.Map<TepAtv>(model);

            objtpprod.Dataincl = DateTime.Now;
            TepAtvRepository tpprod = new TepAtvRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<TepAtv> getTepAtv()
        {
            //busca no banco
            TepAtvRepository tprep = new TepAtvRepository();
            var lst = tprep.ListAll().ToList();

            return lst;
        }

        public static List<TepAtv> getTepAtv(int tepid)
        {
            //busca no banco
            TepAtvRepository tprep = new TepAtvRepository();
            var lst = tprep.Search(x=> x.tepid == tepid).ToList();

            return lst;
        }


        //get produto ID
        public static TepAtvModelView GetTepAtvId(Int16 id)
        {
            TepAtv objretorno = new TepAtv();

            TepAtvRepository tpprod = new TepAtvRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<TepAtv, TepAtvModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TepAtvModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTepAtvId(Int16 id)
        {
            //busca o arquivo q sera apagado
            TepAtv objretorno = new TepAtv();
            TepAtvRepository tpprod = new TepAtvRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
