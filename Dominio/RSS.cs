namespace Dominio
{
    class RSS : ITexto
    {
        private string iURL;
        private string iValorAnterior;

        /// <summary>
        /// Constructor del RSS
        /// </summary>
        /// <param name="pURL">Texto propio</param>
        /// <param name="pDescripcion">Descripción del RSS</param>
        public RSS(string pURL, string pValorAnterior)
        {
            this.iURL = pURL;
            this.iValorAnterior = pValorAnterior;
        }

        /// <summary>
        /// Get de la URL del RSS
        /// </summary>
        public string URL
        {
            get { return this.iURL; }
        }

        /// <summary>
        /// Get Texto anterior del RSS   
        /// </summary>
        /// <returns>Tipo de dato string que representa el texto anterior de la fuente RSS</returns>
        public string Texto()
        {
            return this.iValorAnterior;
        }
    }
}
