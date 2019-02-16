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

        public static List<ClienteContatoProjeto> GetVerificaSelecao(Int16 clienteid, Int16 projetoid, int clientecontatoid)
        {
            //busca no banco
            ClienteContatoProjetoRepository tprep = new ClienteContatoProjetoRepository();
            var lst = tprep.Search(x => x.clienteid == clienteid & x.projetoid == projetoid & x.clientecontatoid == clientecontatoid).ToList();

            return lst;
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
        public static void DeleteClienteContatoProjetoId(Int16 clienteid, Int16 projetoid, Int16 clientecontatoid)
        {
            //busca o arquivo q sera apagado
            List<ClienteContatoProjeto> lst = new List<ClienteContatoProjeto>();
            ClienteContatoProjetoRepository tpprod = new ClienteContatoProjetoRepository();
            lst = tpprod.Search(x => x.clienteid == clienteid & x.projetoid == projetoid & x.clientecontatoid == clientecontatoid).ToList();

            //passa a entidade recuperada para deletar
            foreach (var item in lst)
            {
                tpprod.Delete(item);
                tpprod.Save();
            }
        }

    }
}
