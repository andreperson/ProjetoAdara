using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Table("projeto")]
    public class Projeto
    {
        [Key]
        public Int16 projetoid { get; set; }
        public Int16 clienteid { get; set; }
        [ForeignKey("clienteid")]
        public virtual Cliente Cliente { get; set; }
        public int projetotipoid { get; set; }
        [ForeignKey("projetotipoid")]
        public virtual ProjetoTipo ProjetoTipo { get; set; }
        public int idiomaidfrom { get; set; }
        public int idiomaidto { get; set; }
        public int userid { get; set; }
        [ForeignKey("userid")]
        public virtual User User { get; set; }
        public int listaprecoid { get; set; }
        [ForeignKey("listaprecoid")]
        public virtual ListaPreco ListaPreco { get; set; }

        public string titulo { get; set; }
        public string numeroprojeto { get; set; }
        public string documento { get; set; }
        public int moedaidrecebe { get; set; }
        public DateTime? dataentregaprev { get; set; }
        public DateTime? dataentrega { get; set; }
        public string descricao { get; set; }
        public string obs { get; set; }
        public int status { get; set; }
        public DateTime? dataalt { get; set; }
        public DateTime dataincl { get; set; }
        public string usu { get; set; }
    }
}
