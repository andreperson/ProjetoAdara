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
    public class ServiceRelatorioStatus
    {
        public static void InsertrelatorioStatus(RelatorioStatusModelView model)
        {
            RelatorioStatus objretorno = new RelatorioStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioStatusModelView, RelatorioStatus>();
            var objtpprod = Mapper.Map<RelatorioStatus>(model);

            RelatorioStatusRepository tpprod = new RelatorioStatusRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdaterelatorioStatus(RelatorioStatusModelView model)
        {
            RelatorioStatus objretorno = new RelatorioStatus();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioStatusModelView, RelatorioStatus>();
            var objtpprod = Mapper.Map<RelatorioStatus>(model);

            objtpprod.Dataalt = DateTime.Now;
            RelatorioStatusRepository tpprod = new RelatorioStatusRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<RelatorioStatus> getrelatorioStatus(bool visivel)
        {
            //busca no banco
            RelatorioStatusRepository tprep = new RelatorioStatusRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<RelatorioStatus> getrelatorioStatusCombo()
        {
            //busca no banco
            RelatorioStatusRepository tprep = new RelatorioStatusRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            RelatorioStatus obj = new RelatorioStatus();
            obj.Descricao = "_";
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.Descricao).ToList();

            return lstorder;
        }
        
        public static List<RelatorioStatus> getrelatorioStatus(Int16 statusid)
        {
            //busca no banco
            RelatorioStatusRepository tprep = new RelatorioStatusRepository();
            var lst = tprep.Search(x => x.relatoriostatusid == statusid).ToList();

            return lst;
        }

        public static List<RelatorioStatus> getrelatorioStatus()
        {
            //busca no banco
            RelatorioStatusRepository tprep = new RelatorioStatusRepository();
            var lst = tprep.Search(x => x.relatoriostatusid != 0).ToList();

            return lst;
        }


        //get produto ID
        public static RelatorioStatusModelView GetrelatorioStatusId(Int16 id)
        {
            RelatorioStatus objretorno = new RelatorioStatus();

            RelatorioStatusRepository tpprod = new RelatorioStatusRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<RelatorioStatus, RelatorioStatusModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<RelatorioStatusModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleterelatorioStatusId(Int16 id)
        {
            //busca o arquivo q sera apagado
            RelatorioStatus objretorno = new RelatorioStatus();
            RelatorioStatusRepository tpprod = new RelatorioStatusRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
