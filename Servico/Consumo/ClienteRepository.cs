using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
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
