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
    public class ServiceBrekedown
    {
        public static void InsertBrekedown(BrekeModelView model)
        {
            Brekedown objretorno = new Brekedown();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<BrekeModelView, Brekedown>();
            var objtpprod = Mapper.Map<Brekedown>(model);

            BrekedownRepository tpprod = new BrekedownRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateBrekedown(BrekeModelView model)
        {
            Brekedown objretorno = new Brekedown();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<BrekeModelView, Brekedown>();
            var objtpprod = Mapper.Map<Brekedown>(model);

            objtpprod.Dataalt = DateTime.Now;
            BrekedownRepository tpprod = new BrekedownRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Brekedown> getBrekedown(bool visivel)
        {
            //busca no banco
            BrekedownRepository tprep = new BrekedownRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }


        public static List<Brekedown> getBrekedown()
        {
            //busca no banco
            BrekedownRepository tprep = new BrekedownRepository();
            var lst = tprep.Search(x => x.Status != 0).ToList();

            return lst;
        }

         
        public static List<Brekedown> getBrekedownCombo()
        {
            //busca no banco
            BrekedownRepository tprep = new BrekedownRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            Brekedown obj = new Brekedown();
            obj.descricao = "";
            obj.brekedownid = 0;
            lst.Add(obj);

            var lstorder = lst.OrderBy(s => s.descricao).ToList();

            return lstorder;
        }



        //get produto ID
        public static BrekeModelView GetBrekedownId(Int16 id)
        {
            Brekedown objretorno = new Brekedown();

            BrekedownRepository tpprod = new BrekedownRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Brekedown, BrekeModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<BrekeModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteBrekedownId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Brekedown objretorno = new Brekedown();
            BrekedownRepository tpprod = new BrekedownRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
