using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class FabricaTipoRepository : GenericRepository<FabricaTipo>  
    {
        public FabricaTipo GetFabricaTipo(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
