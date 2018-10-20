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
    public class ServiceProjetoTipo
    {
        public static void InsertProjetoTipo(ProjetoTipoModelView model)
        {
            ProjetoTipo objretorno = new ProjetoTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoTipoModelView, ProjetoTipo>();
            var objtpprod = Mapper.Map<ProjetoTipo>(model);

            ProjetoTipoRepository tpprod = new ProjetoTipoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateProjetoTipo(ProjetoTipoModelView model)
        {
            ProjetoTipo objretorno = new ProjetoTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoTipoModelView, ProjetoTipo>();
            var objtpprod = Mapper.Map<ProjetoTipo>(model);

            objtpprod.Dataalt = DateTime.Now;
            ProjetoTipoRepository tpprod = new ProjetoTipoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<ProjetoTipo> getProjetoTipo(bool visivel)
        {
            //busca no banco
            ProjetoTipoRepository tprep = new ProjetoTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<ProjetoTipo> getProjetoTipo()
        {
            //busca no banco
            ProjetoTipoRepository tprep = new ProjetoTipoRepository();
            var lst = tprep.Search(x => x.projetotipoid != 0).ToList();

            return lst;
        }

         
        public static List<ProjetoTipo> getProjetoTipoCombo()
        {
            //busca no banco
            ProjetoTipoRepository tprep = new ProjetoTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            ProjetoTipo obj = new ProjetoTipo();
            obj.descricao = "_";
            obj.projetotipoid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static ProjetoTipoModelView GetProjetoTipoId(Int16 id)
        {
            ProjetoTipo objretorno = new ProjetoTipo();

            ProjetoTipoRepository tpprod = new ProjetoTipoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<ProjetoTipo, ProjetoTipoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ProjetoTipoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteProjetoTipoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            ProjetoTipo objretorno = new ProjetoTipo();
            ProjetoTipoRepository tpprod = new ProjetoTipoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
