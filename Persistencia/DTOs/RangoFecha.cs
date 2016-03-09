using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Persistencia
{
    class RangoFecha : IEquatable<RangoFecha>
    {
        [Key]
        public int Codigo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public List<RangoHorario> RangosHorario { get; set; }

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
