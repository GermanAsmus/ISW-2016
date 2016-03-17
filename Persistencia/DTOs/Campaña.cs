using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Persistencia
{
    class Campaña : RangoFecheable
    {
        public int IntervaloTiempo { get; set; }
        public string Nombre { get; set; }
        public List<Imagen> Imagenes { get; set; }

        /// <summary>
        /// Constructor Campaña
        /// </summary>
        public Campaña()
        {
            this.RangosFecha = new List<RangoFecha>();
            this.Imagenes = new List<Imagen>();
        }
    }
}
