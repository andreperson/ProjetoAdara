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
    public class ServiceRelatorioTemp
    {
        public static void InsertRelatorioTemp(RelatorioTempModelView model)
        {
            RelatorioTemp objretorno = new RelatorioTemp();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioTempModelView, RelatorioTemp>();
            var objtpprod = Mapper.Map<RelatorioTemp>(model);

            objtpprod.DataIncl = DateTime.Now;
            RelatorioTempRepository tpprod = new RelatorioTempRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateRelatorioTemp(RelatorioTempModelView model)
        {
            RelatorioTemp objretorno = new RelatorioTemp();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioTempModelView, RelatorioTemp>();
            var objtpprod = Mapper.Map<RelatorioTemp>(model);

            RelatorioTempRepository tpprod = new RelatorioTempRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<RelatorioTemp> getRelatorioTemp(Int16 repreid)
        {
            //busca no banco
            RelatorioTempRepository tprep = new RelatorioTempRepository();
            var lst = tprep.Search(x => x.representanteid == repreid).ToList();

            return lst;
        }


        //get produto ID
        public static RelatorioTempModelView GetRelatorioTempId(Int16 id)
        {
            RelatorioTemp objretorno = new RelatorioTemp();

            RelatorioTempRepository tpprod = new RelatorioTempRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<RelatorioTemp, RelatorioTempModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<RelatorioTempModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteRelatorioTemp(Int16 repreid)
        {
            RelatorioTempRepository tprep = new RelatorioTempRepository();
            tprep.DeleteRange(x => x.representanteid == repreid);
            tprep.Save();
        }


        //delete tipo produto
        public static void DeleteRelatorioTempId(Int16 id)
        {
            //busca o arquivo q sera apagado
            RelatorioTemp objretorno = new RelatorioTemp();
            RelatorioTempRepository tpprod = new RelatorioTempRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
