using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class RelatorioStatusRepository : GenericRepository<RelatorioStatus>  
    {
        public RelatorioStatus GetRelatorioStatuss(Int16 id)
        {
            var result = Search(x => x.relatoriostatusid == id).FirstOrDefault();

            return result;
        }
    }
}
