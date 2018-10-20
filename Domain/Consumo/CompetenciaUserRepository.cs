using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class CompetenciaUserRepository : GenericRepository<CompetenciaUser>  
    {
        public CompetenciaUser GetCompetencia(int id)
        {
            var result = Search(x => x.competenciauserid == id).FirstOrDefault();

            return result;
        }
    }
}
