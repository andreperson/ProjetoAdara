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
    public class ServiceJob
    {
        public static void InsertJob(JobModelView model)
        {
            Job objretorno = new Job();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobModelView, Job>();
            var objtpprod = Mapper.Map<Job>(model);

            JobRepository tpprod = new JobRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateJob(JobModelView model)
        {
            Job objretorno = new Job();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobModelView, Job>();
            var objtpprod = Mapper.Map<Job>(model);

            objtpprod.Dataalt = DateTime.Now;
            JobRepository tpprod = new JobRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Job> getJob(bool visivel)
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Job> getJob()
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Job> getJobCombo()
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Job obj = new Job();
            obj.jobid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.Fuzzie.descricao).ToList();

            return lstorder;
        }

        public static List<Job> getJobByProjetoid(Int16 id)
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.projetoid == id).OrderBy(s => s.dataprazo).ToList();
            return lst;
        }


        //get produto ID
        public static JobModelView GetJobId(Int16 id)
        {
            Job objretorno = new Job();

            JobRepository tpprod = new JobRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Job, JobModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<JobModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteJobId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Job objretorno = new Job();
            JobRepository tpprod = new JobRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
