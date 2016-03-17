using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia
{
    class Banner : RangoFecheable
    {
        public string Nombre { get; set; }
        public Fuente Fuente { get; set; }
        [ForeignKey("Fuente"), Column(Order = 2)]
        public int Fuente_Codigo { get; set; }

        /// <summary>
        /// Constructor Banner
        /// </summary>
        public Banner()
        {
            this.RangosFecha = new List<RangoFecha>();
        }
    }
}
