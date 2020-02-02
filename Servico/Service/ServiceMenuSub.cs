using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ModelView;
using Domain.Entities;

using AutoMapper;
using Servico.Consumo;

namespace Servico.Service
{
    public class ServiceMenuSub
    {
        public static void InsertMenuSub(MenuSubModelView model)
        {
            MenuSub objretorno = new MenuSub();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MenuSubModelView, MenuSub>();
            var objtpprod = Mapper.Map<MenuSub>(model);

            MenuSubRepository tpprod = new MenuSubRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateMenuSub(MenuSubModelView model)
        {
            MenuSub objretorno = new MenuSub();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<MenuSubModelView, MenuSub>();
            var objtpprod = Mapper.Map<MenuSub>(model);

            //objtpprod.dataincl = DateTime.Now;
            MenuSubRepository tpprod = new MenuSubRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<MenuSub> getMenuSubByMenuId(int id)
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.Search(x => x.menuid == id).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();
            return result;
        }


        public static List<MenuSub> getMenuSubId(int id)
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.Search(x => x.menusubid == id).ToList();
            var result = lst.OrderBy(y => y.menuid).OrderBy(y=>y.ordem).ToList();
            return result;
        }



        public static List<MenuSub> getMenuSubByController(string ctr)
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.Search(x => x.controller == ctr).ToList();
            var result = lst.OrderBy(y => y.ordem).ToList();
            return result;
        }


        public static List<MenuSub> getMenuSubAll()
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.Search(x => x.status == 1).ToList();
            var result = lst.OrderBy(y => y.menuid).OrderBy(x=>x.descricao).ToList();
            return result;
        }

        //get produto ID
        public static MenuSubModelView GetMenuSubId(Int16 id)
        {
            MenuSub objretorno = new MenuSub();

            MenuSubRepository tpprod = new MenuSubRepository();
            objretorno = tpprod.Find(id);

            //faz o de para: objEntity para objModelView
            Mapper
                .CreateMap<MenuSub, MenuSubModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<MenuSubModelView>(objretorno);

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteMenuSubId(Int16 id)
        {
            //busca o arquivo q sera apagado
            MenuSub objretorno = new MenuSub();
            MenuSubRepository tpprod = new MenuSubRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }



        public static List<MenuSub> getMenuSub()
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.GetMenuSub();

            //faz um de-para
            List<MenuSub> lstMenuSub = new List<MenuSub>();
            lstMenuSub = TranslateMenuSub(lst);

            return lstMenuSub.OrderBy(x => x.descricaomenu).ToList();
        }

        public static List<MenuSub> GetSubMenuPermitido(int usuariotipoid, int menuid)
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.GetSubMenuPermitido(usuariotipoid, menuid);

            //faz um de-para
            List<MenuSub> lstMenuSub = new List<MenuSub>();
            lstMenuSub = TranslateMenuSub(lst);

            return lstMenuSub;
        }


        public static List<MenuSub> GetSubMenuPermitido(int usuariotipoid, string action)
        {
            //busca no banco
            MenuSubRepository tprep = new MenuSubRepository();
            var lst = tprep.GetSubMenuPermitido(usuariotipoid, action);

            //faz um de-para
            List<MenuSub> lstMenuSub = new List<MenuSub>();
            lstMenuSub = TranslateMenuSub(lst);

            return lstMenuSub;
        }

        public static List<MenuSub> TranslateMenuSub(IQueryable lst)
        {
            List<MenuSub> lstRet = new List<MenuSub>();
            MenuSub obj = new MenuSub();

            string strItem = string.Empty;

            foreach (var item in lst)
            {
                strItem = string.Empty;
                strItem = item.ToString().Replace("{","").Replace("}","");

                var splItem = strItem.Split(',');

                obj = new MenuSub();
                obj.descricao = splItem[0].Replace(" DESCRICAOSUB = ", "");
                obj.icone = splItem[1].Replace(" ICONE = ", "");
                obj.menusubid = Convert.ToInt16(splItem[2].Replace(" SUBMENUID = ", ""));
                obj.menuid = Convert.ToInt16(splItem[3].Replace(" MENUID = ", ""));
                obj.descricaomenu = splItem[4].Replace(" DESCRICAOMENU = ", "").Trim();
                obj.controller = splItem[5].Replace(" CONTROLLER = ", "").Trim();
                obj.view = splItem[6].Replace(" VIEW = ", "").Trim();
                obj.menuact = splItem[7].Replace(" MENUACT = ", "").Trim();

                lstRet.Add(obj);
            }

            return lstRet;
        }


    }
}
