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
    public class ServiceClientePrecoProjeto
    {
        public static void InsertClientePrecoProjeto(ClientePrecoProjetoModelView model)
        {
            ClientePrecoProjeto objretorno = new ClientePrecoProjeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClientePrecoProjetoModelView, ClientePrecoProjeto>();
            var objtpprod = Mapper.Map<ClientePrecoProjeto>(model);

            ClientePrecoProjetoRepository tpprod = new ClientePrecoProjetoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateClientePrecoProjeto(ClientePrecoProjetoModelView model)
        {
            ClientePrecoProjeto objretorno = new ClientePrecoProjeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClientePrecoProjetoModelView, ClientePrecoProjeto>();
            var objtpprod = Mapper.Map<ClientePrecoProjeto>(model);

            ClientePrecoProjetoRepository tpprod = new ClientePrecoProjetoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }

        public static List<ClientePrecoProjeto> GetVerificaSelecao(Int16 clienteid, Int16 projetoid, int clienteprecoid)
        {
            //busca no banco
            ClientePrecoProjetoRepository tprep = new ClientePrecoProjetoRepository();
            var lst = tprep.Search(x => x.clienteid == clienteid & x.projetoid == projetoid & x.clienteprecoid == clienteprecoid).ToList();

            return lst;
        }

        public static List<ClientePrecoProjeto> getClientePrecoProjeto(bool visivel)
        {
            //busca no banco
            ClientePrecoProjetoRepository tprep = new ClientePrecoProjetoRepository();
            var lst = tprep.ListAll().ToList();

            return lst;
        }


        public static List<ClientePrecoProjeto> getClientePrecoProjetoByClientId(Int16 clienteid)
        {
            //busca no banco
            ClientePrecoProjetoRepository tprep = new ClientePrecoProjetoRepository();
            var lst = tprep.Search(x => x.clienteid==clienteid).ToList();

            return lst;
        }


        //get produto ID
        public static ClientePrecoProjetoModelView GetClientePrecoProjetoId(Int16 id)
        {
            ClientePrecoProjeto objretorno = new ClientePrecoProjeto();

            ClientePrecoProjetoRepository tpprod = new ClientePrecoProjetoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ClientePrecoProjeto, ClientePrecoProjetoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ClientePrecoProjetoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete preco produto
        public static void DeleteClientePrecoProjetoId(Int16 clienteid, Int16 projetoid, Int16 clienteprecoid)
        {
            //busca o arquivo q sera apagado
            List<ClientePrecoProjeto> lst = new List<ClientePrecoProjeto>();
            ClientePrecoProjetoRepository tpprod = new ClientePrecoProjetoRepository();
            lst = tpprod.Search(x => x.clienteid == clienteid & x.projetoid == projetoid & x.clienteprecoid == clienteprecoid).ToList();

            //passa a entidade recuperada para deletar
            foreach (var item in lst)
            {
                tpprod.Delete(item);
                tpprod.Save();
            }
        }

    }
}
