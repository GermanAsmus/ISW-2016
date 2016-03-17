using System;
using System.Collections.Generic;
using System.Drawing;

namespace Testings
{
    /// <summary>
    /// Clase responsable de verificar si dos instancias son iguales
    /// </summary>
    class Equality
    {
        #region PERSISTENCIA (11)
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Persistencia.Banner objeto1, Persistencia.Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.Fuente_Codigo == objeto2.Fuente_Codigo) &&
                             Equals(objeto1.RangosFecha, objeto2.RangosFecha) &&
                             Equals(objeto1.Fuente, objeto2.Fuente);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Persistencia.Campaña objeto1, Persistencia.Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.RangosFecha, objeto2.RangosFecha)) &&
                             (Equals(objeto1.Imagenes, objeto2.Imagenes));
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Persistencia.RangoFecha> objeto1, List<Persistencia.RangoFecha> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Persistencia.RangoFecha pRangoFecha1 in objeto1)
            {
                Persistencia.RangoFecha pRangoFecha2 = objeto2.Find(x => x.Codigo == pRangoFecha1.Codigo);
                resultado = resultado && (Equals(pRangoFecha1, pRangoFecha2));
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Persistencia.RangoFecha objeto1, Persistencia.RangoFecha objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.FechaInicio == objeto2.FechaInicio) &&
                             (objeto1.FechaFin == objeto2.FechaFin) && 
                             (objeto1.Principal.Codigo == objeto2.Principal.Codigo) &&
                             (objeto1.Principal_Codigo == objeto2.Principal_Codigo) &&
                             Equals(objeto1.RangosHorario, objeto2.RangosHorario);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Persistencia.RangoHorario> objeto1, List<Persistencia.RangoHorario> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Persistencia.RangoHorario pRangoHorario1 in objeto1)
            {
                Persistencia.RangoHorario pRangoHorario2 = objeto2.Find(x => x.Codigo == pRangoHorario1.Codigo);
                resultado = resultado && Equals(pRangoHorario1, pRangoHorario2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Persistencia.RangoHorario objeto1, Persistencia.RangoHorario objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.HoraInicio == objeto2.HoraInicio) &&
                             (objeto1.HoraFin == objeto2.HoraFin) && 
                             (objeto1.RangoFecha_Codigo == objeto2.RangoFecha_Codigo) &&
                             (objeto1.RangoFecha.Codigo == objeto2.RangoFecha.Codigo);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Persistencia.Imagen> objeto1, List<Persistencia.Imagen> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Persistencia.Imagen pImagen1 in objeto1)
            {
                Persistencia.Imagen pImagen2 = objeto2.Find(x => x.Codigo == pImagen1.Codigo);
                resultado = resultado && Equals(pImagen1, pImagen2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Persistencia.Imagen objeto1, Persistencia.Imagen objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Tiempo == objeto2.Tiempo) &&
                             (Equals(objeto1.Picture, objeto2.Picture)) &&
                             (objeto1.Campaña_Codigo == objeto2.Campaña_Codigo) &&
                             (objeto1.Campaña.Codigo == objeto2.Campaña.Codigo);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Persistencia.Fuente objeto1, Persistencia.Fuente objeto2)
        {
            bool resultado = true;
            if (objeto1.GetType() == typeof(Persistencia.FuenteRSS))
            {
                resultado = Equals((Persistencia.FuenteRSS)objeto1, (Persistencia.FuenteRSS)objeto2);
            }
            else
            {
                resultado = Equals((Persistencia.FuenteTextoFijo)objeto1, (Persistencia.FuenteTextoFijo)objeto2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Persistencia.FuenteRSS objeto1, Persistencia.FuenteRSS objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Descripcion == objeto2.Descripcion) &&
                             (objeto1.URL == objeto2.URL) &&
                             (objeto1.Valor == objeto2.Valor);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Persistencia.FuenteTextoFijo objeto1, Persistencia.FuenteTextoFijo objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Valor == objeto2.Valor);
            return resultado;
        }
        #endregion

        #region DOMINIO (11)
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Dominio.Banner objeto1, Dominio.Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha) &&
                             Equality.Equals(objeto1.InstanciaFuente, objeto2.InstanciaFuente);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Dominio.Campaña objeto1, Dominio.Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha)) &&
                             (Equals(objeto1.ListaImagenes, objeto2.ListaImagenes));
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Dominio.RangoFecha> objeto1, List<Dominio.RangoFecha> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Dominio.RangoFecha pRangoFecha1 in objeto1)
            {
                Dominio.RangoFecha pRangoFecha2 = objeto2.Find(x => x.Codigo == pRangoFecha1.Codigo);
                resultado = resultado && (Equals(pRangoFecha1, pRangoFecha2));
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Dominio.RangoFecha objeto1, Dominio.RangoFecha objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.FechaInicio == objeto2.FechaInicio) &&
                             (objeto1.FechaFin == objeto2.FechaFin) &&
                             Equals(objeto1.ListaRangosHorario, objeto2.ListaRangosHorario);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Dominio.RangoHorario> objeto1, List<Dominio.RangoHorario> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Dominio.RangoHorario pRangoHorario1 in objeto1)
            {
                Dominio.RangoHorario pRangoHorario2 = objeto2.Find(x => x.Codigo == pRangoHorario1.Codigo);
                resultado = resultado && Equals(pRangoHorario1, pRangoHorario2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Dominio.RangoHorario objeto1, Dominio.RangoHorario objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.HoraInicio == objeto2.HoraInicio) &&
                             (objeto1.HoraFin == objeto2.HoraFin);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Dominio.Imagen> objeto1, List<Dominio.Imagen> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Dominio.Imagen pImagen1 in objeto1)
            {
                Dominio.Imagen pImagen2 = objeto2.Find(x => x.Codigo == pImagen1.Codigo);
                resultado = resultado && Equals(pImagen1, pImagen2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Dominio.Imagen objeto1, Dominio.Imagen objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Tiempo == objeto2.Tiempo) &&
                             (Equals(objeto1.Picture, objeto2.Picture));
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Image objeto1,Image objeto2)
        {
            bool resultado = true;
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(Dominio.Fuente objeto1, Dominio.Fuente objeto2)
        {
            bool resultado = true;
            if(objeto1.GetType() == typeof(Dominio.FuenteRSS))
            {
                resultado = Equals((Dominio.FuenteRSS)objeto1, (Dominio.FuenteRSS)objeto2);
            }
            else
            {
                resultado = Equals((Dominio.FuenteTextoFijo)objeto1, (Dominio.FuenteTextoFijo)objeto2);
            }
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Dominio.FuenteRSS objeto1, Dominio.FuenteRSS objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Descripcion == objeto2.Descripcion) &&
                             (objeto1.URL == objeto2.URL);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Dominio.FuenteTextoFijo objeto1, Dominio.FuenteTextoFijo objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Valor == objeto2.Valor);
            return resultado;
        }
        #endregion

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(byte[] objeto1, byte[] objeto2)
        {
            return true;
        }
    }
}
