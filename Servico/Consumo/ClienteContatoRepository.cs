﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class ClienteContatoRepository : GenericRepository<ClienteContato>  
    {
        public ClienteContato GetClienteContato(string nome, int clienteid)
        {
            var result = Search(x => x.nome == nome & x.clienteid==clienteid).FirstOrDefault();

            return result;
        }
    }
}
