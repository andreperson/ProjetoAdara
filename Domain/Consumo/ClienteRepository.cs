using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class ClienteRepository : GenericRepository<Cliente>  
    {
        public Cliente GetCliente(string descricao)
        {
            var result = Search(x => x.Fantasia == descricao).FirstOrDefault();

            return result;
        }
    }
}
