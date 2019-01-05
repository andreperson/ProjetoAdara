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
    public class ServiceClienteContatoProjeto
    {
        public static void InsertClienteContatoProjeto(ClienteContatoProjetoModelView model)
        {
            ClienteContatoProjeto objretorno = new ClienteContatoProjeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteContatoProjetoModelView, ClienteContatoProjeto>();
            var objtpprod = Mapper.Map<ClienteContatoProjeto>(model);

            ClienteContatoProjetoRepository tpprod = new ClienteContatoProjetoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateClienteContatoProjeto(ClienteContatoProjetoModelView model)
        {
            ClienteContatoProjeto objretorno = new ClienteContatoProjeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClienteContatoProjetoModelView, ClienteContatoProjeto>();
            var objtpprod = Mapper.Map<ClienteContatoProjeto>(model);

            ClienteContatoProjetoRepository tpprod = new ClienteContatoProjetoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<ClienteContatoProjeto> getClienteContatoProjeto(bool visivel)
        {
            //busca no banco
            ClienteContatoProjetoRepository tprep = new ClienteContatoProjetoRepository();
            var lst = tprep.ListAll().ToList();

            return lst;
        }


        public static List<ClienteContatoProjeto> getClienteContatoProjetoByClientId(Int16 clienteid)
        {
            //busca no banco
            ClienteContatoProjetoRepository tprep = new ClienteContatoProjetoRepository();
            var lst = tprep.Search(x => x.clienteid==clienteid).ToList();

            return lst;
        }


        //get produto ID
        public static ClienteContatoProjetoModelView GetClienteContatoProjetoId(Int16 id)
        {
            ClienteContatoProjeto objretorno = new ClienteContatoProjeto();

            ClienteContatoProjetoRepository tpprod = new ClienteContatoProjetoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ClienteContatoProjeto, ClienteContatoProjetoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ClienteContatoProjetoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete Contato produto
        public static void DeleteClienteContatoProjetoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ClienteContatoProjeto objretorno = new ClienteContatoProjeto();
            ClienteContatoProjetoRepository tpprod = new ClienteContatoProjetoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
