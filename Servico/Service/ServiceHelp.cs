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
    public class ServiceHelp
    {
        public static void InsertHelp(AjudaModelView model)
        {
            Help objretorno = new Help();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<AjudaModelView, Help>();
            var objtpprod = Mapper.Map<Help>(model);

            HelpRepository tpprod = new HelpRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateHelp(AjudaModelView model)
        {
            Help objretorno = new Help();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<AjudaModelView, Help>();
            var objtpprod = Mapper.Map<Help>(model);

            objtpprod.Dataalt = DateTime.Now;
            HelpRepository tpprod = new HelpRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Help> getHelp(bool visivel)
        {
            //busca no banco
            HelpRepository tprep = new HelpRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Help> getHelp()
        {
            //busca no banco
            HelpRepository tprep = new HelpRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

        public static List<Help> getHelByMenuSubId(int id)
        {
            //busca no banco
            HelpRepository tprep = new HelpRepository();
            var lst = tprep.Search(x => x.menusubid == id).ToList();

            return lst;
        }


        //get produto ID
        public static AjudaModelView GetHelpId(Int16 id)
        {
            Help objretorno = new Help();

            HelpRepository tpprod = new HelpRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Help, AjudaModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<AjudaModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteHelpId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Help objretorno = new Help();
            HelpRepository tpprod = new HelpRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
