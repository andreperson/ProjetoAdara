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
    public class ServiceJobStatusHistorico
    {
        public static void InsertJobStatusHistorico(JobStatusHistoricoModelView model)
        {
            JobStatusHistorico objretorno = new JobStatusHistorico();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobStatusHistoricoModelView, JobStatusHistorico>();
            var objtpprod = Mapper.Map<JobStatusHistorico>(model);

            JobStatusHistoricoRepository tpprod = new JobStatusHistoricoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateJobStatusHistorico(JobStatusHistoricoModelView model)
        {
            JobStatusHistorico objretorno = new JobStatusHistorico();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobStatusHistoricoModelView, JobStatusHistorico>();
            var objtpprod = Mapper.Map<JobStatusHistorico>(model);

            objtpprod.Dataincl = DateTime.Now;
            JobStatusHistoricoRepository tpprod = new JobStatusHistoricoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<JobStatusHistorico> getJobStatusHistorico(bool visivel)
        {
            //busca no banco
            JobStatusHistoricoRepository tprep = new JobStatusHistoricoRepository();
            var lst = tprep.Search(x => x.jobstatusid != 0).OrderBy(x=>x.jobstatushistoricoid).ToList();

            return lst;
        }


        public static List<JobStatusHistorico> getJobStatusHistorico()
        {
            //busca no banco
            JobStatusHistoricoRepository tprep = new JobStatusHistoricoRepository();
            var lst = tprep.Search(x => x.jobstatusid != 0).ToList();

            return lst;
        }

        public static List<JobStatusHistorico> getJobStatusHistoricoByJobId(Int16 jobid)
        {
            //busca no banco
            JobStatusHistoricoRepository tprep = new JobStatusHistoricoRepository();
            var lst = tprep.Search(x => x.jobid == jobid).ToList();

            return lst;
        }

        public static List<JobStatusHistorico> getJobStatusHistoricoById(int id)
        {
            //busca no banco
            JobStatusHistoricoRepository tprep = new JobStatusHistoricoRepository();
            var lst = tprep.Search(x => x.jobstatushistoricoid == id).ToList();

            return lst;
        }

        public static int getJobStatusHistoricoCountById(int id)
        {
            //busca no banco
            JobStatusHistoricoRepository tprep = new JobStatusHistoricoRepository();
            var qtde = tprep.Search(x => x.jobstatushistoricoid == id).Count();

            return qtde;
        }

        

        //get produto ID
        public static JobStatusHistoricoModelView GetJobStatusHistoricoId(Int16 id)
        {
            JobStatusHistorico objretorno = new JobStatusHistorico();

            JobStatusHistoricoRepository tpprod = new JobStatusHistoricoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<JobStatusHistorico, JobStatusHistoricoModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<JobStatusHistoricoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteJobStatusHistoricoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            JobStatusHistorico objretorno = new JobStatusHistorico();
            JobStatusHistoricoRepository tpprod = new JobStatusHistoricoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
