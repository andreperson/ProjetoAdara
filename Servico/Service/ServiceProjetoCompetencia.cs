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
    public class ServiceProjetoCompetencia
    {
        public static void InsertProjetoCompetencia(ProjetoCompetenciaModelView model)
        {
            ProjetoCompetencia objretorno = new ProjetoCompetencia();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoCompetenciaModelView, ProjetoCompetencia>();
            var objtpprod = Mapper.Map<ProjetoCompetencia>(model);

            ProjetoCompetenciaRepository tpprod = new ProjetoCompetenciaRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateProjetoCompetencia(ProjetoCompetenciaModelView model)
        {
            ProjetoCompetencia objretorno = new ProjetoCompetencia();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoCompetenciaModelView, ProjetoCompetencia>();
            var objtpprod = Mapper.Map<ProjetoCompetencia>(model);

            objtpprod.Dataalt = DateTime.Now;
            ProjetoCompetenciaRepository tpprod = new ProjetoCompetenciaRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<ProjetoCompetencia> getProjetoCompetencia(bool visivel)
        {
            //busca no banco
            ProjetoCompetenciaRepository tprep = new ProjetoCompetenciaRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<ProjetoCompetencia> getProjetoCompetencia()
        {
            //busca no banco
            ProjetoCompetenciaRepository tprep = new ProjetoCompetenciaRepository();
            var lst = tprep.Search(x => x.projetocompetenciaid != 0).ToList();

            return lst;
        }


        public static List<Competencia> getCompetencia(Int16 projetoid)
        {
            //busca no banco
            ProjetoCompetenciaRepository tprep = new ProjetoCompetenciaRepository();
            var lst = tprep.Search(x => x.projetocompetenciaid != 0).ToList();

            //pega as competencias
            string comp = string.Empty;
            foreach (var item in lst)
            {
                comp += item.competenciaid + ",";
            }


            comp = comp.Substring(0, comp.Length - 1);

            CompetenciaRepository tpcomp = new CompetenciaRepository();
            var lstcomp = tpcomp.Search(x => comp.Contains(x.Competenciaid.ToString())).ToList();

            return lstcomp;
        }



        public static List<ProjetoCompetencia> getProjetoCompetencia(Int16 projetoid)
        {
            //busca no banco
            ProjetoCompetenciaRepository tprep = new ProjetoCompetenciaRepository();
            var lst = tprep.Search(x => x.projetoid == projetoid).ToList();

            return lst;
        }

        

        //get produto ID
        public static ProjetoCompetenciaModelView GetProjetoCompetenciaId(Int16 id)
        {
            ProjetoCompetencia objretorno = new ProjetoCompetencia();

            ProjetoCompetenciaRepository tpprod = new ProjetoCompetenciaRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ProjetoCompetencia, ProjetoCompetenciaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ProjetoCompetenciaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteProjetoCompetenciaId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ProjetoCompetencia objretorno = new ProjetoCompetencia();
            ProjetoCompetenciaRepository tpprod = new ProjetoCompetenciaRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }


        public static void DeleteProjetoCompetenciaId(Int16 projetoid, Int16 atividadeid)
        {
            //busca o arquivo q sera apagado
            ProjetoCompetenciaRepository tpprod = new ProjetoCompetenciaRepository();
            var lst = tpprod.Search(x => x.projetoid == projetoid & x.competenciaid == atividadeid).ToList();

            //passa a entidade recuperada para deletar

            foreach (var item in lst)
            {
                tpprod.Delete(item);
                tpprod.Save();
            }
        }

    }
}
