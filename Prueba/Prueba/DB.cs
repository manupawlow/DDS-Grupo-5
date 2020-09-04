using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Prueba
{
    class DB : DbContext
    {
        public virtual DbSet<Persona> personas { get; set; }
        public virtual DbSet<Perro> perros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            // Cargar connection strings directamente en el código es peligroso...
            // Solución: http://go.microsoft.com/fwlink/?LinkId=723263
            optionsBuilder.UseMySQL("server=localhost;database=prueba;user=root;password=;");


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<Perro>()
                .HasOne<Persona>(s => s.duenio)
                .WithMany(g => g.perros)
                .HasForeignKey(s => s.id_duenio);
                

            /*
            modelBuilder.Entity<Post>()
                .HasRequired<Usuario>(s => s.creador)
                .WithMany(g => g.posts)
                .HasForeignKey<int>(s => s.creador_id);
            */

        }
    }
}
