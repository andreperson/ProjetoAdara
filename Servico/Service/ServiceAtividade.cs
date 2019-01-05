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
    public class ServiceAtividade
    {
        public static void InsertAtividade(AtividadeModelView model)
        {
            Atividade objretorno = new Atividade();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<AtividadeModelView, Atividade>();
            var objtpprod = Mapper.Map<Atividade>(model);

            AtividadeRepository tpprod = new AtividadeRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateAtividade(AtividadeModelView model)
        {
            Atividade objretorno = new Atividade();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<AtividadeModelView, Atividade>();
            var objtpprod = Mapper.Map<Atividade>(model);

            objtpprod.Dataalt = DateTime.Now;
            AtividadeRepository tpprod = new AtividadeRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Atividade> getAtividade(bool visivel)
        {
            //busca no banco
            AtividadeRepository tprep = new AtividadeRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Atividade> getAtividade()
        {
            //busca no banco
            AtividadeRepository tprep = new AtividadeRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Atividade> getAtividadeCombo()
        {
            //busca no banco
            AtividadeRepository tprep = new AtividadeRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Atividade obj = new Atividade();
            obj.descricao = "";
            obj.atividadeid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static AtividadeModelView GetAtividadeId(Int16 id)
        {
            Atividade objretorno = new Atividade();

            AtividadeRepository tpprod = new AtividadeRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Atividade, AtividadeModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<AtividadeModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteAtividadeId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Atividade objretorno = new Atividade();
            AtividadeRepository tpprod = new AtividadeRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
