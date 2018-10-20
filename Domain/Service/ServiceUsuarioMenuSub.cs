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
    public class ServiceUsuarioMenuSub
    {
        public static void InsertUsuarioMenuSub(UsuarioMenuSubModelView model)
        {
            UsuarioMenuSub objretorno = new UsuarioMenuSub();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioMenuSubModelView, UsuarioMenuSub>();
            var objtpprod = Mapper.Map<UsuarioMenuSub>(model);

            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateUsuarioMenuSub(UsuarioMenuSubModelView model)
        {
            UsuarioMenuSub objretorno = new UsuarioMenuSub();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioMenuSubModelView, UsuarioMenuSub>();
            var objtpprod = Mapper.Map<UsuarioMenuSub>(model);

            //objtpprod.dataincl = DateTime.Now;
            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<UsuarioMenuSub> getUsuarioMenuSub()
        {
            //busca no banco
            UsuarioMenuSubRepository tprep = new UsuarioMenuSubRepository();
            var lst = tprep.Search(x => x.usuariomenusubid != 0).ToList();

            return lst;
        }


        public static List<UsuarioMenuSub> getUsuarioMenuSubByTipoId(int usuariotipoid)
        {
            //busca no banco
            UsuarioMenuSubRepository tprep = new UsuarioMenuSubRepository();
            var lst = tprep.Search(x => x.usuariotipoid == usuariotipoid).ToList();

            return lst;
        }

        public static List<UsuarioMenuSub> getUsuarioMenuSubByTipoMenu(int usuariotipoid, int menusubid)
        {
            //busca no banco
            UsuarioMenuSubRepository tprep = new UsuarioMenuSubRepository();
            var lst = tprep.Search(x => x.usuariotipoid == usuariotipoid & x.menusubid == menusubid).ToList();

            return lst;
        }



        //get produto ID
        public static UsuarioMenuSubModelView GetUsuarioMenuSubId(int id)
        {
            UsuarioMenuSub objretorno = new UsuarioMenuSub();

            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<UsuarioMenuSub, UsuarioMenuSubModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<UsuarioMenuSubModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }



        public static void DeleteUsuarioMenuSubId(int id)
        {
            //busca o arquivo q sera apagado
            UsuarioMenuSub objretorno = new UsuarioMenuSub();
            UsuarioMenuSubRepository tpprod = new UsuarioMenuSubRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }




    }
}
