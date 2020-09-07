using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Biblioteca_Ejercicio_34.Modelo;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Biblioteca_Ejercicio_34
{
    class BaseDeDatos : DbContext
    {
        public DbSet<Libro> libros { get; set; }
        public DbSet<Lector> lectores { get; set; }
        public DbSet<Autor> autores { get; set; }
        public DbSet<Prestamo> prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=biblioteca;user=root;password=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Fluent API
            modelBuilder.Entity<Libro>()
              .HasOne<Autor>(s => s.autor)
              .WithMany()
              .HasForeignKey(s => s.id_autor);

            modelBuilder.Entity<Prestamo>()
                .HasOne<Lector>(p => p.lector)
                .WithMany(l => l.prestamos)
                .HasForeignKey(p => p.id_lector);

            modelBuilder.Entity<Prestamo>()
                .HasOne<Libro>(p => p.libro)
                .WithMany()
                .HasForeignKey(p => p.id_libro);


        }

    }
}
