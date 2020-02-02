using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class JobStatusHistoricoModelView
    {
        public int jobstatushistoricoid { get; set; }
        public int jobid { get; set; }
        public int jobstatusid { get; set; }
        public DateTime? dataincl { get; set; }
        public string user { get; set; }

        public List<JobStatusHistorico> JobStatusHistorico { get; set; }
    }
}
