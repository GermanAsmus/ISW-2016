namespace Modelo
{
    class TextoFijo : ITexto
    {
        private string iTexto;

        /// <summary>
        /// Constructor del Texto Fijo
        /// </summary>
        /// <param name="pTexto">Texto propio</param>
        public TextoFijo(string pTexto)
        {
            this.iTexto = pTexto;
        }
        
        /// <summary>
        /// Texto Fijo
        /// </summary>
        /// <returns>Tipo de dato string que representa el Texto Fijo</returns>
        public string Texto()
        {
            return this.iTexto;
        }

    }
}
