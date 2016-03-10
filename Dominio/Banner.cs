using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System;

//Hace que sea visible para el Testing, los Servicios y UI
[assembly: InternalsVisibleTo("Testings")]
[assembly: InternalsVisibleTo("Servicios")]
[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    class Banner : IEquatable<Banner>
    {
        private int iCodigo;
        private string iNombre;
        private ITexto iTexto;
        private List<RangoFecha> iListaRangosFecha;

        /// <summary>
        /// Devuelve un Banner es el Nulo (código -1)
        /// </summary>
        /// <returns>tipo de dato Banner que representa el Banner de código -1</returns>
        public static Banner BannerNulo()
        {
            TextoFijo pTextoFijo = new TextoFijo("");
            return new Banner()
            {
                Codigo = -1,
                InstanciaTexto = pTextoFijo
            };
        }

        /// <summary>
        /// Constructor del Banner
        /// </summary>
        public Banner()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
        }

        /// <summary>
        /// Get/Set del código del Banner
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del nombre del Banner
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get del Texto del Banner
        /// </summary>
        public string Texto
        {
            get { return this.iTexto.Texto(); }

        }

        /// <summary>
        /// Get/Set del iTexto del Banner
        /// </summary>
        public ITexto InstanciaTexto
        {
            get { return this.iTexto; }
            set { this.iTexto = value; }
        }

        /// <summary>
        /// Get/Set de la Lista de Rangos de Fechas
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }

        /// <summary>
        /// Busca un rango fecha en la lista de rangos fechas por un determinado código
        /// </summary>
        /// <param name="pCodigo">Código del rango fecha</param>
        /// <returns></returns>
        public RangoFecha BuscarRangoFechaEnLista(DateTime pFechaDesde, DateTime pFechaHasta)
        {
            return this.iListaRangosFecha.Find(x => (x.FechaInicio.Date.CompareTo(pFechaDesde.Date) == 0) &&
                                                    (x.FechaFin.Date.CompareTo(pFechaHasta.Date) == 0));
        }

        /// <summary>
        /// Compara dos intancias de Banner
        /// </summary>
        /// <param name="other">Otro Banner a comparar</param>
        /// <returns>Tipo de dato booleano que representa si dos instancias de Banner son diferentes</returns>
        public bool Equals(Banner other)
        {
            return this.Codigo == other.Codigo;
        }
    }
}
