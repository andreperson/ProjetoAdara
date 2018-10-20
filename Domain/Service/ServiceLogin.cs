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
    public class ServiceLogin
    {
        public static void InsertLogin(LoginModelView model)
        {
            Login objretorno = new Login();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<LoginModelView, Login>();
            var objtpprod = Mapper.Map<Login>(model);

            LoginRepository tpprod = new LoginRepository();
            tpprod.Add(objtpprod);
            tpprod.Save();
        }

        public static void UpdateLogin(LoginModelView model)
        {
            Login objretorno = new Login();

            //faz o de para: objModelView para objEntity 
            Mapper.CreateMap<LoginModelView, Login>();
            var objtpprod = Mapper.Map<Login>(model);

            //objtpprod.dataincl = DateTime.Now;
            LoginRepository tpprod = new LoginRepository();
            tpprod.Edit(objtpprod);
            tpprod.Save();
        }


        
        public static List<Login> getLogin(Int16 id)
        {
            //busca no banco
            LoginRepository tprep = new LoginRepository();
            var lst = tprep.Search(x => x.userid == id).ToList();

            return lst;
        }


        //get produto ID
        public static LoginModelView GetLoginId(Int16 id)
        {
            Login objretorno = new Login();

            LoginRepository tpprod = new LoginRepository();
            objretorno = tpprod.Find(id);

            ////faz o de para: objEntity para objModelView
            //Mapper.CreateMap<Login, LoginModelView>();
            //var vretorno = Mapper.Map<LoginModelView>(objretorno);

            //guarda a imagem no arquivo que chega até a tela como texto.
        //    var img = objretorno.imagem;

            //faz o de para: objEntity para objModelView
            Mapper
                .CreateMap<Login, LoginModelView>();
                //.ForMember(x => x.imagem, option => option.Ignore());
            var vretorno = Mapper.Map<LoginModelView>(objretorno);

            //vretorno.arquivoimagem = img;

            return vretorno;
        }


        //delete tipo produto
        public static void DeleteLoginId(Int16 id)
        {
            //busca o arquivo q sera apagado
            Login objretorno = new Login();
            LoginRepository tpprod = new LoginRepository();
            objretorno = tpprod.Find(id);

            //passa a entidade recuperada para deletar
            tpprod.Delete(objretorno);
            tpprod.Save();
        }

    }
}
