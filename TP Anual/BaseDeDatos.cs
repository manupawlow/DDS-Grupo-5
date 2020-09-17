using System;
using System.Collections.Generic;
using System.Text;
using TP_Anual.Egresos;
using MySql.Data.Entity;
using System.Data.Entity;
using TP_Anual.Organizaciones;

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
        public DbSet<CriterioPorItem> criterios_por_item { get; set; }
        public DbSet<DocumentoComercial> documentos { get; set; }
        public DbSet<EntidadBase> entidades_base  { get; set; }
        public DbSet<EntidadJuridica> entidades_juridicas { get; set; }

        public BaseDeDatos() : base("dbConn")
        {

            // Deshabilita la inicializacion mágica del ORM
            Database.SetInitializer<BaseDeDatos>(null);

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            /*modelBuilder.Entity<Presupuesto>()
                .HasMany<Item>(i => i.itemsDePresupuesto)
                .WithMany(i => i.presupuesto)
                .Map(ip =>
                {
                    ip.ToTable("item_por_presupuesto");
                    ip.MapLeftKey("id_presupuesto");
                    ip.MapRightKey("id_item");
                });
                */



            modelBuilder.Entity<Egreso>()
                 .HasRequired<Ingreso>(e => e.ingreso)
                 .WithMany(i => i.egresos)
                 .HasForeignKey(e => e.id_ingreso);

            modelBuilder.Entity<Egreso>()
                 .HasRequired<Proveedor>(e => e.proveedorElegido)
                 .WithMany()
                 .HasForeignKey(e => e.id_prov);

            modelBuilder.Entity<Presupuesto>()
                 .HasRequired<Egreso>(p => p.egreso)
                 .WithMany(e => e.presupuestos)
                 .HasForeignKey(p => p.id_egreso);

            modelBuilder.Entity<Presupuesto>()
                 .HasRequired<Proveedor>(pres => pres.proveedor)
                 .WithMany()
                 .HasForeignKey(pres => pres.id_prov);


            modelBuilder.Entity<DocumentoComercial>()
                .HasRequired<Presupuesto>(d => d.presupuesto)
                .WithRequiredPrincipal(p => p.documentoComercial);

            modelBuilder.Entity<DocumentoComercial>()
                .HasRequired<Egreso>(d => d.egreso)
                .WithMany(e => e.documentosComerciales)
                .HasForeignKey(d => d.id_egreso);


            #region ITEMS

            modelBuilder.Entity<ItemPorEgreso>()
                .HasRequired<Item>(ie => ie.item)
                .WithMany()
                .HasForeignKey(ie => ie.id_item);

            modelBuilder.Entity<ItemPorEgreso>()
                .HasRequired<Egreso>(ie => ie.egreso)
                .WithMany(e => e.items)
                .HasForeignKey(ie => ie.id_egreso);


            modelBuilder.Entity<ItemPorPresupuesto>()
                .HasRequired<Item>(ip => ip.item)
                .WithMany()
                .HasForeignKey(ip => ip.id_item);

            modelBuilder.Entity<ItemPorPresupuesto>()
                .HasRequired<Presupuesto>(ip => ip.presupuesto)
                .WithMany(p => p.itemsDePresupuesto)
                .HasForeignKey(ip => ip.id_presupuesto);


            #endregion

            #region CRITERIOS Y CATEGORIAS

            modelBuilder.Entity<Categoria>()
                .HasRequired<Criterio>(cat => cat.criterio)
                .WithMany(crit => crit.categorias)
                .HasForeignKey(cat => cat.id_criterio);

            modelBuilder.Entity<CriterioPorItem>()
                .HasRequired<Criterio>(ci => ci.criterio)
                .WithMany()
                .HasForeignKey(ci => ci.id_criterio);

            modelBuilder.Entity<CriterioPorItem>()
                .HasRequired<Item>(ci => ci.item)
                .WithMany(i => i.criteriosDeItem)
                .HasForeignKey(ci => ci.id_item);

            modelBuilder.Entity<CriterioPorItem>()
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


            /*modelBuilder.Entity<TipoOrganizacion>()
                .Map<OSC>(m => m.Requires("discriminador").HasValue("OSC"))
                .Map<MedianaTramo2>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 2"))
                .Map<MedianaTramo1>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 1"))
                .Map<Pequenia>(m => m.Requires("discriminador").HasValue("Pequenia"))
                .Map<Micro>(m => m.Requires("discriminador").HasValue("Micro"));
                */

            modelBuilder.Entity<OSC>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<OSC>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");


            modelBuilder.Entity<Empresa>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<Empresa>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<Empresa>()
                .Map<MedianaTramo2>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 2"))
                .Map<MedianaTramo1>(m => m.Requires("discriminador").HasValue("Mediana Tramo - 1"))
                .Map<Pequenia>(m => m.Requires("discriminador").HasValue("Pequenia"))
                .Map<Micro>(m => m.Requires("discriminador").HasValue("Micro"));


            modelBuilder.Entity<OSC>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<MedianaTramo2>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<MedianaTramo2>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<MedianaTramo1>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<MedianaTramo1>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<Pequenia>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<Pequenia>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");

            modelBuilder.Entity<Micro>()
                .Property(o => o.categoria)
                .HasColumnName("categoria");

            modelBuilder.Entity<Micro>()
                .Property(o => o.tipo)
                .HasColumnName("tipo");
            



            /* ESTO NO LO USAMOS MAS
            modelBuilder.Entity<EntidadJuridica>()
                .Map(m =>
                {
                m.MapInheritedProperties();
                m.ToTable("entidad_juridica");
                });

            modelBuilder.Entity<EntidadJuridica>()
                .Property(j => j.id_organizacion)
                .HasColumnName("id_juridica");

            modelBuilder.Entity<EntidadJuridica>()
            .HasKey(j => j.id_organizacion); 
              
            
            modelBuilder.Entity<EntidadBase>()
            .Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("entidad_base");
            });

            modelBuilder.Entity<EntidadBase>()
                .Property(j => j.id_organizacion)
                .HasColumnName("id_base");

            modelBuilder.Entity<EntidadBase>()
            .HasKey(j => j.id_organizacion);
            */

            
            #endregion



        }

    }
}