using System.Linq;
using System.Data.Entity;

namespace Persistencia
{
    class GenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Queryable;
        internal CarteleriaContext context;
        internal DbSet dbSet;

        /// <summary>
        /// Construye una instancia de GenericRepsitory
        /// </summary>
        public GenericRepository(CarteleriaContext context)
        {
            this.context = context;
            this.dbSet = this.context.Set<TEntity>();
            Queryable = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Obtiene una entidad
        /// </summary>
        /// <param name="id">ID de la entidad que se desea obtener</param>
        /// <returns></returns>
        public virtual TEntity GetByCodigo(object id)
        {
            return (TEntity)this.dbSet.Find(id);
        }

        /// <summary>
        /// Inserta una entidad al repositorio.
        /// </summary>
        /// <param name="entity">entidad a insertar</param>
        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        /// <summary>
        /// Elimina una entidad del repositorio
        /// </summary>
        /// <param name="id">Id de la entidad que se desea eliminar</param>
        public virtual void Delete(object id)
        {
            this.Delete(this.GetByCodigo(id));
        }

        /// <summary>
        /// Elimina una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        public virtual void Delete(TEntity entity)
        {
            if ((this.context.Entry(entity).State) == (EntityState.Detached))
            {
                this.dbSet.Attach(entity);
            }
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Actualiza una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        public virtual void Update(TEntity entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }
    }
}
