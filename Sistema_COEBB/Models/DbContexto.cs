using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sistema_COEBB.Models
{
    public class DbContexto : DbContext
    {
        public DbContexto() : base("Coebbdb") { }

        public DbSet<Equipe> Equipes { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}