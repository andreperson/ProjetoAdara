using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;
using Data.DataContext;

namespace Servico.Consumo
{
    public class UserRepository : GenericRepository<User>
    {
        ConnDataContext db = new ConnDataContext();
        public User GetUser(User objusuario)
        {
            var result = Search(x => x.Email == objusuario.Email && x.Senha == objusuario.Senha).FirstOrDefault();

            return result;
        }



        public List<User> GetUsuariosRecursos()
        {
            var lst = (from us in db.User
                       join re in db.Recurso on us.UserId equals re.userid
                       select new
                       {
                           APELIDO = us.Apelido,
                           UserId = us.UserId,
                       }).ToList().Distinct();


                
            List<User> lstUser = new List<User>();
            User obj = new User();

            foreach (var item in lst)
            {
                obj = new User();
                obj.UserId = item.UserId;
                obj.Apelido = item.APELIDO;
                lstUser.Add(obj);
            }
            return lstUser;
        }

    }

}
