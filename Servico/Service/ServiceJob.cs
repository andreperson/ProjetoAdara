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


        public static void InsertGet(JobModelView model)
        {
            Job objretorno = new Job();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<JobModelView, Job>();
            var objtpprod = Mapper.Map<Job>(model);

            JobRepository tpprod = new JobRepository();
            //objretorno = tpprod.InsertGet(objtpprod);
            tpprod.Save();

            //grava o histórico
            JobStatusHistoricoModelView modelh = new JobStatusHistoricoModelView();
            modelh.dataincl = DateTime.Now;
            modelh.jobid = objretorno.jobid;
            modelh.jobstatusid = model.jobstatusid;
            modelh.user = model.user;
            ServiceJobStatusHistorico.InsertJobStatusHistorico(modelh);
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
            var lst = tprep.Search(x => x.jobstatusid == 1).ToList();

            return lst;
        }


        public static List<Job> getJob()
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.jobstatusid != 0).ToList();

            return lst;
        }


        public static List<Job> getJobCombo()
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.jobstatusid == 1).ToList();

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

        public static List<Job> getJobByUserid(int id)
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.userid == id).OrderBy(s => s.dataprazo).ToList();
            return lst;
        }

        public static List<Job> getJobByStatusUserid(int jobstatusid, int userid)
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.userid == userid & x.jobstatusid == jobstatusid).ToList();
            return lst;
        }


        //get job ID
        public static JobModelView GetJobId(Int16 id)
        {
            Job objretorno = new Job();

            JobRepository tpprod = new JobRepository();
            objretorno = tpprod.Find(id);

            JobModelView model = TranslateToModel(objretorno);

            return model;
        }

        private static JobModelView TranslateToModel(Job objretorno)
        {
            JobModelView model = new JobModelView();

            model.jobid = objretorno.jobid;
            model.projetoid = objretorno.projetoid;
            model.userid = objretorno.userid;
            model.clienteid = objretorno.clienteid;
            model.fuzzieid = objretorno.fuzzieid;
            model.jobstatusid = objretorno.jobstatusid;
            model.qtdepalavrajob = objretorno.qtdepalavrajob;
            model.idiomaidfrom = objretorno.idiomaidfrom;
            model.idiomaidto = objretorno.idiomaidto;
            model.valorporpalavrajob = objretorno.valorporpalavrajob;
            model.dataprazo = objretorno.dataprazo;
            model.dataentrega = objretorno.dataentrega;
            model.dataalt = objretorno.Dataalt;
            model.user = objretorno.User;
            
            return model;
        }

        public static List<Job> getJobByJobId(Int16 id)
        {
            //busca no banco
            JobRepository tprep = new JobRepository();
            var lst = tprep.Search(x => x.jobid== id).OrderBy(s => s.dataprazo).ToList();
            return lst;
        }


        //delete tipo produto
        public static int DeleteJobId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Job objretorno = new Job();
            JobRepository tpprod = new JobRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();

            return 1;
        }





    }
}
