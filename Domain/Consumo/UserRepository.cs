using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository; 


namespace Domain.Consumo
{
    public class UserRepository : GenericRepository<User>  
    {
        public User GetUser(User objusuario)
        {
            var result = Search(x => x.Email == objusuario.Email && x.Senha == objusuario.Senha).FirstOrDefault();

            return result;
        }
    }
}
