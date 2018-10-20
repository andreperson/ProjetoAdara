using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using System.Web;


namespace Domain.ModelView
{
    public class ProjetoModelView
    {
        [Display(Name = "ID do Projeto")]
        public Int16 projetoid { get; set; }

        [Required(ErrorMessage = "Cliente")]
        [Display(Name = "Cliente")]
        public Int16 clienteid { get; set; }

        [Display(Name = "Competências")]
        public int competenciaid { get; set; }


        [Display(Name = "Lista de Preços")]
        public int listaprecoid { get; set; }

        [Display(Name = "Cliente Preços")]
        public int clienteprecoid { get; set; }

        [Display(Name = "Par de Idiomas")]
        public int paridiomaid { get; set; }

        [Display(Name = "Gestor do Projeto")]
        public Int16 userid { get; set; }

        [Required(ErrorMessage = "Número")]
        [Display(Name = "Número")]
        public string numeroprojeto{ get; set; }

        [Required(ErrorMessage = "Título")]
        [Display(Name = "Título")]
        public string titulo { get; set; }

        [Display(Name = "Número de Palavras")]
        [Required(ErrorMessage = "Número de Palavras")]
        public int numeropalavras { get; set; }

        [Display(Name = "Moeda Recebimento")]
        public int moedaidrecebe { get; set; }

        [Display(Name = "Moeda Pagamento")]
        public int moedaidpaga { get; set; }

        [Display(Name = "Câmbio")]
        public double cambio { get; set; }

        [Display(Name = "Valor Calculado")]
        public double valorcalculado { get; set; }

        [Display(Name = "Valor do Projeto")]
        public double valorprojeto { get; set; }
    
        [Display(Name = "Prazo em Horas")]
        public string prazohoras { get; set; }

        [Display(Name = "Previsão de Entrega")]
        public DateTime? dataentregaprev { get; set; }

        [Display(Name = "Data Entrega")]
        public DateTime? dataentrega { get; set; }

        [Display(Name = "Descrição")]
        public string descricao { get; set; }

        [Display(Name = "Obs")]
        public string obs { get; set; }

        [Display(Name = "Documento / Anexo")]
        public HttpPostedFileBase documento { get; set; }

        [Display(Name = "Arquivo Documento / Anexo")]
        public string documentoanexo { get; set; }

        [Required(ErrorMessage = "Lista de Preços")]
        [Display(Name = "Informe a Lista de Preços")]
        public string tipolistapreco { get; set; } // cliente  geral 

        public bool statusb { get; set; }
        public int status { get; set; }
        public DateTime? Dataalt { get; set; }
        public DateTime DataIncl { get; set; }
        public string usu { get; set; }
        public Int16 menuid { get; set; }
        public Int16 menusubid { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Projeto> Projetos { get; set; }
        public List<User> Usuarios { get; set; }
        public List<Moeda> Moedas { get; set; }
        public List<Competencia> Competencias { get; set; }
        public List<ParIdioma> ParIdiomas { get; set; }
        public List<ClientePreco> ClientePrecos { get; set; }
        public List<ListaPreco> ListaPrecos { get; set; }

    }
}
