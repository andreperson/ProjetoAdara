using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class RecursoRepository : GenericRepository<Recurso>  
    {
        public Recurso GetRecurso(Recurso objrec)
        {
            var result = Search(x => x.RecursoId == objrec.RecursoId).FirstOrDefault();

            return result;
        }
    }
}
