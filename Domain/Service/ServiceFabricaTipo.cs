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
    public class ServiceFabricaTipo
    {
        public static void InsertFabricaTipo(FabricaTipoModelView model)
        {
            FabricaTipo objretorno = new FabricaTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<FabricaTipoModelView, FabricaTipo>();
            var objtpprod = Mapper.Map<FabricaTipo>(model);

            FabricaTipoRepository tpprod = new FabricaTipoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateFabricaTipo(FabricaTipoModelView model)
        {
            FabricaTipo objretorno = new FabricaTipo();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<FabricaTipoModelView, FabricaTipo>();
            var objtpprod = Mapper.Map<FabricaTipo>(model);

            objtpprod.Dataalt = DateTime.Now;
            FabricaTipoRepository tpprod = new FabricaTipoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<FabricaTipo> getFabricaTipo(bool visivel)
        {
            //busca no banco
            FabricaTipoRepository tprep = new FabricaTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<FabricaTipo> getFabricaTipo()
        {
            //busca no banco
            FabricaTipoRepository tprep = new FabricaTipoRepository();
            var lst = tprep.Search(x => x.fabricatipoid != 0).ToList();

            return lst;
        }

         
        public static List<FabricaTipo> getFabricaTipoCombo()
        {
            //busca no banco
            FabricaTipoRepository tprep = new FabricaTipoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            FabricaTipo obj = new FabricaTipo();
            obj.descricao = "_";
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static FabricaTipoModelView GetFabricaTipoId(Int16 id)
        {
            FabricaTipo objretorno = new FabricaTipo();

            FabricaTipoRepository tpprod = new FabricaTipoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<FabricaTipo, FabricaTipoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<FabricaTipoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteFabricaTipoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            FabricaTipo objretorno = new FabricaTipo();
            FabricaTipoRepository tpprod = new FabricaTipoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
