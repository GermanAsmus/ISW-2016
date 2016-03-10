using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    public static class ExtesionLista
    {
        /// <summary>
        /// Obtiene los elementos eliminados de la lista original
        /// </summary>
        /// <typeparam name="T">Clase que implementa IEquatable</typeparam>
        /// <param name="pListaOriginal">Lista Original</param>
        /// <param name="pListaModificada">Lista Modificada</param>
        /// <returns>Tipo de dato Lista que contiene los elementos eliminados de la lista original</returns>
        public static List<T> GetDeleted<T>(this List<T> pListaOriginal, List<T> pListaModificada) where T : IEquatable<T>
        {
            List<T> listaResultado = new List<T>();
            foreach (T pElemento in pListaOriginal)
            {
                if (pListaModificada.Contains(pElemento))
                {
                    listaResultado.Add(pElemento);
                }
            }
            return listaResultado;
        }

        /// <summary>
        /// Obtiene los elementos nuevos de la lista original
        /// </summary>
        /// <typeparam name="T">Clase que implementa IEquatable</typeparam>
        /// <param name="pListaOriginal">Lista Original</param>
        /// <param name="pListaModificada">Lista Modificada</param>
        /// <returns>Tipo de dato Lista que contiene los elementos nuevos de  la lista original</returns>
        public static List<T> GetNew<T>(this List<T> pListaOriginal, List<T> pListaModificada) where T : IEquatable<T>
        {
            List<T> listaResultado = new List<T>();
            foreach (T pElemento in pListaModificada)
            {
                if (!pListaOriginal.Contains(pElemento))
                {
                    listaResultado.Add(pElemento);
                }
            }
            return listaResultado;
        }

        /// <summary>
        /// Obtiene los elementos modificados de la lista original
        /// </summary>
        /// <typeparam name="T">Clase que implementa IEquatable</typeparam>
        /// <param name="pListaOriginal">Lista Original</param>
        /// <param name="pListaModificada">Lista Modificada</param>
        /// <returns>Tipo de dato Lista que contiene los elementos modificados de la lista original</returns>
        public static List<T> GetModified<T>(this List<T> pListaOriginal, List<T> pListaModificada) where T : IEquatable<T>
        {
            List<T> listaResultado = new List<T>();
            foreach (T pElemento in pListaModificada)
            {
                if (pListaOriginal.Contains(pElemento))
                {
                    listaResultado.Add(pElemento);
                }
            }
            return listaResultado;
        }
    }
}
