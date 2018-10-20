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
    public class ServiceUF
    {
        public static void InsertUF(UFModelView model)
        {
            UF objretorno = new UF();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UFModelView, UF>();
            var objtpprod = Mapper.Map<UF>(model);

            UFRepository tpprod = new UFRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateUF(UFModelView model)
        {
            UF objretorno = new UF();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UFModelView, UF>();
            var objtpprod = Mapper.Map<UF>(model);

            //objtpprod.dataincl = DateTime.Now;
            UFRepository tpprod = new UFRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<UF> getUF()
        {
            //busca no banco
            UFRepository tprep = new UFRepository();
            var lst = tprep.Search(x => x.uf != string.Empty).ToList();
            List<UF> lstUF = (from estados in lst orderby estados.uf select estados).ToList();

            return lstUF;
        }

        public static List<UF> getUF(string uf)
        {
            //busca no banco
            UFRepository tprep = new UFRepository();
            var lst = tprep.Search(x => x.uf == uf).ToList();
            List<UF> lstUF = (from estados in lst orderby estados.uf select estados).ToList();

            return lstUF;
        }

        public static List<UF> getUFCombo()
        {
            //busca no banco
            UFRepository tprep = new UFRepository();
            var lst = tprep.Search(x => x.uf != string.Empty).ToList();

            UF obj = new UF();
            obj.uf = "_";
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.uf).ToList();

            return lstorder;
        }



        public static void DeleteUFId(int id)
        {
            //busca o arquivo q sera apagado
            UF objretorno = new UF();
            UFRepository tpprod = new UFRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
