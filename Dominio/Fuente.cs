using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Fuente
    {
        /// <summary>
        /// Agrega la Fuente a la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a agregar</param>
        public static void Agregar(IFuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            pFuente.Codigo = fachada.CrearFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a modificar</param>
        public static void Modificar(IFuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.ActualizarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Elimina la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Campaña a eliminar</param>
        public static void Eliminar(IFuente pFuente)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            fachada.EliminarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Obtiene todos las Fuentes que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Fuente</param>
        /// <returns>Tipo de dato Lista que representa las Fuentes filtradas</returns>
        public static List<IFuente> ObtenerFuentes(IFuente argumentoFiltro = null)
        {
            Persistencia.Fachada fachada = IoCContainerLocator.GetType<Persistencia.Fachada>();
            return (AutoMapper.Map<List<Persistencia.Fuente>, List<IFuente>>
                            (fachada.ObtenerFuentes(AutoMapper.Map<IFuente, Persistencia.Fuente>(argumentoFiltro))));
        }

        /// <summary>
        /// Actualiza las fuentes RSS
        /// </summary>
        internal static void Actualizar()
        {
            Persistencia.Fachada fachadaPersistencia = IoCContainerLocator.GetType<Persistencia.Fachada>();
            foreach (IFuente pFuente in Banner.ActualizarFuentes())
            {
                fachadaPersistencia.ActualizarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
            }
        }
    }
}
