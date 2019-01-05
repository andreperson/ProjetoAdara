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
    public class ServiceTra
    {
        public static void InsertTra(TraModelView model)
        {
            Tra objretorno = new Tra();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TraModelView, Tra>();
            var objtpprod = Mapper.Map<Tra>(model);

            TraRepository tpprod = new TraRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateTra(TraModelView model)
        {
            Tra objretorno = new Tra();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TraModelView, Tra>();
            var objtpprod = Mapper.Map<Tra>(model);

            objtpprod.Dataincl = DateTime.Now;
            TraRepository tpprod = new TraRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Tra> getTra(bool visivel)
        {
            //busca no banco
            TraRepository tprep = new TraRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Tra> getTra()
        {
            //busca no banco
            TraRepository tprep = new TraRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Tra> getTraCombo()
        {
            //busca no banco
            TraRepository tprep = new TraRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Tra obj = new Tra();
            obj.descricao = "";
            obj.Traid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static TraModelView GetTraId(Int16 id)
        {
            Tra objretorno = new Tra();

            TraRepository tpprod = new TraRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Tra, TraModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TraModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteTraId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Tra objretorno = new Tra();
            TraRepository tpprod = new TraRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
