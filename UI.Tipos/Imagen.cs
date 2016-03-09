using System.Drawing;

namespace UI.Tipos
{
    public class Imagen
    {
        private int iCodigo;
        private Image iPicture;
        private int iTiempo;

        /// <summary>
        /// Constructor de la Imagen
        /// </summary>
        public Imagen()
        {
            this.iTiempo = 0;
        }

        /// <summary>
        /// Get/Set del Código de la Imagen
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set de la Imagen (Image)
        /// </summary>
        public Image Picture
        {
            get { return this.iPicture; }
            set { this.iPicture = value; }
        }

        /// <summary>
        /// Get/Set del Tiempo en el que se reproduce la Imagen
        /// </summary>
        public int Tiempo
        {
            get { return this.iTiempo; }
            set { this.iTiempo = value; }
        }
    }
}
