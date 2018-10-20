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
    public class ServiceMoeda
    {
        public static void InsertMoeda(MoedaModelView model)
        {
            Moeda objretorno = new Moeda();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MoedaModelView, Moeda>();
            var objtpprod = Mapper.Map<Moeda>(model);

            objtpprod.DataIncl = DateTime.Now;
            MoedaRepository tpprod = new MoedaRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateMoeda(MoedaModelView model)
        {
            Moeda objretorno = new Moeda();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MoedaModelView, Moeda>();
            var objtpprod = Mapper.Map<Moeda>(model);

            objtpprod.Dataalt = DateTime.Now;
            MoedaRepository tpprod = new MoedaRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<Moeda> getMoeda(bool visivel)
        {
            //busca no banco
            MoedaRepository tprep = new MoedaRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Moeda> getMoeda()
        {
            //busca no banco
            MoedaRepository tprep = new MoedaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }



        public static List<Moeda> getMoedaCombo()
        {
            //busca no banco
            MoedaRepository tprep = new MoedaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();
            List<Moeda> lstReturn = new List<Moeda>();
            Moeda obj = new Moeda();

            obj = new Moeda();
            obj.Descricao = "";
            obj.moedaid = 0;
            lstReturn.Add(obj);

            foreach (var item in lst)
            {
                obj = new Moeda();
                obj.Descricao = item.Descricao;
                obj.moedaid = item.moedaid;
                lstReturn.Add(obj);
            }

            return lstReturn;
        }


        //get produto ID
        public static MoedaModelView GetMoedaId(Int16 id)
        {
            Moeda objretorno = new Moeda();

            MoedaRepository tpprod = new MoedaRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Moeda, MoedaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<MoedaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteMoedaId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Moeda objretorno = new Moeda();
            MoedaRepository tpprod = new MoedaRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
