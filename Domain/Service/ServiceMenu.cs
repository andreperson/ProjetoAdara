using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ModelView;
using Data.Entities;
using Domain.Consumo;
using AutoMapper;


namespace Domain.Service
{
    public class ServiceMenu
    {
        public static void InsertMenu(MenuModelView model)
        {
            Menu objretorno = new Menu();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MenuModelView, Menu>();
            var objtpprod = Mapper.Map<Menu>(model);

            MenuRepository tpprod = new MenuRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateMenu(MenuModelView model)
        {
            Menu objretorno = new Menu();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MenuModelView, Menu>();
            var objtpprod = Mapper.Map<Menu>(model);

            //objtpprod.dataincl = DateTime.Now;
            MenuRepository tpprod = new MenuRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }

        public static List<Menu> getMenu()
        {
            //busca no banco
            MenuRepository tprep = new MenuRepository();
            var lst = tprep.Search(x => x.status == 1).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }

        public static List<Menu> getMenu(Int16 menuid)
        {
            //busca no banco
            MenuRepository tprep = new MenuRepository();
            var lst = tprep.Search(x => x.status == 1 & x.menuid==menuid).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }

        public static List<Menu> getMenuStr(string str)
        {
            //busca no banco
            MenuRepository tprep = new MenuRepository();
            var lst = tprep.Search(x => x.descricao == str).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }


        public static List<Menu> getMenu(string ctrdelete)
        {
            //busca no banco
            MenuRepository tprep = new MenuRepository();
            var lst = tprep.Search(x => x.status == 1 & x.controller != ctrdelete).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();

            return result;
        }


        //get produto ID
        public static MenuModelView GetMenuId(Int16 id)
        {
            Menu objretorno = new Menu();

            MenuRepository tpprod = new MenuRepository();
            objretorno = tpprod.Find(id);

            ////faz o de para: objEntity para objModelView
            //Mapper.CreateMap<Menu, MenuModelView>();
            //var vretorno = Mapper.Map<MenuModelView>(objretorno);

            //guarda a imagem no arquivo que chega até a tela como texto.
        //    var img = objretorno.imagem;

            //faz o de para: objEntity para objModelView
            Mapper
                .CreateMap<Menu, MenuModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<MenuModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteMenuId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Menu objretorno = new Menu();
            MenuRepository tpprod = new MenuRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
