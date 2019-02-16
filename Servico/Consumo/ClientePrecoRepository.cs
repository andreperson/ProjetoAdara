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
