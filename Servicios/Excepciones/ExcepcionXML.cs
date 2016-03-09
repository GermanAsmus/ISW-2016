using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Excepciones
{
    /// <summary>
    /// Clase responsable de las excepciones de manejo de XML
    /// </summary>
    public class ExcepcionXML : Exception
    {
        /// <summary>
        /// Crea una Excepción de XML, enmascarando otra excepción
        /// </summary>
        /// <param name="pMensaje">Mensaje de la excepción</param> 
        public ExcepcionXML(string pMensaje,Exception ex) : base(pMensaje,ex)
        {

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
