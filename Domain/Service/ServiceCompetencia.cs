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
    public class ServiceCompetencia
    {
        public static void InsertCompetencia(CompetenciaModelView model)
        {
            Competencia objretorno = new Competencia();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<CompetenciaModelView, Competencia>();
            var objtpprod = Mapper.Map<Competencia>(model);

            objtpprod.DataIncl = DateTime.Now;
            CompetenciaRepository tpprod = new CompetenciaRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateCompetencia(CompetenciaModelView model)
        {
            Competencia objretorno = new Competencia();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<CompetenciaModelView, Competencia>();
            var objtpprod = Mapper.Map<Competencia>(model);

            objtpprod.Dataalt = DateTime.Now;
            CompetenciaRepository tpprod = new CompetenciaRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<Competencia> getCompetencia(bool visivel)
        {
            //busca no banco
            CompetenciaRepository tprep = new CompetenciaRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Competencia> getCompetencia()
        {
            //busca no banco
            CompetenciaRepository tprep = new CompetenciaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

     
        public static List<Competencia> getCompetenciaCombo()
        {
            //busca no banco
            CompetenciaRepository tprep = new CompetenciaRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();
            List<Competencia> lstReturn = new List<Competencia>();
            Competencia obj = new Competencia();

            obj = new Competencia();
            obj.Descricao = "";
            obj.Competenciaid = 0;
            lstReturn.Add(obj);


            foreach (var item in lst)
            {
                obj = new Competencia();
                obj.Descricao = item.Descricao;
                obj.Competenciaid = item.Competenciaid;
                lstReturn.Add(obj);
            }
            

            return lstReturn;
        }


        //get produto ID
        public static CompetenciaModelView GetCompetenciaId(Int16 id)
        {
            Competencia objretorno = new Competencia();

            CompetenciaRepository tpprod = new CompetenciaRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Competencia, CompetenciaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<CompetenciaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteCompetenciaId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Competencia objretorno = new Competencia();
            CompetenciaRepository tpprod = new CompetenciaRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
