﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class IdiomaRepository : GenericRepository<Idioma>  
    {
        public Idioma GetIdioma(string descricao)
        {
            var result = Search(x => x.Descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
