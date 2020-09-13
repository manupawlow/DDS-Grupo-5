using System;
using System.Collections.Generic;
using System.Text;
using TP_Anual.Egresos;
using MySql.Data.Entity;
using System.Data.Entity;

namespace TP_Anual
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class BaseDeDatos : DbContext
    {
        public DbSet<Egreso> egresos { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Presupuesto> presupuestos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Criterio> criterios { get; set; }
        public DbSet<DocumentoComercial> documentos { get; set; }

        public BaseDeDatos() : base("dbConn")
        {

            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<BaseDeDatos>(null);

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Presupuesto>()
                .HasMany<Item>(i => i.itemsDePresupuesto)
                .WithMany(i => i.presupuesto)
                .Map(ip =>
                {
                    ip.ToTable("item_por_presupuesto");
                    ip.MapLeftKey("id_presupuesto");
                    ip.MapRightKey("id_item");
                });

            modelBuilder.Entity<Egreso>()
                .HasRequired<Ingreso>(e => e.ingreso)
                .WithMany(i => i.egresos)
                .HasForeignKey(e => e.id_ingreso);

            modelBuilder.Entity<DocumentoComercial>()
                .HasRequired<Presupuesto>(d => d.presupuesto)
                .WithMany(p => p.documentosComerciales)
                .HasForeignKey(d => d.id_presupuesto);

        }

    }
}