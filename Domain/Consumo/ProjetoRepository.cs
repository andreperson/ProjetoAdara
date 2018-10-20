using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class ProjetoRepository : GenericRepository<Projeto>  
    {
        public Projeto GetProjetos(int projetoid)
        {
            var result = Search(x => x.projetoid == projetoid).FirstOrDefault();

            return result;
        }
    }
}
