using Domain.Entities;
using System.Linq;
using Data.Repository;

namespace Servico.Consumo
{
    public class AtividadeRepository : GenericRepository<Atividade>  
    {
        public Atividade GetAtividade(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }
    }
}
