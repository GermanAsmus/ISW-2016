namespace Persistencia
{
    class FuenteRSS : Fuente
    {
        public string URL { get; set; }
        public string Descripcion { get; set; }
        public override string Valor { get; set; }
    }
}
