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
    public class ServiceJobStatus
    {
        public static void InsertJobStatus(JobStatusModelView model)
        {
            JobStatus objretorno = new JobStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobStatusModelView, JobStatus>();
            var objtpprod = Mapper.Map<JobStatus>(model);

            JobStatusRepository tpprod = new JobStatusRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateJobStatus(JobStatusModelView model)
        {
            JobStatus objretorno = new JobStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobStatusModelView, JobStatus>();
            var objtpprod = Mapper.Map<JobStatus>(model);

            objtpprod.Dataalt = DateTime.Now;
            JobStatusRepository tpprod = new JobStatusRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<JobStatus> getJobStatus(bool visivel)
        {
            //busca no banco
            JobStatusRepository tprep = new JobStatusRepository();
            var lst = tprep.Search(x => x.Status == 1).OrderBy(x=>x.jobstatusid).ToList();

            return lst;
        }


        public static List<JobStatus> getJobStatus()
        {
            //busca no banco
            JobStatusRepository tprep = new JobStatusRepository();
            var lst = tprep.Search(x => x.Status != 0).OrderBy(x=>x.jobstatusid).ToList();

            return lst;
        }

        public static List<JobStatus> getJobStatusById(int id)
        {
            //busca no banco
            JobStatusRepository tprep = new JobStatusRepository();
            var lst = tprep.Search(x => x.jobstatusid == id).ToList();

            return lst;
        }

        public static int getJobStatusCountById(int id)
        {
            //busca no banco
            JobStatusRepository tprep = new JobStatusRepository();
            var qtde = tprep.Search(x => x.jobstatusid == id).Count();

            return qtde;
        }


        public static List<JobStatus> getJobStatusCombo()
        {
            //busca no banco
            JobStatusRepository tprep = new JobStatusRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            JobStatus obj = new JobStatus();
            obj.descricao = "";
            obj.jobstatusid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static JobStatusModelView GetJobStatusId(Int16 id)
        {
            JobStatus objretorno = new JobStatus();

            JobStatusRepository tpprod = new JobStatusRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<JobStatus, JobStatusModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<JobStatusModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteJobStatusId(Int16 id)
        {
            //busca o arquivo q sera apagado
            JobStatus objretorno = new JobStatus();
            JobStatusRepository tpprod = new JobStatusRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
