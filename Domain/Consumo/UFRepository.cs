using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
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
