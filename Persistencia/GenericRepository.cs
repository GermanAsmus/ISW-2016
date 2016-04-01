using System.Linq;
using System.Data.Entity;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;

namespace Persistencia
{
    class GenericRepository<TEntity> where TEntity : class
    {
        public IQueryable<TEntity> Queryable;
        private CarteleriaContext context;
        private DbSet<TEntity> dbSet;

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
            TEntity entity = (TEntity)this.dbSet.Find(id);
            if(entity != null)
            {
                //Todas las propiedades virtualess carga su valor
                foreach (PropertyInfo propiedad in typeof(TEntity).GetProperties())
                {
                    if (typeof(ICollection).IsAssignableFrom(propiedad.PropertyType))
                    {
                        this.context.Entry(entity).Collection(propiedad.Name).Load();
                    }
                    else if (propiedad.GetValue(entity) == null)
                    {
                        this.context.Entry(entity).Reference(propiedad.Name).Load();
                    }
                }
            }
            return entity;
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
        /// Elimina una entidad del repositorio, que tiene objetos relacionados (relación otras tablas con fk)
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        public virtual void DeleteWithRelated(TEntity entity)
        {
            this.Attach(entity);
            this.dbSet.Remove(entity);
        }

        /// <summary>
        /// Elimina una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad a eliminar</param>
        public virtual void Delete(TEntity entity)
        {
            this.Attach(entity);
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        /// <summary>
        /// Actualiza una entidad del repositorio
        /// </summary>
        /// <param name="entity">Entidad a actualizar</param>
        public virtual void Update(TEntity entity)
        {
            this.Attach(entity);
            this.context.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Cambia los valores de la entidad original por los de la nueva entidad
        /// </summary>
        /// <param name="originaEntity">Entidad Original almacenada</param>
        /// <param name="newEntity">Entidad con los valores actuales</param>
        public virtual void ChangeValues(TEntity originaEntity, TEntity newEntity)
        {
            if ((this.context.Entry(originaEntity).State) == (EntityState.Detached))
            {
                this.dbSet.Attach(originaEntity);
            }
            this.context.Entry(originaEntity).CurrentValues.SetValues(newEntity);
        }

        /// <summary>
        /// Devuelve todos las entidades del Repositorio
        /// </summary>
        /// <returns>Tipo de dato Lista que representa todos las entidades del repositorio</returns>
        public virtual List<TEntity> GetAll()
        {
            return this.dbSet.ToList<TEntity>();
        }

        /// <summary>
        /// Hace un Attach al context con la entidad
        /// </summary>
        /// <param name="entity">Entidad a adjuntar</param>
        private void Attach(TEntity entity)
        {
            if ((this.context.Entry(entity).State) == (EntityState.Detached))
            {
                this.dbSet.Attach(entity);
            }
        }
    }
}
