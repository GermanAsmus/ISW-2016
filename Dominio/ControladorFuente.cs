using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class ControladorFuente
    {
        /// <summary>
        /// Agrega la Fuente a la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a agregar</param>
        internal static void Agregar(IFuente pFuente)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            pFuente.Codigo = fachada.CrearFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
            GC.Collect();
        }

        /// <summary>
        /// Modifica la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Fuente a modificar</param>
        internal static void Modificar(IFuente pFuente)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.ActualizarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Elimina la Fuente en la base de datos
        /// </summary>
        /// <param name="pFuente">Campaña a eliminar</param>
        internal static void Eliminar(IFuente pFuente)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            fachada.EliminarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
        }

        /// <summary>
        /// Obtiene todos las Fuentes que cumplen con un determinado filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar Fuente</param>
        /// <returns>Tipo de dato Lista que representa las Fuentes filtradas</returns>
        internal static List<IFuente> ObtenerFuentes(IFuente argumentoFiltro = null)
        {
            Persistencia.FachadaPersistencia fachada = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            return (AutoMapper.Map<List<Persistencia.Fuente>, List<IFuente>>
                            (fachada.ObtenerFuentes(AutoMapper.Map<IFuente, Persistencia.Fuente>(argumentoFiltro))));
        }

        /// <summary>
        /// Obtiene la Fuente que se corresponde con el código
        /// </summary>
        /// <param name="pCodigoFuente">Codigo de Fuente de la imagen a buscar</param>
        /// <returns>Fuente cuyo código es el suminitrado</returns>
        internal static IFuente ObtenerFuentePorCodigo(int pCodigoFuente)
        {
            return AutoMapper.Map<Persistencia.Fuente, IFuente>
                        (IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>().ObtenerFuente(pCodigoFuente));
        }

        /// <summary>
        /// Actualiza las fuentes RSS
        /// </summary>
        internal static void Actualizar()
        {
            Persistencia.FachadaPersistencia fachadaPersistencia = IoCContainerLocator.GetType<Persistencia.FachadaPersistencia>();
            foreach (IFuente pFuente in ControladorBanner.ActualizarFuentes())
            {
                fachadaPersistencia.ActualizarFuente(AutoMapper.Map<IFuente, Persistencia.Fuente>(pFuente));
            }
        }
    }
}
