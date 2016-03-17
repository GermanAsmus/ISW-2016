using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistencia
{
    abstract class Fuente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key,Column(Order = 0)]
        /// <summary>
        /// Código identificable de la fuente
        /// </summary>
        public int Codigo { get; set; }
        /// <summary>
        /// Último valor de la fuente
        /// </summary>
        public virtual string Valor { get; set; }
    }
}
