using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class RelatorioRepository : GenericRepository<Relatorio>  
    {
        public Relatorio GetRelatorio(Int16 id)
        {
            var result = Search(x => x.relatorioid == id).FirstOrDefault();

            return result;
        }
    }
}
