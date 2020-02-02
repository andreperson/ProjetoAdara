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
    public class ServiceIdioma
    {
        public static void InsertIdioma(IdiomaModelView model)
        {
            Idioma objretorno = new Idioma();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<IdiomaModelView, Idioma>();
            var objtpprod = Mapper.Map<Idioma>(model);

            objtpprod.DataIncl = DateTime.Now;
            IdiomaRepository tpprod = new IdiomaRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateIdioma(IdiomaModelView model)
        {
            Idioma objretorno = new Idioma();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<IdiomaModelView, Idioma>();
            var objtpprod = Mapper.Map<Idioma>(model);

            objtpprod.Dataalt = DateTime.Now;
            IdiomaRepository tpprod = new IdiomaRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<Idioma> getIdioma(bool visivel)
        {
            //busca no banco
            IdiomaRepository tprep = new IdiomaRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Idioma> getIdioma()
        {
            //busca no banco
            IdiomaRepository tprep = new IdiomaRepository();
            var lst = tprep.Search(x => x.Status != 0).OrderBy(x=>x.Sigla).ToList();

            return lst;
        }



        public static List<Idioma> getIdiomaCombo()
        {
            //busca no banco
            IdiomaRepository tprep = new IdiomaRepository();
            var lst = tprep.Search(x => x.Status != 0).OrderBy(x=>x.Sigla).ToList();
            List<Idioma> lstReturn = new List<Idioma>();
            Idioma obj = new Idioma();

            obj = new Idioma();
            obj.Descricao = "";
            obj.idiomaid = 0;
            lstReturn.Add(obj);

            
            foreach (var item in lst)
            {
                obj = new Idioma();
                obj.Descricao = item.Descricao;
                obj.idiomaid = item.idiomaid;
                obj.Sigla = item.Sigla;
                lstReturn.Add(obj);
            }

           

            return lstReturn;
        }


        public static IdiomaModelView GetIdiomaId(int id)
        {
            Idioma objretorno = new Idioma();

            IdiomaRepository tpprod = new IdiomaRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Idioma, IdiomaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<IdiomaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteIdiomaId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Idioma objretorno = new Idioma();
            IdiomaRepository tpprod = new IdiomaRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
