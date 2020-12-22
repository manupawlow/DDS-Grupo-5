using System;
using System.Collections.Generic;
using System.Text;
using TP_Anual.Egresos;
using MySql.Data.EntityFramework;
using System.Data.Entity;
using TP_Anual.Organizaciones;
using TP_Anual.Administrador_Inicio_Sesion;

namespace TP_Anual
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySql : DbContext
    {
        public DbSet<Egreso> egresos { get; set; }
        public DbSet<Ingreso> ingresos { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<CriterioCategoriaPorItem> item_categoria_criterio {get; set;}
        public DbSet<Presupuesto> presupuestos { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Criterio> criterios { get; set; }
        public DbSet<DocumentoComercial> documentos { get; set; }
        public DbSet<EntidadBase> entidades_base { get; set; }
        public DbSet<EntidadJuridica> entidades_juridicas { get; set; }
        public DbSet<TipoOrganizacion> tipos_organizacion { get; set; }
        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<ProyectoDeFinanciamiento> proyectos { get; set; }


        public MySql() : base("dbConn")
        {

            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<MySql>(null);

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Egreso>()
                 .HasRequired<Ingreso>(e => e.ingreso)
                 .WithMany(i => i.egresos)
                 .HasForeignKey(e => e.id_ingreso);

            modelBuilder.Entity<Egreso>()
                 .HasRequired<Proveedor>(e => e.proveedorElegido)
                 .WithMany()
                 .HasForeignKey(e => e.id_prov);

            modelBuilder.Entity<Egreso>()
                .HasRequired<DocumentoComercial>(e => e.documentoComercial)
                .WithMany()
                .HasForeignKey(e => e.id_documento_comercial);

            modelBuilder.Entity<Egreso>()
                .HasRequired<ProyectoDeFinanciamiento>(e => e.proyecto)
                .WithMany()
                .HasForeignKey(e => e.id_proyecto);

            modelBuilder.Entity<Egreso>()
                .HasRequired<Presupuesto>(e => e.presupuestoElegido)
                .WithMany()
                .HasForeignKey(p => p.id_presupuesto_elegido);

            modelBuilder.Entity<Presupuesto>()
                 .HasRequired<Egreso>(p => p.egreso)
                 .WithMany(e => e.presupuestos)
                 .HasForeignKey(p => p.id_egreso);

            modelBuilder.Entity<Presupuesto>()
                 .HasRequired<Proveedor>(pres => pres.proveedor)
                 .WithMany()
                 .HasForeignKey(pres => pres.id_prov);

            modelBuilder.Entity<Presupuesto>()
                .HasRequired<DocumentoComercial>(p => p.documentoComercial)
                .WithMany()
                .HasForeignKey(p => p.id_documento_comercial);

            modelBuilder.Entity<Ingreso>()
                .HasRequired<ProyectoDeFinanciamiento>(i => i.proyecto)
                .WithMany()
                .HasForeignKey(i => i.id_proyecto);

            modelBuilder.Entity<ProyectoDeFinanciamiento>()
                .HasRequired<Usuario>(p => p.director)
                .WithMany()
                .HasForeignKey(p => p.id_director);

            
            #region ITEMS
            
            modelBuilder.Entity<Item>()
                .HasRequired<Egreso>(i => i.egreso)
                .WithMany(e => e.items)
                .HasForeignKey(i => i.id_egreso);

            modelBuilder.Entity<Item>()
                .HasRequired<Proveedor>(i => i.prov)
                .WithMany()
                .HasForeignKey(i => i.id_proveedor);


            modelBuilder.Entity<Item>()
                .HasRequired<Presupuesto>(i => i.presupuesto)
                .WithMany(p => p.itemsDePresupuesto)
                .HasForeignKey(i => i.id_presupuesto);

            #endregion
            
            
            #region CRITERIOS Y CATEGORIAS

            modelBuilder.Entity<Categoria>()
                .HasRequired<Criterio>(cat => cat.criterio)
                .WithMany()
                .HasForeignKey(cat => cat.id_criterio);
            
            modelBuilder.Entity<CriterioCategoriaPorItem>()
                .HasRequired<Criterio>(ci => ci.criterio_item)
                .WithMany()
                .HasForeignKey(ci => ci.id_criterio_item);

            modelBuilder.Entity<CriterioCategoriaPorItem>()
                .HasRequired<Item>(ci => ci.item)
                .WithMany()
                .HasForeignKey(ci => ci.id_item);

            modelBuilder.Entity<CriterioCategoriaPorItem>()
                .HasRequired<Categoria>(ci => ci.categoria_item)
                .WithMany()
                .HasForeignKey(ci => ci.id_categoria_item);

            #endregion
            

            #region ORGANIZACIONES

            modelBuilder.Entity<EntidadJuridica>()
                .Property(j => j.actividad)
                .HasColumnName("actividad");

            modelBuilder.Entity<EntidadJuridica>()
                .Property(j => j.cantidadPersonal)
                .HasColumnName("cant_personal");

            modelBuilder.Entity<EntidadJuridica>()
                .Property(j => j.nombreFicticio)
                .HasColumnName("nombre_ficticio");

            modelBuilder.Entity<EntidadJuridica>()
                .Property(j => j.promedioVentasAnuales)
                .HasColumnName("promedio_ventas_anuales");


            modelBuilder.Entity<EntidadBase>()
                .Property(b => b.actividad)
                .HasColumnName("actividad");

            modelBuilder.Entity<EntidadBase>()
                .Property(b => b.cantidadPersonal)
                .HasColumnName("cant_personal");

            modelBuilder.Entity<EntidadBase>()
                .Property(b => b.nombreFicticio)
                .HasColumnName("nombre_ficticio");

            modelBuilder.Entity<EntidadBase>()
                .Property(b => b.promedioVentasAnuales)
                .HasColumnName("promedio_ventas_anuales");


            modelBuilder.Entity<EntidadBase>()
                .HasRequired<EntidadJuridica>(b => b.entidad_juridica)
                .WithMany(j => j.entidades_base)
                .HasForeignKey(b => b.id_juridica);


            modelBuilder.Entity<TipoOrganizacion>()
                .Map<MedianaTramo2>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 2"))
                .Map<MedianaTramo1>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 1"))
                .Map<Pequenia>(m => m.Requires("discriminador").HasValue("Pequenia"))
                .Map<Micro>(m => m.Requires("discriminador").HasValue("Micro"))
                .Map<OSC>(m => m.Requires("discriminador").HasValue("OSC"));


            modelBuilder.Entity<EntidadJuridica>()
                .HasRequired<TipoOrganizacion>(eb => eb.tipoOrganizacion)
                .WithMany()
                .HasForeignKey(eb => eb.id_tipo_organizacion);

            modelBuilder.Entity<EntidadBase>()
                .HasRequired<TipoOrganizacion>(eb => eb.tipoOrganizacion)
                .WithMany()
                .HasForeignKey(eb => eb.id_tipo_organizacion);

            #endregion



        }

    }
}