using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class TalaoRepository : GenericRepository<Talao>  
    {
        public Talao GetBoleto(Int32 id)
        {
            var result = Search(x => x.talaoid == id).FirstOrDefault();

            return result;
        }
    }
}
