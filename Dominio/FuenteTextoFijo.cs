using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    class FuenteTextoFijo : Fuente
    {
        private string iTexto;
        private int iCodigo;

        /// <summary>
        /// Constructor del Texto Fijo
        /// </summary>
        /// <param name="pTexto">Texto propio</param>
        public FuenteTextoFijo()
        {

        }

        /// <summary>
        /// Get/Set del código de la Fuente Texto Fijo
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Texto Fijo
        /// </summary>
        /// <returns>Tipo de dato string que representa el Texto Fijo</returns>
        public string Valor
        {
            get
            {
                return this.iTexto ;
            }
            set
            {
                this.iTexto = value;
            }
        }
        
        /// <summary>
        /// Obtiene el texto de la fuente
        /// </summary>
        /// <returns>Tipo de dato string que representa el texto de la fuente</returns>
        public string Texto()
        {
            return this.iTexto;
        }
    }
}
