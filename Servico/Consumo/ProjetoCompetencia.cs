using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.DataContext;
using Data.Repository;

namespace Servico.Consumo
{
    public class ProjetoCompetenciaRepository : GenericRepository<ProjetoCompetencia>
    {
        ConnDataContext db = new ConnDataContext();
        public ProjetoCompetencia GetProjetoCompetencia()
        {
            var result = Search(x => x.projetoid != 0).FirstOrDefault();

            return result;
        }


        public List<Competencia> getProjetoCompetenciaDescricao(Int16 projetoid)
        {
            var lst = (from co in db.Competencia
                       join pc in db.ProjetoCompetencia on co.Competenciaid equals pc.competenciaid
                       where pc.projetoid == projetoid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                           //VALORHORA = co.ValorHora
                       }).ToList();



            List<Competencia> lstCompt = new List<Competencia>();
            Competencia obj = new Competencia();


            foreach (var item in lst)
            {
                obj = new Competencia();
                obj.Competenciaid = item.COMPETENCIAID;
                obj.Descricao = item.DESCRICAO;
                //obj.ValorHora = item.VALORHORA;
                lstCompt.Add(obj);
            }


            return lstCompt;
        }



        public List<Competencia> getProjetoCompetenciaNotIN(Int16 projetoid)
        {
            var lst = (from co in db.Competencia
                       join pc in db.ProjetoCompetencia on co.Competenciaid equals pc.competenciaid
                       where pc.projetoid == projetoid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                           //VALORHORA = co.ValorHora
                       }).ToList();



            List<Competencia> lstCompt = new List<Competencia>();
            Competencia obj = new Competencia();


            foreach (var item in lst)
            {
                obj = new Competencia();
                obj.Competenciaid = item.COMPETENCIAID;
                obj.Descricao = item.DESCRICAO;
                //obj.ValorHora = item.VALORHORA;
                lstCompt.Add(obj);
            }


            return lstCompt;
        }


    }
}
