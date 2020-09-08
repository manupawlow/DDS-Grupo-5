using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TP_Anual.Egresos;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace TP_Anual
{
    class BaseDeDatos : DbContext
    {
        public DbSet<Egreso> egresos { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Presupuesto> presupuestos { get; set; }
        public DbSet<Proveedor> proveedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseMySQL("server=localhost;database=biblioteca;user=root;password=;"); 
            optionsBuilder.UseMySQL("server=database-1.cow3ly6mxmir.sa-east-1.rds.amazonaws.com;database=DDS_TP_ANUAL;user=admin;password=pepepepe;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definimos que use el schema public
            //modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            // Fluent API
            

        }

    }
}