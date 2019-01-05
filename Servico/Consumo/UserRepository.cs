using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
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
