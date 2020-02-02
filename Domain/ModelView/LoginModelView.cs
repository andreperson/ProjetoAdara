using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.ModelView
{
    public class LoginModelView
    {
        public Int16 loginid { get; set; }
        public Int16 userid { get; set; }
        public string email { get; set; }
        public string apelido { get; set; }
        public string origem { get; set; }
        public DateTime? dataalt { get; set; }

        [Display(Name = "Users")]
        public List<User> users { get; set; }
    }
}
