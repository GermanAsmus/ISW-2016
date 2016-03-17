using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia
{
    class RangoFecha : IEquatable<RangoFecha>
    {
        [Column(Order = 0)]
        [Key]
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<RangoHorario> RangosHorario { get; set; }
        public virtual RangoFecheable Principal { get; set; }
        [ForeignKey("Principal"), Column(Order = 1)]
        public int Principal_Codigo { get; set; }

        /// <summary>
        /// Determina si dos Rango Fecha son iguales por código
        /// </summary>
        /// <param name="other">Otro Rango Fecha</param>
        /// <returns>Tipo de dato booleano que representa si dos intancias son iguales o no</returns>
        public bool Equals(RangoFecha other)
        {
            return this.Codigo == other.Codigo;
        }
    }
}
