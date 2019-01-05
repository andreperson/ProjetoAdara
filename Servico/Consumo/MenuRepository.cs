using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Data.Repository;

namespace Servico.Consumo
{
    public class MenuRepository : GenericRepository<Menu>  
    {
        public Menu GetMenu(string descricao)
        {
            var result = Search(x => x.descricao == descricao).FirstOrDefault();

            return result;
        }

        public List<Menu> GetMenuAll()
        {
            //primeiro pega todos os menus cadastrados
            var lst = Search(x => x.status == 1).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }
    }
}
