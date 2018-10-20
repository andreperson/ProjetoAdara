using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class ParIdiomaRepository : GenericRepository<ParIdioma>  
    {
        public ParIdioma GetIdioma(int paridiomaid)
        {
            var result = Search(x => x.paridiomaid == paridiomaid).FirstOrDefault();

            return result;
        }
    }
}
