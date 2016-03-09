using System;

namespace Servicios.Excepciones
{
    /// <summary>
    /// Clase responsable de las excepciones de la Web
    /// </summary>
    public class ExcepcionWeb : Exception
    {
        /// <summary>
        /// URL correspondiente a la excepción
        /// </summary>
        string iWebURL;

        /// <summary>
        /// Crea una Excepción de URL, enmascarando otra excepción
        /// </summary>
        /// <param name="pWebURL">URL relacionado</param>
        /// <param name="pMensaje">Mensaje de la excepción</param>
        /// <param name="e">Excepción enmascarada</param>
        public ExcepcionWeb(string pWebURL, string pMensaje, Exception e) : base(pMensaje, e)
        {
            this.iWebURL = pWebURL;
        }

        /// <summary>
        /// Crea una Excepción de URL, enmascarando otra excepción
        /// </summary>
        /// <param name="pWebURL">URL relacionado</param>
        /// <param name="pMensaje">Mensaje de la excepción</param>
        public ExcepcionWeb(string pWebURL, string pMensaje) : base(pMensaje)
        {
            this.iWebURL = pWebURL;
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
