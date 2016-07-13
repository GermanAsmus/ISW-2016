using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    class FuenteTextoFijo : IFuente
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

        /// <summary>
        /// Determina si la fuenteRSS debe actualizarse
        /// </summary>
        /// <returns>Tipo de dato bool que representa si debe actualizarse o no la fuenteRSS</returns>
        public bool Actualizable()
        {
            return false;
        }

        /// <summary>
        /// Determina si dos fuentes son iguales
        /// </summary>
        /// <param name="other">Otra Fuente a comparar</param>
        /// <returns>Tipo de dato bool que representa si dos Fuentes son iguales</returns>
        public bool Equals(IFuente other)
        {
            return (other.GetType() == this.GetType()) && (this.Codigo == other.Codigo);
        }

        /// <summary>
        /// Actualiza el Texto fijo (el texto fijo no cambia, es estático)
        /// </summary>
        public void Actualizar()
        {

        }
    }
}
