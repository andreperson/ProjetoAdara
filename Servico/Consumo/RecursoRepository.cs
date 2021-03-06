﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
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
