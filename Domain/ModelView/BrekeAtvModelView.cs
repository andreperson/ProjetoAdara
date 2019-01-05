using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class BrekeAtvModelView
    {
        public int brekedownid { get; set; }
        public int atividadeid { get; set; }

        public string breke { get; set; }
        public string atv { get; set; }

        public int valor { get; set; }
        public int perc { get; set; }

    }
}
