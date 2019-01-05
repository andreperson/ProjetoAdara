
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class LoginRepository : GenericRepository<Login>  
    {
        public Login GetLogin(string email)
        {
            var result = Search(x => x.email == email).FirstOrDefault();

            return result;
        }
    }
}
