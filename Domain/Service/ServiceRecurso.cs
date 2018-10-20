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
    public class ServiceRecurso
    {
        public static void InsertRecurso(RecursoModelView model)
        {
            Recurso objretorno = new Recurso();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RecursoModelView, Recurso>();
            var objtpprod = Mapper.Map<Recurso>(model);
            objtpprod.DataIncl = DateTime.Now;

            RecursoRepository tpprod = new RecursoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateRecurso(RecursoModelView model)
        {
            Recurso objretorno = new Recurso();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RecursoModelView, Recurso>();
            var objtpprod = Mapper.Map<Recurso>(model);
            
            //objtpprod.dataincl = DateTime.Now;
            RecursoRepository tpprod = new RecursoRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Recurso> getRecurso()
        {
            //busca no banco
            RecursoRepository tprep = new RecursoRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Recurso> getRecurso(Int16 userid)
        {
            //busca no banco
            RecursoRepository tprep = new RecursoRepository();
            var lst = tprep.Search(x => x.userid == userid).ToList();

            return lst;
        }

        public static RecursoModelView GetRecursoId(Int16 id)
        {
            Recurso objretorno = new Recurso();

            RecursoRepository tpprod = new RecursoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Recurso, RecursoModelView>();
            //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<RecursoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteRecursoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Recurso objretorno = new Recurso();
            RecursoRepository tpprod = new RecursoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }


        public static void DeleteRecurso(Int16 userid, Int16 competenciaid)
        {
            RecursoRepository tprep = new RecursoRepository();
            var lst = tprep.Search(x => x.userid == userid & x.competenciaid == competenciaid).ToList();
            int id = 0;

            foreach (var item in lst)
            {
                id = item.RecursoId;


                //busca o arquivo q sera apagado
                Recurso objretorno = new Recurso();
                RecursoRepository tpprod = new RecursoRepository();
                objretorno = tpprod.Find(id);


                //passa a entidade recuperada para deletar
                tpprod.Delete(objretorno);
                tpprod.Save();

            }


          
        }

    }
}
