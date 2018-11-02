using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Util
{
    public class config
    {

        public static string UrlImg
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.URL.IMG"].ToString();
            }
        }


        public static string UrlImgProdutos
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.URL.ImgProdutos"].ToString();
            }
        }

        public static string UrlSite
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.URL.SITE"].ToString();
            }
        }


        public static string PathUpImg
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Path.UpImg"].ToString();
            }
        }

        public static string PathUpBanner
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Path.UpBanner"].ToString();
            }
        }

        public static string Idioma
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Idioma"].ToString();
            }
        }

        public static string Gerente
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["Configuration.Gerente"].ToString();
            }
        }

        public static string Title
        {
            get
            {
                return "Sprach";
            }
        }

    }
}
