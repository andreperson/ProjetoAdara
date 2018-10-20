using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Service;


namespace Domain.Util
{
    public class formata
    {

        /// <summary>
        /// FORMATA COMO MOEDA
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>S
        public static string FormataMoeda(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                valor = "0";
            }

            string moeda = string.Format("{0:N2}", Convert.ToDouble(valor));

            return moeda;
        }


    }
}
