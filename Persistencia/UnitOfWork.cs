using System;

namespace Persistencia
{
    class UnitOfWork : IDisposable
    {
        private bool disposed = false;

        private CarteleriaContext context;
        private GenericRepository<Banner> iBannerRepository;
        private GenericRepository<Campaña> iCampañaRepository;
        private GenericRepository<Imagen> iImagenRepository;
        private GenericRepository<RangoFecha> iRangoFechaRepository;
        private GenericRepository<RangoHorario> iRangoHorarioRepository;

        /// <summary>
        /// Construye una instancia de UnitOfWork
        /// </summary>
        public UnitOfWork()
        {
            context = new CarteleriaContext();
            this.iBannerRepository = new GenericRepository<Banner>(context);
            this.iCampañaRepository = new GenericRepository<Campaña>(context);
            this.iImagenRepository = new GenericRepository<Imagen>(context);
            this.iRangoFechaRepository = new GenericRepository<RangoFecha>(context);
            this.iRangoHorarioRepository = new GenericRepository<RangoHorario>(context);
        }

        /// <summary>
        /// Guarda en la base de datos las transacciones que están en memoria.
        /// </summary>
        public virtual void Save()
        {
            if (this.context != null)
            {
                this.context.SaveChanges();
            }
        }

        /// <summary>
        /// Determina si el UnitOfWork ha sido disposed o no
        /// </summary>
        public bool Disposed
        {
            get { return this.disposed; }
        }

        /// <summary>
        /// Libera los recursos
        /// </summary>
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Libera los recursos
        /// </summary>
        /// <param name="disposing">Dato booleano que determina se ha sido disposed o no</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Devuelve el repositorio de Banners
        /// </summary>
        public virtual GenericRepository<Banner> BannerRepository
        {
            get { return this.iBannerRepository; }
        }

        /// <summary>
        /// Devuelve el repositorio de Campañas
        /// </summary>
        public virtual GenericRepository<Campaña> CampañaRepository
        {
            get { return this.iCampañaRepository; }
        }

        /// <summary>
        /// Devuelve el repositorio de Imágenes
        /// </summary>
        public virtual GenericRepository<Imagen> ImagenRepository
        {
            get { return this.iImagenRepository; }
        }

        /// <summary>
        /// Devuelve el repositorio de Rangos de Fecha
        /// </summary>
        public virtual GenericRepository<RangoFecha> RangoFechaRepository
        {
            get { return this.iRangoFechaRepository; }
        }

        /// <summary>
        /// Devuelve el repositorio de Rangos de Horario
        /// </summary>
        public virtual GenericRepository<RangoHorario> RangoHorarioRepository
        {
            get { return this.iRangoHorarioRepository; }
        }
    }
}
