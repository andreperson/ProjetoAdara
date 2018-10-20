using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
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
