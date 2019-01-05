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
    public class ServiceClienteTipo
    {
        public static void InsertClienteTipo(ClienteTipoModelView model)
        {
            ClienteTipo objretorno = new ClienteTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteTipoModelView, ClienteTipo>();
            var objtpprod = Mapper.Map<ClienteTipo>(model);

            ClienteTipoRepository tpprod = new ClienteTipoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateClienteTipo(ClienteTipoModelView model)
        {
            ClienteTipo objretorno = new ClienteTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteTipoModelView, ClienteTipo>();
            var objtpprod = Mapper.Map<ClienteTipo>(model);

            objtpprod.Dataalt = DateTime.Now;
            ClienteTipoRepository tpprod = new ClienteTipoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<ClienteTipo> getClienteTipo(bool visivel)
        {
            //busca no banco
            ClienteTipoRepository tprep = new ClienteTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<ClienteTipo> getClienteTipo()
        {
            //busca no banco
            ClienteTipoRepository tprep = new ClienteTipoRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<ClienteTipo> getClienteTipoCombo()
        {
            //busca no banco
            ClienteTipoRepository tprep = new ClienteTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            ClienteTipo obj = new ClienteTipo();
            obj.descricao = "";
            obj.clientetipoid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static ClienteTipoModelView GetClienteTipoId(Int16 id)
        {
            ClienteTipo objretorno = new ClienteTipo();

            ClienteTipoRepository tpprod = new ClienteTipoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ClienteTipo, ClienteTipoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ClienteTipoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteClienteTipoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ClienteTipo objretorno = new ClienteTipo();
            ClienteTipoRepository tpprod = new ClienteTipoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
