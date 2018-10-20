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
    public class ServiceListaPreco
    {
        public static void InsertListaPreco(ListaPrecoModelView model)
        {
            ListaPreco objretorno = new ListaPreco();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ListaPrecoModelView, ListaPreco>();
            var objtpprod = Mapper.Map<ListaPreco>(model);

            objtpprod.DataIncl = DateTime.Now;
            ListaPrecoRepository tpprod = new ListaPrecoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateListaPreco(ListaPrecoModelView model)
        {
            ListaPreco objretorno = new ListaPreco();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ListaPrecoModelView, ListaPreco>();
            var objtpprod = Mapper.Map<ListaPreco>(model);

            objtpprod.Dataalt = DateTime.Now;
            ListaPrecoRepository tpprod = new ListaPrecoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<ListaPreco> getListaPreco(bool visivel)
        {
            //busca no banco
            ListaPrecoRepository tprep = new ListaPrecoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<ListaPreco> getListaPreco()
        {
            //busca no banco
            ListaPrecoRepository tprep = new ListaPrecoRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }



        public static List<ListaPreco> getListaPrecoCombo()
        {
            //busca no banco
            ListaPrecoRepository tprep = new ListaPrecoRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();
            List<ListaPreco> lstReturn = new List<ListaPreco>();
            ListaPreco obj = new ListaPreco();

            obj = new ListaPreco();
            obj.ListaPrecoid = 0;
            obj.ParIdioma.Descricao = "";

            lstReturn.Add(obj);

            
            foreach (var item in lst)
            {
                obj = new ListaPreco();
                obj.ListaPrecoid = item.ListaPrecoid;
                obj.ParIdioma.Descricao = item.ParIdioma.Descricao;
                lstReturn.Add(obj);
            }

           

            return lstReturn;
        }


        //get produto ID
        public static ListaPrecoModelView GetListaPrecoId(Int16 id)
        {
            ListaPreco objretorno = new ListaPreco();

            ListaPrecoRepository tpprod = new ListaPrecoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ListaPreco, ListaPrecoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ListaPrecoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteListaPrecoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ListaPreco objretorno = new ListaPreco();
            ListaPrecoRepository tpprod = new ListaPrecoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
