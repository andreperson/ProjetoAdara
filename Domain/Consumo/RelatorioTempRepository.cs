using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class RelatorioTempRepository : GenericRepository<RelatorioTemp>  
    {
        public List<RelatorioTemp> GetRelatorioTemp(Int16 repreid)
        {
            var result = Search(x => x.representanteid == repreid).ToList();


            


            return result;
        }
    }
}
