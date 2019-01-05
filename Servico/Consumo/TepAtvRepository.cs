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
    public class TepAtvRepository : GenericRepository<TepAtv>  
    {
        public TepAtv GetTepAtv(int tepid)
        {
            var result = Search(x => x.tepid == tepid).FirstOrDefault();

            return result;
        }

        public static void DeleteTepAtvByTepID(int tepid)
        {
            ConnDataContext conn = new ConnDataContext();

            conn.TepAtv.RemoveRange(conn.TepAtv.Where(x => x.tepid == tepid));
            conn.SaveChanges();
        }

    }
}
