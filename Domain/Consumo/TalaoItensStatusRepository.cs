using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class TalaoItensStatusRepository : GenericRepository<TalaoItensStatus>  
    {
        public TalaoItensStatus GetBoletoItensStatuss(Int16 id)
        {
            var result = Search(x => x.talaoitensstatusid == id).FirstOrDefault();

            return result;
        }
    }
}
