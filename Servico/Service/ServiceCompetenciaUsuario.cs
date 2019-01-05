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
    public class ServiceCompetenciaUsuario
    {
        public static void InsertCompetenciaUser(CompetenciaUsuarioModelView model)
        {
            CompetenciaUser objretorno = new CompetenciaUser();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<CompetenciaUsuarioModelView, CompetenciaUser>();
            var objtpprod = Mapper.Map<CompetenciaUser>(model);

            objtpprod.DataIncl = DateTime.Now;
            CompetenciaUserRepository tpprod = new CompetenciaUserRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateCompetenciaUser(CompetenciaUsuarioModelView model)
        {
            CompetenciaUser objretorno = new CompetenciaUser();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<CompetenciaUsuarioModelView, CompetenciaUser>();
            var objtpprod = Mapper.Map<CompetenciaUser>(model);

            objtpprod.Dataalt = DateTime.Now;
            CompetenciaUserRepository tpprod = new CompetenciaUserRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        public static List<CompetenciaUser> getCompetenciaUser(bool visivel)
        {
            //busca no banco
            CompetenciaUserRepository tprep = new CompetenciaUserRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<CompetenciaUser> getCompetenciaUser()
        {
            //busca no banco
            CompetenciaUserRepository tprep = new CompetenciaUserRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

        //get produto ID
        public static CompetenciaUsuarioModelView GetCompetenciaUserId(Int16 id)
        {
            CompetenciaUser objretorno = new CompetenciaUser();

            CompetenciaUserRepository tpprod = new CompetenciaUserRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<CompetenciaUser, CompetenciaUsuarioModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<CompetenciaUsuarioModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteCompetenciaUserId(Int16 id)
        {
            //busca o arquivo q sera apagado
            CompetenciaUser objretorno = new CompetenciaUser();
            CompetenciaUserRepository tpprod = new CompetenciaUserRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
