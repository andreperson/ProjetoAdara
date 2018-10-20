
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
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
