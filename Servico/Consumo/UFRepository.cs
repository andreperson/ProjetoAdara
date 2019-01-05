using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class UFRepository : GenericRepository<UF>  
    {
        public UF GetUF(string uf)
        {
            var result = Search(x => x.uf == uf).FirstOrDefault();

            return result;
        }
    }
}
