using System.ComponentModel.DataAnnotations;

namespace Persistencia
{
    public abstract class Fuente
    {
        [Key]
        public int Codigo { get; set; }
    }
}
