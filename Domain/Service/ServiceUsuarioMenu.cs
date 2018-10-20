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
    public class ServiceUsuarioMenu
    {
        public static void InsertUsuarioMenu(UsuarioMenuModelView model)
        {
            UsuarioMenu objretorno = new UsuarioMenu();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioMenuModelView, UsuarioMenu>();
            var objtpprod = Mapper.Map<UsuarioMenu>(model);

            UsuarioMenuRepository tpprod = new UsuarioMenuRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateUsuarioMenu(UsuarioMenuModelView model)
        {
            UsuarioMenu objretorno = new UsuarioMenu();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioMenuModelView, UsuarioMenu>();
            var objtpprod = Mapper.Map<UsuarioMenu>(model);

            //objtpprod.dataincl = DateTime.Now;
            UsuarioMenuRepository tpprod = new UsuarioMenuRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<UsuarioMenu> getUsuarioMenu()
        {
            //busca no banco
            UsuarioMenuRepository tprep = new UsuarioMenuRepository();
            var lst = tprep.Search(x => x.usuariomenuid != 0).ToList();

            return lst;
        }


        public static List<UsuarioMenu> getUsuarioMenuByTipoId(int usuariotipoid)
        {
            //busca no banco
            UsuarioMenuRepository tprep = new UsuarioMenuRepository();
            var lst = tprep.Search(x => x.usuariotipoid == usuariotipoid).ToList();

            return lst;
        }


        public static List<UsuarioMenu> getUsuarioMenuByTipoMenu(int usuariotipoid, int menuid)
        {
            //busca no banco
            UsuarioMenuRepository tprep = new UsuarioMenuRepository();
            var lst = tprep.Search(x => x.usuariotipoid == usuariotipoid & x.menuid == menuid).ToList();

            return lst;
        }


        //get produto ID
        public static UsuarioMenuModelView GetUsuarioMenuId(Int16 id)
        {
            UsuarioMenu objretorno = new UsuarioMenu();

            UsuarioMenuRepository tpprod = new UsuarioMenuRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<UsuarioMenu, UsuarioMenuModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<UsuarioMenuModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }



        public static void DeleteUsuarioMenuId(Int16 id)
        {
            //busca o arquivo q sera apagado
            UsuarioMenu objretorno = new UsuarioMenu();
            UsuarioMenuRepository tpprod = new UsuarioMenuRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

        



    }
}
