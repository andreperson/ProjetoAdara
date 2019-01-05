using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class ListaPrecoRepository : GenericRepository<ListaPreco>  
    {
        public ListaPreco GetIdiomaPreco(int listaprecoid)
        {
            var result = Search(x => x.ListaPrecoid == listaprecoid).FirstOrDefault();

            return result;
        }
    }
}
