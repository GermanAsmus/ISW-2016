using System.Collections.Generic;
using System.Runtime.CompilerServices;

//Hace que sea visible para los Servicios, la UI y los Testings
[assembly: InternalsVisibleTo("Servicios")]
[assembly: InternalsVisibleTo("UI")]
[assembly: InternalsVisibleTo("Testings")]

namespace UI.Tipos
{
    public class Banner
    {
        private int iCodigo;
        private string iNombre;
        private string iURL;
        private string iTexto;
        private List<RangoFecha> iListaRangosFecha;

        /// <summary>
        /// Devuelve el valor de TextoFijo
        /// </summary>
        /// <returns>Tipo de dato string que representa el TextoFijo</returns>
        public static string TextoFijo()
        {
            return "Texto Fijo";
        }

        /// <summary>
        /// Devuelve el valor de RSS
        /// </summary>
        /// <returns>Tipo de dato string que representa el RSS</returns>
        public static string RSS()
        {
            return "Fuente RSS";
        }

        /// <summary>
        /// Constructor del Banner
        /// </summary>
        public Banner()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
        }

        /// <summary>
        /// Get/Set del código del Banner
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del nombre del Banner
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get del Texto del Banner
        /// </summary>
        public string Texto
        {
            get { return this.iTexto; }
            set { this.iTexto = value; }
        }

        /// <summary>
        /// Get del URL del Banner
        /// </summary>
        public string URL
        {
            get { return this.iURL; }
            set { this.iURL = value; }
        }

        /// <summary>
        /// Get/Set de la Lista de Rangos de Fechas
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }

        /// <summary>
        /// Get del Tipo de Banner (RSS o Texto Fijo)
        /// </summary>
        public string Tipo
        {
            get
            {
                string resultado;
                if (this.Texto != "")
                {
                    resultado = TextoFijo();
                }
                else
                {
                    resultado = RSS();
                }
                return resultado;
            }
        }
    }
}
