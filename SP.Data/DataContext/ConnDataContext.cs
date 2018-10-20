using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;  
using SP.Data.Entities;

namespace SP.Data.DataContext
{
    public class ConnDataContext : DbContext
    {
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Atividade> Atividade { get; set; }
        public DbSet<AtividadePorCategoria> AtividadePorCategoria { get; set; }

        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Codigo> Codigo { get; set; }
        public DbSet<CodigoBarras> CodigoBarras { get; set; }
        
        public DbSet<EtiquetaConfiguracao> EtiquetaConfiguracao { get; set; }
        public DbSet<EtiquetaTamanho> EtiquetaTamanho { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<EventoTipo> EventoTipo { get; set; }
        public DbSet<EventoUsuario> EventoUsuario { get; set; }

        public DbSet<Imagem> Imagem { get; set; }
        public DbSet<Imprime> Imprime { get; set; }

        public DbSet<Login> Login { get; set; }
        
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuSub> MenuSub { get; set; }

        public DbSet<Participante> Participante { get; set; }
        public DbSet<ParticipanteConfiguracao> ParticipanteConfiguracao { get; set; }
        public DbSet<ParticipanteEvento> ParticipanteEvento { get; set; }
        public DbSet<ParticipanteFinanceiro> ParticipanteFinanceiro { get; set; }

        public DbSet<Pergunta> Pergunta { get; set; }
        public DbSet<Pesquisa> Pesquisa { get; set; }

        public DbSet<Respondido> Respondido { get; set; }
        public DbSet<Resposta> Resposta { get; set; }

        public DbSet<Sala> Sala { get; set; }
        
        public DbSet<User> User { get; set; }
        public DbSet<UsuarioMenu> UsuarioMenu { get; set; }
        public DbSet<UsuarioTipo> UsuarioTipo { get; set; }
    }
}
