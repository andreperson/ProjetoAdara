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
    public class ServiceRelatorio
    {
        public static void InsertRelatorio(RelatorioModelView model)
        {
            Relatorio objretorno = new Relatorio();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioModelView, Relatorio>();
            var objtpprod = Mapper.Map<Relatorio>(model);

            objtpprod.DataIncl = DateTime.Now;
            RelatorioRepository tpprod = new RelatorioRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateRelatorio(RelatorioModelView model)
        {
            Relatorio objretorno = new Relatorio();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<RelatorioModelView, Relatorio>();
            var objtpprod = Mapper.Map<Relatorio>(model);

            objtpprod.Dataalt = DateTime.Now;
            RelatorioRepository tpprod = new RelatorioRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }

  
        public static List<Relatorio> getRelatorio(bool visivel)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.Status == 1).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorio(Int16 repreid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.Status==1).ToList();

            return lst;
        }


        public static List<Relatorio> getRelatorio(Int16 repreid, Int16 boletoid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.boletoid==boletoid & x.Status == 1).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorio()
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.relatorioid != 0).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorio(Int16 repreid, string venc)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            List<Relatorio> lst = new List<Relatorio>();

            string dthj = Convert.ToString(DateTime.Now).Substring(0, 10);
            if (venc == "t")
            {
                var lstall = tprep.Search(x => x.representanteid == repreid & x.Status == 1 & x.relatoriostatusid == 1).ToList();
                lst = (from x in lstall where Convert.ToString(x.dataRecebto).Substring(0, 10) == dthj select x).ToList();

            }
            else if (venc == "a")
            {
                lst = tprep.Search(x => x.representanteid == repreid & x.Status == 1 & x.relatoriostatusid == 1 & x.dataRecebto <= DateTime.Now).ToList();
            }

            return lst;
        }

        public static List<Relatorio> getRelatorioId(Int16 repreid, Int16 fechaid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.relatorioid == fechaid & x.Status == 1).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorioTotal(int mes, Int16 repreid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.Status == 1 & x.dataRecebto.Month == mes & x.representanteid == repreid & x.relatoriostatusid == 1).ToList();

            return lst;
        }


        public static List<Relatorio> getRelatorioRecebidasTotal(int mes, Int16 repreid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.Status == 1 & x.datapagto.Month == mes & x.representanteid == repreid & x.relatoriostatusid == 2).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorioRecebidasAno(Int16 repreid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();
            var lst = tprep.Search(x => x.representanteid == repreid & x.relatoriostatusid == 2 & x.Status == 1 & x.datapagto.Year == DateTime.Now.Year).OrderBy(x => x.datapagto).ToList();

            return lst;
        }

        public static List<Relatorio> getRelatorioByBusca(RelatorioModelView model)
        {
            //busca no banco
            List<Relatorio> lst = new List<Relatorio>();
            RelatorioRepository tprep = new RelatorioRepository();

            //busca inicial pelo representante
            lst = tprep.Search(tp => tp.representanteid == model.representanteid).ToList();

            //fabrica
            if (model.fabricaid != 0)
            {
                lst = (from x in lst where x.fabricaid == model.fabricaid select x).ToList();
            }

            //data boleto
            if (model.dtboletode != DateTime.Today | model.dtboletoate != DateTime.Today)
            {
                lst = (from x in lst where x.Boleto.Dtboleto >= model.dtboletode & x.Boleto.Dtboleto <= model.dtboletoate select x).ToList();
            }

            //data vencimento
            if (model.dtvencimentode != DateTime.Today | model.dtvencimentoate != DateTime.Today)
            {
                lst = (from x in lst where x.Boleto.DtVencimento >= model.dtboletode & x.Boleto.DtVencimento <= model.dtboletoate select x).ToList();
            }

            //boletoid
            if (model.boletoid != 0)
            {
                lst = (from x in lst where x.talaoitensid == model.boletoid select x).ToList();
            }

            //cliente
            if (model.clienteid != 0)
            {
                lst = (from x in lst where x.clienteid == model.clienteid select x).ToList();
            }

            //Assessor
            if (model.assessorid != 0)
            {
                lst = (from x in lst where x.assessorid == model.assessorid select x).ToList();
            }


            //Número Boleto de - ate
            if (model.nrboletode != 0 & model.nrboletoate != 0)
            {
                lst = (from x in lst where x.talaoitensid >= model.nrboletode & x.talaoitensid <= model.nrboletoate select x).ToList();
            }

            if (model.relatoriostatusid != 0)
            {
                lst = (from x in lst where x.relatoriostatusid == model.relatoriostatusid select x).ToList();
            }
          
            return lst;
        }

        public static RelatorioModelView GetRelatorioId(Int16 id)
        {
            Relatorio objretorno = new Relatorio();

            RelatorioRepository tpprod = new RelatorioRepository();
            objretorno = tpprod.Find(id);

            Mapper
                .CreateMap<Relatorio, RelatorioModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<RelatorioModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }

        public static Int16 getRelatorioMax(Int16 repreid)
        {
            //busca no banco
            RelatorioRepository tprep = new RelatorioRepository();

            var fec = tprep.Search(x => x.representanteid == repreid).OrderByDescending(x => x.relatorioid).FirstOrDefault();

            return fec.relatorioid;
        }

        //delete tipo produto
        public static void DeleteRelatorioId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Relatorio objretorno = new Relatorio();
            RelatorioRepository tpprod = new RelatorioRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
