using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class JobStatusHistoricoRepository : GenericRepository<JobStatusHistorico>  
    {
        public JobStatusHistorico GetJobStatusHistorico(string descricao)
        {
            var result = Search(x => x.jobstatushistoricoid != 0).FirstOrDefault();

            return result;
        }
    }
}
