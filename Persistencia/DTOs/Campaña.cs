using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Persistencia
{
    class Campaña
    {
        [Key]
        public int Codigo { get; set; }
        public int IntervaloTiempo { get; set; }
        public string Nombre { get; set; }
        public List<Imagen> Imagenes { get; set; }
        public List<RangoFecha> RangosFecha { get; set; }
    }
}
