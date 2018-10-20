using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class TalaoItensRepository : GenericRepository<TalaoItens>  
    {
        public TalaoItens GetBoletoItens(Int32 itemid)
        {
            var result = Search(x => x.talaoitensid == itemid).FirstOrDefault();

            return result;
        }
    }
}
