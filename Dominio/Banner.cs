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
        private IFuente iFuente;
        private List<RangoFecha> iListaRangosFecha;

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
            get { return this.iFuente.Texto(); }

        }

        /// <summary>
        /// Get/Set de la Fuente del Banner
        /// </summary>
        public IFuente InstanciaFuente
        {
            get { return this.iFuente; }
            set { this.iFuente = value; }
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
        /// Compara dos intancias de Banner
        /// </summary>
        /// <param name="other">Otro Banner a comparar</param>
        /// <returns>Tipo de dato booleano que representa si dos instancias de Banner son diferentes</returns>
        public bool Equals(Banner other)
        {
            return this.Codigo == other.Codigo;
        }

        /// <summary>
        /// Devuelve los rangos Horarios ocupados por el Banner
        /// </summary>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representan aquellos ocupados por el Banner</returns>
        public List<RangoHorario> ObtenerRangosHorariosOcupados()
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach (RangoFecha pRangoFecha in this.iListaRangosFecha)
            {
                listaResultado.AddRange(pRangoFecha.ListaRangosHorario);
            }
            return listaResultado;
        }

        /// <summary>
        /// Devuelve los Rangos Horarios de los Rangos de Fecha que contienen la fecha suministrada
        /// </summary>
        /// <param name="pFecha">Fecha a contener</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que pertenencen a los Rangos de fecha que contienen la fecha suministrada</returns>
        public List<RangoHorario> RangosHorariosDeFecha(DateTime pFecha)
        {
            List<RangoHorario> listaRangosHorarios = new List<RangoHorario>();
            foreach(RangoFecha pRangoFecha in this.ListaRangosFecha)
            {
                if (RangoFecha.RangoContieneFecha(pRangoFecha, pFecha))
                {
                    listaRangosHorarios.AddRange(pRangoFecha.ListaRangosHorario);
                }
            }
            return listaRangosHorarios;
        }
    }
}
