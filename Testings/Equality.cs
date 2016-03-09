using System.Collections.Generic;
using System.Linq;

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
        public static bool Equals(UI.Tipos.Banner objeto1, UI.Tipos.Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.Texto == objeto2.Texto) && (objeto1.URL == objeto2.URL) &&
                             Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(UI.Tipos.Campaña objeto1, UI.Tipos.Campaña objeto2)
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
        private static bool Equals(List<UI.Tipos.RangoFecha> objeto1, List<UI.Tipos.RangoFecha> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (UI.Tipos.RangoFecha pRangoFecha1 in objeto1)
            {
                UI.Tipos.RangoFecha pRangoFecha2 = objeto2.Find(x => x.Codigo == pRangoFecha1.Codigo);
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
        private static bool Equals(UI.Tipos.RangoFecha objeto1, UI.Tipos.RangoFecha objeto2)
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
        private static bool Equals(List<UI.Tipos.RangoHorario> objeto1, List<UI.Tipos.RangoHorario> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (UI.Tipos.RangoHorario pRangoHorario1 in objeto1)
            {
                UI.Tipos.RangoHorario pRangoHorario2 = objeto2.Find(x => x.Codigo == pRangoHorario1.Codigo);
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
        private static bool Equals(UI.Tipos.RangoHorario objeto1, UI.Tipos.RangoHorario objeto2)
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
        private static bool Equals(UI.Tipos.Imagen objeto1, UI.Tipos.Imagen objeto2)
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
        private static bool Equals(List<UI.Tipos.Imagen> objeto1, List<UI.Tipos.Imagen> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (UI.Tipos.Imagen pImagen1 in objeto1)
            {
                UI.Tipos.Imagen pImagen2 = objeto2.Find(x => x.Codigo == pImagen1.Codigo);
                resultado = resultado && Equals(pImagen1, pImagen2);
            }
            return resultado;
        }
        #endregion

        #region MODELO (10)
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Modelo.Banner objeto1, Modelo.Banner objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.Texto == objeto2.Texto) && (objeto1.InstanciaTexto == objeto2.InstanciaTexto) &&
                             Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha);
            return resultado;
        }

        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        public static bool Equals(Modelo.Campaña objeto1, Modelo.Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha));
            return resultado;
        }
        
        /// <summary>
        /// Verifica si dos instancias son iguales
        /// </summary>
        /// <param name="objeto1">Primer objeto a verificar</param>
        /// <param name="objeto2">Segundo objeto a verificar</param>
        /// <returns>Tipo de dato boolean que representa True si son iguale o False si son diferentes</returns>
        private static bool Equals(List<Modelo.RangoFecha> objeto1, List<Modelo.RangoFecha> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Modelo.RangoFecha pRangoFecha1 in objeto1)
            {
                Modelo.RangoFecha pRangoFecha2 = objeto2.Find(x => x.Codigo == pRangoFecha1.Codigo);
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
        private static bool Equals(Modelo.RangoFecha objeto1, Modelo.RangoFecha objeto2)
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
        private static bool Equals(List<Modelo.RangoHorario> objeto1, List<Modelo.RangoHorario> objeto2)
        {
            bool resultado = (objeto1.Count == objeto2.Count);
            foreach (Modelo.RangoHorario pRangoHorario1 in objeto1)
            {
                Modelo.RangoHorario pRangoHorario2 = objeto2.Find(x => x.Codigo == pRangoHorario1.Codigo);
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
        private static bool Equals(Modelo.RangoHorario objeto1, Modelo.RangoHorario objeto2)
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
        private static bool Equals(Modelo.ITexto objeto1, Modelo.ITexto objeto2)
        {
            bool resultado = objeto1.GetType() == objeto2.GetType();
            if (resultado)
            {
                if (objeto1.GetType() == typeof(Modelo.RSS))
                {
                    resultado = ((Modelo.RSS)objeto1).URL == ((Modelo.RSS)objeto2).URL;
                }
                else
                {
                    resultado = ((Modelo.TextoFijo)objeto1).Texto() == ((Modelo.TextoFijo)objeto2).Texto();
                }
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
        public static bool EqualsDesdeModelo(UI.Tipos.Campaña objeto1, UI.Tipos.Campaña objeto2)
        {
            bool resultado = (objeto1.Codigo == objeto2.Codigo) && (objeto1.Nombre == objeto2.Nombre) &&
                             (objeto1.IntervaloTiempo == objeto2.IntervaloTiempo) &&
                             (Equals(objeto1.ListaRangosFecha, objeto2.ListaRangosFecha));
            return resultado;
        }
        #endregion
    }
}
