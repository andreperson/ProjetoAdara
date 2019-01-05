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
    public class ServiceClienteContato
    {
        public static void InsertClienteContato(ClienteContatoModelView model)
        {
            ClienteContato objretorno = new ClienteContato();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteContatoModelView, ClienteContato>();
            var objtpprod = Mapper.Map<ClienteContato>(model);

            ClienteContatoRepository tpprod = new ClienteContatoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateClienteContato(ClienteContatoModelView model)
        {
            ClienteContato objretorno = new ClienteContato();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteContatoModelView, ClienteContato>();
            var objtpprod = Mapper.Map<ClienteContato>(model);

            objtpprod.Dataalt = DateTime.Now;
            ClienteContatoRepository tpprod = new ClienteContatoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<ClienteContato> getClienteContato(bool visivel)
        {
            //busca no banco
            ClienteContatoRepository tprep = new ClienteContatoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<ClienteContato> getClienteContatoByClientId(Int16 clienteid)
        {
            //busca no banco
            ClienteContatoRepository tprep = new ClienteContatoRepository();
            var lst = tprep.Search(x => x.Status != 0 & x.clienteid==clienteid).OrderBy(x=>x.nome).ToList();

            return lst;
        }

         
        public static List<ClienteContato> getClienteContatoCombo()
        {
            //busca no banco
            ClienteContatoRepository tprep = new ClienteContatoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            ClienteContato obj = new ClienteContato();
            obj.nome = "";
            obj.clientecontatoid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.nome).ToList();

            return lstorder;
        }



        //get produto ID
        public static ClienteContatoModelView GetClienteContatoId(Int16 id)
        {
            ClienteContato objretorno = new ClienteContato();

            ClienteContatoRepository tpprod = new ClienteContatoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ClienteContato, ClienteContatoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ClienteContatoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete Contato produto
        public static void DeleteClienteContatoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ClienteContato objretorno = new ClienteContato();
            ClienteContatoRepository tpprod = new ClienteContatoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
