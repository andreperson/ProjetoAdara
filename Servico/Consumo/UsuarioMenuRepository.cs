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
    public class UsuarioMenuRepository : GenericRepository<UsuarioMenu>  
    {
        public void DeleteUsuarioMenuAll()
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
