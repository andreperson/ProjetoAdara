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
    public class ServiceUsuarioTipo
    {
        public static void InsertUsuarioTipo(UsuarioTipoModelView model)
        {
            UsuarioTipo objretorno = new UsuarioTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioTipoModelView, UsuarioTipo>();
            var objtpprod = Mapper.Map<UsuarioTipo>(model);

            UsuarioTipoRepository tpprod = new UsuarioTipoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateUsuarioTipo(UsuarioTipoModelView model)
        {
            UsuarioTipo objretorno = new UsuarioTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<UsuarioTipoModelView, UsuarioTipo>();
            var objtpprod = Mapper.Map<UsuarioTipo>(model);

            //objtpprod.dataincl = DateTime.Now;
            UsuarioTipoRepository tpprod = new UsuarioTipoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<UsuarioTipo> getUsuarioTipo()
        {
            //busca no banco
            UsuarioTipoRepository tprep = new UsuarioTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<UsuarioTipo> getUsuarioTipo(bool useradmin )
        {
            //busca no banco
            UsuarioTipoRepository tprep = new UsuarioTipoRepository();
            List<UsuarioTipo> lst = new List<UsuarioTipo>();
            if (!useradmin)
            {
                lst = tprep.Search(x => x.Status == 1 & x.usuariotipoid != 1).ToList();
            }
            else
            {
                lst = tprep.Search(x => x.Status == 1).ToList();
            }

            return lst;
        }

        //get produto ID
        public static UsuarioTipoModelView GetUsuarioTipoId(Int16 id)
        {
            UsuarioTipo objretorno = new UsuarioTipo();

            UsuarioTipoRepository tpprod = new UsuarioTipoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<UsuarioTipo, UsuarioTipoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<UsuarioTipoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        public static List<UsuarioTipo> getUsuarioTipo(string descricao)
        {
            //busca no banco
            UsuarioTipoRepository tprep = new UsuarioTipoRepository();
            List<UsuarioTipo> lst = new List<UsuarioTipo>();
            lst = tprep.Search(x => x.Status == 1 & x.descricao == descricao).ToList();

            return lst;
        }




        //delete tipo produto
        public static void DeleteUsuarioTipoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            UsuarioTipo objretorno = new UsuarioTipo();
            UsuarioTipoRepository tpprod = new UsuarioTipoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
