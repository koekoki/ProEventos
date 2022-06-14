using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contextos
{
    public class ProEventosDataContext : DbContext
    {
        public ProEventosDataContext (DbContextOptions<ProEventosDataContext> options) : base(options){ }
         public DbSet<Evento> Eventos{get; set;}
         public DbSet<Lote> Lotes{get; set;}
         public DbSet<Palestrante> Palestrantes{get; set;}
         public DbSet<PalestranteEvento> PalestrantesEventos{get; set;}
         public DbSet<RedeSocial> RedesSociais{get; set;}

         protected override void OnModelCreating(ModelBuilder modelBuilder){
             modelBuilder .Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.eventoId, PE.palestranteId});

            modelBuilder.Entity<Evento>()
                        .HasMany(e => e.redesSociais)
                        .WithOne(rs => rs.evento)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>()
                        .HasMany(e => e.lotes)
                        .WithOne(rs => rs.evento)
                        .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                        .HasMany(e => e.redesSociais)
                        .WithOne(rs => rs.palestrante)
                        .OnDelete(DeleteBehavior.Cascade);
         }
    }
}