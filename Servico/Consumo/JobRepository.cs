using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class JobRepository : GenericRepository<Job>  
    {
        public Job GetJob()
        {
            var result = Search(x => x.jobstatusid !=0).FirstOrDefault();

            return result;
        }
    }
}
