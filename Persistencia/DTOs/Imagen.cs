using System.ComponentModel.DataAnnotations;
using System;

namespace Persistencia
{
    class Imagen : IEquatable<Imagen>
    {
        [Key]
        public int Codigo { get; set; }
        public byte[] Picture { get; set; }
        public int Tiempo { get; set; }

        /// <summary>
        /// Determina si dos Imágenes son iguales por código
        /// </summary>
        /// <param name="other">Otra Imagen</param>
        /// <returns>Tipo de dato booleano que representa si dos intancias son iguales o no</returns>
        public bool Equals(Imagen other)
        {
            return this.Codigo == other.Codigo;
        }
    }
}
