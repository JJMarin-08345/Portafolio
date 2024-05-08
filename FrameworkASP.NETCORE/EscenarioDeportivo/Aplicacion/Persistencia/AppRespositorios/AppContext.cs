using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Dominio;
using System;
using System.Collections.Generic;

namespace Persistencia
{
    public class AppContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Todo torneo se relaciona con varios equipos, todo equipo se relaciona con varios torneos
            //modelBuilder.Entity<Equipo>().HasMany(E=>E.Torneos).WithMany(E=>E.Equipos);
            modelBuilder.Entity<Arbitro>().HasIndex(ar => ar.Documento).IsUnique();
            modelBuilder.Entity<ColegioInstruccion>().HasIndex(c => c.Nit).IsUnique();
            modelBuilder.Entity<Deportista>().HasIndex(de => de.Documento).IsUnique();
            modelBuilder.Entity<Entrenador>().HasIndex(en => en.Documento).IsUnique();
            modelBuilder.Entity<Equipo>().HasIndex(eq => eq.Nombre).IsUnique();
            modelBuilder.Entity<Escenario>().HasIndex(esc => esc.Nombre).IsUnique();
            modelBuilder.Entity<Municipio>().HasIndex(m => m.Nombre).IsUnique();
            modelBuilder.Entity<Patrocinador>().HasIndex(pat => pat.Documento).IsUnique();
            modelBuilder.Entity<Torneo>().HasIndex(tor => tor.Nombre).IsUnique();
            modelBuilder.Entity<UnidadDeportiva>().HasIndex(uni => uni.Nombre).IsUnique();
            //Evitar eliminacion cascada Patrocinador
            modelBuilder.Entity<Patrocinador>()
                        .HasMany(p => p.Equipos)
                        .WithOne(e => e.patrocinador)
                        .OnDelete(DeleteBehavior.Restrict);
            //Evitar eliminacion cascada Colegio
            modelBuilder.Entity<ColegioInstruccion>()
                        .HasMany(c => c.Arbitros)
                        .WithOne(a => a.Colegio)
                        .OnDelete(DeleteBehavior.Restrict);
            //Evitar eliminacion cascada Equipos
            //modelBuilder.Entity<Equipo>().
        }

        //Conectar con la base de datos
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= VIVOBOOKASUSM51; Database=BD_EscenarioDeportivo; Trusted_Connection=True; Encrypt=False");
            }
        }

        /*Todo esto de abajo se hace para que la base de datos cree
        las tablas, ademas de servir para luego usarlas en los métodos CRUD
        */
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Torneo> Torneos { get; set; }
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<TorneoEquipo> TorneoEquipos { get; set; }
        public DbSet<Patrocinador> Patrocinadores { get; set; }
        public DbSet<Arbitro> Arbitros { get; set; }
        public DbSet<ColegioInstruccion> ColegiosInstrucciones { get; set; }
        public DbSet<UnidadDeportiva> UnidadesDeportivas { get; set; }
        public DbSet<Entrenador> Entrenadores { get; set; }
        public DbSet<Deportista> Deportistas { get; set; }
        public DbSet<Escenario> Escenarios { get; set; }
        //Atajo teclado para abrir la terminal: Ctrl+Shift+Ñ

        //Comando para crear la migracion, debe estar en el la carpeta de persistencia:
        //dotnet ef migrations add ElNombreQueQuiera
        //Comando para crear o actualizar la Base de Datos, debe estar en la carpeta persistencia:
        //dotnet ef database update 

        //Comando para verificar errores en las capas cualquiera:
        //dotnet build

        //Comando para crear la Consola:
        //dotnet new console -o NombreQueLeQuieraPoner(usualmente es Consola)

        //Comando para correr la consola:
        //dotnet run 

    }

}