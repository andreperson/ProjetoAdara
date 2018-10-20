using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Data.Repository;
using Data.DataContext;


namespace Domain.Consumo
{
    public class UsuarioMenuSubRepository : GenericRepository<UsuarioMenuSub>  
    {
        public static void DeleteUsuarioMenuSubAll()
        {
            Data.DataContext.ConnDataContext conn = new ConnDataContext();

            conn.UsuarioMenuSub.RemoveRange(conn.UsuarioMenuSub.Where(x => x.usuariomenusubid != 0));
            conn.SaveChanges();
        }


        public List<UsuarioMenuSub> GetUsuarioMenuSubByUsuarioTipoId(int usuariotipoid)
        {
            //primeiro pega todos os menus cadastrados
            var result = Search(x => x.usuariotipoid == usuariotipoid).ToList();

            return result;
        }

    }
}
