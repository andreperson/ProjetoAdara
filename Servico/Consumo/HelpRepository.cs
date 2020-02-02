using Domain.Entities;
using System.Linq;
using Data.Repository;

namespace Servico.Consumo
{
    public class HelpRepository : GenericRepository<Help>  
    {
        public Help GetManual(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
