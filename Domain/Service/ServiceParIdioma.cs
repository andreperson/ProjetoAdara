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
    public class ServiceParIdioma
    {
        public static void InsertParIdioma(ParIdiomaModelView model)
        {
            ParIdioma objretorno = new ParIdioma();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ParIdiomaModelView, ParIdioma>();
            var objtpprod = Mapper.Map<ParIdioma>(model);

            objtpprod.DataIncl = DateTime.Now;
            ParIdiomaRepository tpprod = new ParIdiomaRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateParIdioma(ParIdiomaModelView model)
        {
            ParIdioma objretorno = new ParIdioma();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ParIdiomaModelView, ParIdioma>();
            var objtpprod = Mapper.Map<ParIdioma>(model);

            objtpprod.Dataalt = DateTime.Now;
            ParIdiomaRepository tpprod = new ParIdiomaRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<ParIdioma> getParIdioma(bool visivel)
        {
            //busca no banco
            ParIdiomaRepository tprep = new ParIdiomaRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<ParIdioma> getParIdioma()
        {
            //busca no banco
            ParIdiomaRepository tprep = new ParIdiomaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }



        public static List<ParIdioma> getParIdiomaCombo()
        {
            //busca no banco
            ParIdiomaRepository tprep = new ParIdiomaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();
            List<ParIdioma> lstReturn = new List<ParIdioma>();
            ParIdioma obj = new ParIdioma();

            obj = new ParIdioma();
            obj.paridiomaid = 0;
            obj.Descricao = "";
            lstReturn.Add(obj);

            
            foreach (var item in lst)
            {
                obj = new ParIdioma();
                obj.paridiomaid = item.paridiomaid;
                obj.Descricao = item.Descricao;
                lstReturn.Add(obj);
            }

           

            return lstReturn;
        }


        //get produto ID
        public static ParIdiomaModelView GetParIdiomaId(int id)
        {
            ParIdioma objretorno = new ParIdioma();

            ParIdiomaRepository tpprod = new ParIdiomaRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ParIdioma, ParIdiomaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ParIdiomaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteParIdiomaId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ParIdioma objretorno = new ParIdioma();
            ParIdiomaRepository tpprod = new ParIdiomaRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
