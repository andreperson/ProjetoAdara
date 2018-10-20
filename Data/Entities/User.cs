using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public int  UserId { get; set; }
        public int usuariotipoid { get; set; }
        [ForeignKey("usuariotipoid")]
        public virtual UsuarioTipo UsuarioTipo { get; set; }

       
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public string imagem { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string UserAlt { get; set; }
    }
}
