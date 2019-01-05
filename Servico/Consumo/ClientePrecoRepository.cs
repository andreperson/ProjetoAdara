using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

using Data.DataContext;
using Data.Repository;

namespace Servico.Consumo
{
    public class ClientePrecoRepository : GenericRepository<ClientePreco>  
    {
        ConnDataContext db = new ConnDataContext();
        public ClientePreco GetClientePreco(Int16 clienteid)
        {
            var result = Search(x => x.clienteid == clienteid).FirstOrDefault();

            return result;
        }

        public List<ClientePreco> GetClientePrecoProjeto(Int16 projetoid, Int16 clienteid)
        {
            var lst = (from co in db.Competencia
                       join pc in db.ProjetoCompetencia on co.Competenciaid equals pc.competenciaid
                       join cp in db.ClientePreco on co.Competenciaid equals cp.competenciaid
                       where pc.projetoid == projetoid & cp.clienteid==clienteid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                           VALORHORA = cp.PrecoHora,
                           VALORPALAVRA = cp.PrecoPalavra,
                           VALORLLINHA = cp.PrecoLinha,

                       }).ToList();



            List<ClientePreco> lstPrecos = new List<ClientePreco>();
            ClientePreco obj = new ClientePreco();


            foreach (var item in lst)
            {
                obj = new ClientePreco();
                obj.competenciaid = item.COMPETENCIAID;
                obj.Competencia.Descricao = item.DESCRICAO;
                obj.PrecoHora = item.VALORHORA;
                obj.PrecoPalavra = item.VALORPALAVRA;
                obj.PrecoLinha = item.VALORLLINHA;
                lstPrecos.Add(obj);
            }


            return lstPrecos;
        }


        public List<Competencia> GetCompetenciaClientePrecoLista(int paridiomaid, Int16 clienteid)
        {
            var lst = (from co in db.Competencia
                       join cp in db.ClientePreco on co.Competenciaid equals cp.competenciaid
                       where cp.paridiomaid == paridiomaid & cp.clienteid == clienteid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                       }).ToList();



            List<Competencia> lstComp = new List<Competencia>();
            Competencia obj = new Competencia();


            foreach (var item in lst)
            {
                obj = new Competencia();
                obj.Competenciaid = item.COMPETENCIAID;
                obj.Descricao = item.DESCRICAO;
                lstComp.Add(obj);
            }


            return lstComp;
        }


        public List<Competencia> GetCompetenciaPrecoLista(int paridiomaid)
        {
            var lst = (from co in db.Competencia
                       join cp in db.ListaPreco on co.Competenciaid equals cp.competenciaid
                       where cp.paridiomaid == paridiomaid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                       }).ToList();



            List<Competencia> lstComp = new List<Competencia>();
            Competencia obj = new Competencia();


            foreach (var item in lst)
            {
                obj = new Competencia();
                obj.Competenciaid = item.COMPETENCIAID;
                obj.Descricao = item.DESCRICAO;
                lstComp.Add(obj);
            }


            return lstComp;
        }


        public List<ListaPreco> GetCompetenciaPrecoLista2(int paridiomaid)
        {
            var lst = (from co in db.Competencia
                       join cp in db.ListaPreco on co.Competenciaid equals cp.competenciaid
                       where cp.paridiomaid == paridiomaid
                       select new
                       {
                           COMPETENCIAID = co.Competenciaid,
                           DESCRICAO = co.Descricao,
                           PRECOPALAVRA = cp.Precopalavra,
                           PRECOLINHA = cp.Precolinha,
                           PRECOHORA = cp.Precohora,
                           LISTAPRECOID=cp.ListaPrecoid,
                       }).ToList();

            List<ListaPreco> lstPreco = new List<ListaPreco>();
            ListaPreco obj = new ListaPreco();

            foreach (var item in lst)
            {
                obj = new ListaPreco();
                obj.competenciaid = item.COMPETENCIAID;
                obj.ListaPrecoid = item.LISTAPRECOID;
                obj.Descricao = item.DESCRICAO;
                obj.Precopalavra = item.PRECOPALAVRA;
                obj.Precolinha = item.PRECOLINHA;
                obj.Precohora = item.PRECOHORA;
                lstPreco.Add(obj);
            }
            return lstPreco;
        }

    }
}
