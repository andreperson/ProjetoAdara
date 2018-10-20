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
    public class UsuarioMenuRepository : GenericRepository<UsuarioMenu>  
    {
        public static void DeleteUsuarioMenuAll()
        {
            Data.DataContext.ConnDataContext conn = new ConnDataContext();

            conn.UsuarioMenu.RemoveRange(conn.UsuarioMenu.Where(x => x.usuariomenuid != 0));
            conn.SaveChanges();
        }


        public List<UsuarioMenu> GetUsuarioMenuByUsuarioTipoId(int usuariotipoid)
        {
            //primeiro pega todos os menus cadastrados
            var result = Search(x => x.usuariotipoid == usuariotipoid).ToList();

            return result;
        }

    }
}
