using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
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
