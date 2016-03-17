using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia
{
    abstract class RangoFecheable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Codigo { get; set; }
        public List<RangoFecha> RangosFecha { get; set; }
    }
}
