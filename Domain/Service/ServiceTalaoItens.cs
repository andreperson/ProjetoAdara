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
    public class ServiceTalaoItens
    {
        public static void InsertTalaoItens(TalaoItensModelView model)
        {
            TalaoItens objretorno = new TalaoItens();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoItensModelView, TalaoItens>();
            var objtpprod = Mapper.Map<TalaoItens>(model);

            objtpprod.DataIncl = DateTime.Now;
            TalaoItensRepository tpprod = new TalaoItensRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateTalaoItens(TalaoItensModelView model)
        {
            TalaoItens objretorno = new TalaoItens();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<TalaoItensModelView, TalaoItens>();
            var objtpprod = Mapper.Map<TalaoItens>(model);

            objtpprod.Dataalt = DateTime.Now;
            TalaoItensRepository tpprod = new TalaoItensRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }



        //get item ID
        public static Int16 GetItemByNumero(Int16 repreid, Int16 numero)
        {
            Int16 RetItem = 0;
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.Numero == numero & x.representanteid==repreid).ToList();

            foreach (var item in lst)
            {
                RetItem = item.talaoitensid;
            }
            

            return RetItem;
        }


        //get item ID
        public static List<TalaoItens> GetItemByNumeroList(Int16 repreid, Int16 numero)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.Numero == numero & x.representanteid == repreid).ToList();

            return lst;
        }

        //get item ID
        public static TalaoItensModelView GetTalaoItensId(Int16 itemid)
        {
            TalaoItens objretorno = new TalaoItens();

            TalaoItensRepository tpprod = new TalaoItensRepository();
            objretorno = tpprod.Find(itemid);

            Mapper
                .CreateMap<TalaoItens, TalaoItensModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<TalaoItensModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //get Talao ID
        public static List<TalaoItens> GetTalaoItemId(Int16 Talaoitemid)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.talaoitensid == Talaoitemid).ToList();

            return lst;
        }

        public static List<TalaoItens> GetTalaoItemId(Int16 Talaoitemid, int statusid)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.talaoitensid == Talaoitemid & x.talaoitensstatusid == statusid).ToList();

            return lst;
        }


        public static List<TalaoItens> GetTalaoItensCombo(Int16 Talaoid)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.talaoid == Talaoid & x.Status==1 & x.talaoitensstatusid==1).ToList();

            TalaoItens obj = new TalaoItens();
            obj.Numero = 0;
            obj.talaoitensid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.Numero).ToList();

            return lstorder;
        }


        //get Talao ID
        public static List<TalaoItens> GetTalaoItens(Int16 Talaoid)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.talaoid == Talaoid).ToList();
         
            return lst;
        }

        //get Talao ID
        public static List<TalaoItens> GetTalaoItens(Int16 Talaoid, Int16 representanteid)
        {
            List<TalaoItens> lst = new List<TalaoItens>();

            TalaoItensRepository tprep = new TalaoItensRepository();
            lst = tprep.Search(x => x.talaoid == Talaoid & x.representanteid==representanteid).OrderBy(x=> x.Numero).ToList();

            return lst;
        }


        //delete tipo produto
        public static void DeleteTalaoItensId(Int16 id)
        {
            //busca o arquivo q sera apagado
            TalaoItens objretorno = new TalaoItens();
            TalaoItensRepository tpprod = new TalaoItensRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
