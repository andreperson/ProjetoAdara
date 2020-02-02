using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("user")]
    public class User
    {
        [Key]
        public Int16  UserId { get; set; }
        public int usuariotipoid { get; set; }
        [ForeignKey("usuariotipoid")]
        public virtual UsuarioTipo UsuarioTipo { get; set; }

       
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Apelido { get; set; }
        public string imagem { get; set; }
        public string Email { get; set; }
        public DateTime? dtnasc { get; set; }
        public string curso { get; set; }
        public string instituicao { get; set; }
        public string formacao { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Pais { get; set; }
        public string CEP { get; set; }
        public string About { get; set; }
        public string Senha { get; set; }
        public int recebeemails { get; set; }
        public int Status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string UserAlt { get; set; }
    }
}
