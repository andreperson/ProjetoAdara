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
    public class ServiceClientePreco
    {
        public static void InsertClientePreco(ClientePrecoModelView model)
        {
            ClientePreco objretorno = new ClientePreco();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClientePrecoModelView, ClientePreco>();
            var objtpprod = Mapper.Map<ClientePreco>(model);

            objtpprod.DataIncl = DateTime.Now;
            ClientePrecoRepository tpprod = new ClientePrecoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateClientePreco(ClientePrecoModelView model)
        {
            ClientePreco objretorno = new ClientePreco();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ClientePrecoModelView, ClientePreco>();
            var objtpprod = Mapper.Map<ClientePreco>(model);

            objtpprod.Dataalt = DateTime.Now;
            ClientePrecoRepository tpprod = new ClientePrecoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<ClientePreco> getClientePreco(bool visivel)
        {
            //busca no banco
            ClientePrecoRepository tprep = new ClientePrecoRepository();
            var lst = tprep.Search(x => x.Status == 1).OrderBy(y=> y.clienteid).ToList();

            return lst;
        }

        public static List<ClientePreco> getClientePreco(Int16 clienteid, int paridiomaid)
        {
            //busca no banco
            ClientePrecoRepository tprep = new ClientePrecoRepository();
            var lst = tprep.Search(x => x.clienteid == clienteid & x.paridiomaid==paridiomaid).OrderBy(y => y.clienteid).ToList();

            return lst;
        }



        public static List<ClientePreco> getClientePreco()
        {
            //busca no banco
            ClientePrecoRepository tprep = new ClientePrecoRepository();
            var lst = tprep.Search(x => x.Status != 0).OrderBy(y => y.clienteid).ToList();

            return lst;
        }



        //public static List<ClientePreco> getClientePrecoCombo()
        //{
        //    //busca no banco
        //    ClientePrecoRepository tprep = new ClientePrecoRepository();
        //    var lst = tprep.Search(x => x.Status != 0).OrderBy(y => y.clienteid).ToList();
        //    List<ClientePreco> lstReturn = new List<ClientePreco>();
        //    ClientePreco obj = new ClientePreco();

        //    obj = new ClientePreco();
        //    obj.Fantasia = "-";
        //    obj.ClientePrecoid = 0;
        //    lstReturn.Add(obj);

        //    foreach (var item in lst)
        //    {
        //        obj = new ClientePreco();
        //        obj.Fantasia = item.Fantasia;
        //        obj.ClientePrecoid = item.ClientePrecoid;
        //        lstReturn.Add(obj);
        //    }


        //    return lstReturn;
        //}


        //get produto ID
        public static ClientePrecoModelView GetClientePrecoId(Int16 id)
        {
            ClientePreco objretorno = new ClientePreco();

            ClientePrecoRepository tpprod = new ClientePrecoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ClientePreco, ClientePrecoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ClientePrecoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteClientePrecoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ClientePreco objretorno = new ClientePreco();
            ClientePrecoRepository tpprod = new ClientePrecoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
