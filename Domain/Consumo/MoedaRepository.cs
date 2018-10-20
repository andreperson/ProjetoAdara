using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class MoedaRepository : GenericRepository<Moeda>  
    {
        public Moeda GetMoeda(string descricao)
        {
            var result = Search(x => x.Descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
