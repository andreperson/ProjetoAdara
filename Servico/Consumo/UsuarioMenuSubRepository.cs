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
    public class UsuarioMenuSubRepository : GenericRepository<UsuarioMenuSub>  
    {
        public void DeleteUsuarioMenuSubAll()
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
