﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class ClienteTipoRepository : GenericRepository<ClienteTipo>  
    {
        public ClienteTipo GetClienteTipo(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
