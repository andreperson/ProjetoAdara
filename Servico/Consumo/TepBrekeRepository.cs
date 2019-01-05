using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.DataContext;
using Data.Repository;

namespace Servico.Consumo
{
    public class TepBrekeRepository : GenericRepository<TepBreke>  
    {
        public TepBreke GetTepBreke(int tepid)
        {
            var result = Search(x => x.tepid == tepid).FirstOrDefault();

            return result;
        }

        public void DeleteTepBrekeByTepID(int tepid)
        {
            ConnDataContext conn = new ConnDataContext();

            conn.TepBreke.RemoveRange(conn.TepBreke.Where(x => x.tepid == tepid));
            conn.SaveChanges();
        }

    }
}
