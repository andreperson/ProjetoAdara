using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;  

namespace Deia.Data
{

    public class Produto
    {
        public Int32 produtoID { get; set; }
        public string codigo { get; set;}
        public string descricao { get; set; }
        public Boolean status { get; set; }
    }


    [Table("Produto")] // Table name
    public class ProdutoTable
    {
        [Key] // Primary key
        public Int32 produtoID { get; set; }
        public string codigo { get; set; }
        public string descricao { get; set; }
        public Boolean status { get; set; }

    }


    public class DbConn : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
    }
}


    //<add name="ConexaoBD" connectionString="Server=mysql.unilimpesistema.com.br; uid=unilimpe01; pwd=uniuser123; database=unilimpe01; Port=3306;"/>
