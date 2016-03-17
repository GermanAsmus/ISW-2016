using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia
{
    partial class CarteleriaContext : DbContext
    {
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Campaña> Campañas { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<RangoFecha> RangosFecha { get; set; }
        public DbSet<RangoHorario> RangosHorario { get; set; }
        public DbSet<Fuente> Fuente { get; set; }

        /// <summary>
        /// Constructor del Context de la Carteleria
        /// </summary>
        public CarteleriaContext()
        {
            // Es un hack que asegura que el Entity Framework SQL Provider es copiado a la carpeta de salida.
            // Es necesario para probarlo.
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            Database.SetInitializer<CarteleriaContext>(new DropCreateDatabaseIfModelChanges<CarteleriaContext>());
        }

        /// <summary>
        /// Método que crea mapea los objetos FuenteRSS y FuenteTextFijo en sus respectivas tablas
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //FUENTE
            modelBuilder.Entity<Fuente>()
                .ToTable("Fuente")
                .HasKey(fuente => fuente.Codigo);
            modelBuilder.Entity<FuenteRSS>().ToTable("FuenteRSS");
            modelBuilder.Entity<FuenteTextoFijo>().ToTable("FuenteTextoFijo");
            modelBuilder.Entity<RangoFecheable>()
                .ToTable("RangoFecheable")
                .HasKey(rangoF => rangoF.Codigo);
            modelBuilder.Entity<Banner>().ToTable("Banner");
            modelBuilder.Entity<Campaña>().ToTable("Campaña");
            //Imagenes
            modelBuilder.Entity<Imagen>()
                .HasKey<int>(i => i.Codigo)
                .HasRequired<Campaña>(i => i.Campaña)
                .WithMany(c => c.Imagenes)
                .HasForeignKey(i => i.Campaña_Codigo)
                .WillCascadeOnDelete(true);
            //Banners
            modelBuilder.Entity<Banner>()
                .HasRequired<Fuente>(b => b.Fuente)
                .WithMany()
                .HasForeignKey(b => b.Fuente_Codigo)
                .WillCascadeOnDelete(true);
            //Rangos Horario
            modelBuilder.Entity<RangoHorario>()
                .HasRequired<RangoFecha>(rh => rh.RangoFecha)
                .WithMany(rf => rf.RangosHorario)
                .HasForeignKey(rh => rh.RangoFecha_Codigo)
                .WillCascadeOnDelete(true);
            //Rangos Fecha
            modelBuilder.Entity<RangoFecha>()
                .HasRequired<RangoFecheable>(rf => rf.Principal)
                .WithMany(principal => principal.RangosFecha)
                .HasForeignKey(rf => rf.Principal_Codigo)
                .WillCascadeOnDelete(true);
        }
    }
}