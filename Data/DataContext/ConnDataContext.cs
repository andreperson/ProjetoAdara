using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;  
using Data.Entities;

namespace Data.DataContext
{
    public class ConnDataContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ClientePreco> ClientePreco { get; set; }
        public DbSet<ClienteTipo> ClienteTipo { get; set; }
        public DbSet<Competencia> Competencia { get; set; }
        public DbSet<CompetenciaUser> Competencia_User { get; set; }

        public DbSet<Idioma> Idioma { get; set; }
        
        public DbSet<Login> Login { get; set; }

        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuSub> MenuSub { get; set; }
        public DbSet<Moeda> Moeda { get; set; }

        public DbSet<ParIdioma> ParIdioma { get; set; }
        public DbSet<ListaPreco> ListaPreco { get; set; }
        public DbSet<Projeto> Projeto { get; set; }
        public DbSet<ProjetoCompetencia> ProjetoCompetencia { get; set; }
        public DbSet<ProjetoTipo> ProjetoTipo { get; set; }

        public DbSet<Recurso> Recurso { get; set; }

        public DbSet<UF> UF { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UsuarioMenu> UsuarioMenu { get; set; }
        public DbSet<UsuarioMenuSub> UsuarioMenuSub { get; set; }
        public DbSet<UsuarioTipo> UsuarioTipo { get; set; }
    }
}
