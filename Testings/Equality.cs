using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Testings
{
    /// <summary>
    /// Clase responsable de verificar si dos instancias son iguales
    /// </summary>
    class Equality
    {
        #region PERSISTENCIA (9)
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Persistencia.Banner objeto1, Persistencia.Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.Texto == objeto2.Texto) && (objeto1.URL == objeto2.URL) &&
                             Equals(objeto1.RangosFecha, objeto2.RangosFecha);
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
                             (objeto1.FechaFin == objeto1.FechaFin) &&
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
                             (objeto1.HoraFin == objeto2.HoraFin);
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
                             (Equals(objeto1.Picture, objeto2.Picture));
            return resultado;
        }

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
        #endregion

        #region UI (9)
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Banner objeto1, Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha);
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
        private static bool Equals(List<RangoFecha> objeto1, List<RangoFecha> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (RangoFecha pRangoFecha1 in objeto1)
            {
                RangoFecha pRangoFecha2 = objeto2.Find(x => x.Codigo == pRangoFecha1.Codigo);
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
        private static bool Equals(RangoFecha objeto1, RangoFecha objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.FechaInicio == objeto2.FechaInicio) &&
                             (objeto1.FechaFin == objeto1.FechaFin) &&
                             Equals(objeto1.ListaRangosHorario, objeto2.ListaRangosHorario);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<RangoHorario> objeto1, List<RangoHorario> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (RangoHorario pRangoHorario1 in objeto1)
            {
                RangoHorario pRangoHorario2 = objeto2.Find(x => x.Codigo == pRangoHorario1.Codigo);
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
        private static bool Equals(RangoHorario objeto1, RangoHorario objeto2)
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
        private static bool Equals(Imagen objeto1, Imagen objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Tiempo == objeto2.Tiempo);
                            /*&& (objeto1.Picture == objeto2.Picture);*/
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Imagen> objeto1, List<Imagen> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Imagen pImagen1 in objeto1)
            {
                Imagen pImagen2 = objeto2.Find(x => x.Codigo == pImagen1.Codigo);
                resultado = resultado && Equals(pImagen1, pImagen2);
            }
            return resultado;
        }
        #endregion


        #region ModeloAOtroTipo(Imagenes)
        /// <summary>
        /// Verifica si dos instancias son iguales (mapeo desde modelo)
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool EqualsDesdeModelo(Persistencia.Campaña objeto1, Persistencia.Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.RangosFecha, objeto2.RangosFecha));
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales (mapeo desde modelo)
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool EqualsDesdeModelo(Campaña objeto1, Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha));
            return resultado;
        }
        #endregion
    }
}
