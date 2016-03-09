using System;
using System.Data.Entity;

namespace Persistencia
{
    partial class CarteleriaContext : DbContext
    {
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

        public DbSet<Banner> Banners { get; set; }
        public DbSet<Campaña> Campañas { get; set; }
        public DbSet<Imagen> Imagenes { get; set; }
        public DbSet<RangoFecha> RangosFecha { get; set; }
        public DbSet<RangoHorario> RangosHorario { get; set; }
    }
}
