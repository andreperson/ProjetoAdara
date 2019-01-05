using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class ClienteContatoProjetoRepository : GenericRepository<ClienteContatoProjeto>  
    {
        public ClienteContatoProjeto GetClienteContatoProjeto(string nome, int clienteid)
        {
            var result = Search(x => x.clienteid==clienteid).FirstOrDefault();

            return result;
        }
    }
}
