using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Persistencia
{
    class Banner
    {
        [Key]
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public Fuente Texto { get; set; }
        public string URL { get; set; }
        public List<RangoFecha> RangosFecha { get; set; }
    }
}
