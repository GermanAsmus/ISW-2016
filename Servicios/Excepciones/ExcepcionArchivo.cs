using System;

namespace Servicios.Excepciones
{
    /// <summary>
    /// Clase responsable de las excepciones de manejo de Archivos
    /// </summary>
    public class ExcepcionArchivo : Exception
    {
        /// <summary>
        /// Ruta del archivo correspondiente a la excepción
        /// </summary>
        string iRuta;

        /// <summary>
        /// Crea una Excepción de Archivo, enmascarando otra excepción
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>
        /// <param name="pMensaje">Mensaje de la excepción</param>
        /// <param name="e">Excepción enmascarada</param>
        public ExcepcionArchivo(string ruta, string pMensaje, Exception e) : base(pMensaje,e)
        {
            this.iRuta = ruta;
        }

        /// <summary>
        /// Crea una Excepción de Archivo, enmascarando otra excepción
        /// </summary>
        /// <param name="ruta">Ruta del archivo</param>
        /// <param name="pMensaje">Mensaje de la excepción</param>
        public ExcepcionArchivo(string ruta, string pMensaje) : base(pMensaje)
        {
            this.iRuta = ruta;
        }

        /// <summary>
        /// Representación interna de la excepción en formato de cadena
        /// </summary>
        /// <returns>Tipo de dato string que representa el estado interno de la excepción</returns>
        public override string ToString()
        {
            return (this.Message);
        }
    }
}
