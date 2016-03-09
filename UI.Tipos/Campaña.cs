using System.Collections.Generic;

namespace UI.Tipos
{
    public class Campaña
    {
        private int iCodigo;
        private int iInteravaloTiempo;
        private string iNombre;
        private List<RangoFecha> iListaRangosFecha;
        private List<Imagen> iListaImagenes;

        /// <summary>
        /// Constructor de la Campaña
        /// </summary>
        public Campaña()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
            this.iListaImagenes = new List<Imagen>();
        }

        /// <summary>
        /// Get/Set del código de la campaña
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del intervalo de tiempo  de la campaña
        /// </summary>
        public int IntervaloTiempo
        {
            get { return this.iInteravaloTiempo; }
            set { this.iInteravaloTiempo = value; }
        }

        /// <summary>
        /// Get/Set del nombre de la campaña
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get/Set de la lista de imágenes de la campaña
        /// </summary>
        public List<Imagen> ListaImagenes
        {
            get { return this.iListaImagenes; }
            set { this.iListaImagenes = value; }
        }

        /// <summary>
        /// Get/Set de la lista de Rangos de Fecha
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }
    }
}
