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
    public class ServiceProjeto
    {
        public static void InsertProjeto(ProjetoModelView model)
        {
            Projeto objretorno = new Projeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoModelView, Projeto>();
            var objtpprod = Mapper.Map<Projeto>(model);

            ////pega o nome do arquivo
            if (model.documento != null)
            { objtpprod.documento = model.documento.FileName; }

            objtpprod.dataincl = DateTime.Now;
            ProjetoRepository tpprod = new ProjetoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }


        public static Int16 InsertGetProjeto(ProjetoModelView model)
        {
            Projeto objretorno = new Projeto();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<ProjetoModelView, Projeto>();
            var objtpprod = Mapper.Map<Projeto>(model);

            ////pega o nome do arquivo
            if (model.documento != null)
            { objtpprod.documento = model.documento.FileName; }

            objtpprod.dataincl = DateTime.Now;
            ProjetoRepository tpprod = new ProjetoRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();


            //You can get the ID here
            Int16 last_insert_id = objtpprod.projetoid;

            return last_insert_id;

        }

        public static void UpdateProjeto(ProjetoModelView model)
        {
            try
            {

                Projeto objretorno = new Projeto();

                //faz o de para: objModelView para objEntity 
                Mapper.CreateMap<ProjetoModelView, Projeto>();
                var objtpprod = Mapper.Map<Projeto>(model);

                ////pega o nome da Produto
                if (model.documento != null)
                {
                    objtpprod.documento = model.documento.FileName;
                }
                else
                {
                    objtpprod.documento = model.documentoanexo;
                }

                objtpprod.dataalt = DateTime.Now;
                ProjetoRepository tpprod = new ProjetoRepository();
                tpprod.Edit(objtpprod);
                tpprod.Save();
            }
            catch (Exception ex)
            {
                String xxx = ex.Message;
                throw;
            }

        }


        public static List<Projeto> getProjeto(bool visivel)
        {
            //busca no banco
            ProjetoRepository tprep = new ProjetoRepository();
            var lst = tprep.Search(x => x.status == 1).ToList();

            return lst;
        }

        public static List<Projeto> getProjeto()
        {
            //busca no banco
            ProjetoRepository tprep = new ProjetoRepository();
            var lst = tprep.Search(x => x.status != 0).ToList();

            return lst;
        }


        public static List<Projeto> getProjeto(Int16 userid)
        {
            //busca no banco
            ProjetoRepository tprep = new ProjetoRepository();
            var lst = tprep.Search(x => x.userid == userid).ToList();

            return lst;
        }

        public static List<Projeto> getProjetobycliente(Int16 clienteid)
        {
            //busca no banco
            ProjetoRepository tprep = new ProjetoRepository();
            var lst = tprep.Search(x => x.clienteid == clienteid).ToList();

            return lst;
        }

        //get produto ID
        public static ProjetoModelView GetProjetoId(Int16 id)
        {
            Projeto objretorno = new Projeto();

            ProjetoRepository tpprod = new ProjetoRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Projeto, ProjetoModelView>();
            //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<ProjetoModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteProjetoId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Projeto objretorno = new Projeto();
            ProjetoRepository tpprod = new ProjetoRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
