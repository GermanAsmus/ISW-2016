using System;

namespace Dominio
{
    /// <summary>
    /// Ítem RSS.
    /// </summary>
    public class RssItem
    {

        /// <summary>
        /// Título del ítem.
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Descripción acerca del ítem.
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// URL del ítem.
        /// </summary>
        public Uri Url { get; set; }

        /// <summary>
        /// Fecha de publicación.
        /// </summary>
        public DateTime? PublishingDate { get; set; }

    }
}
