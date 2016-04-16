using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]


namespace Dominio
{
    class RangoFecha
    {
        private int iCodigo;
        private DateTime iFechaInicio;
        private DateTime iFechaFin;
        private List<RangoHorario> iListaRangosHorario;

        /// <summary>
        /// Constructor del Rango de Fechas
        /// </summary>
        public RangoFecha()
        {
            this.iListaRangosHorario = new List<RangoHorario>();
        }

        /// <summary>
        /// Get/Set del Código del Rango de Fechas
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }
        
        /// <summary>
        /// Get/Set de la Fecha de Inicio del Rango de Fechas
        /// </summary>
        public DateTime FechaInicio
        {
            get { return this.iFechaInicio; }
            set { this.iFechaInicio = value; }
        }

        /// <summary>
        /// Get/Set de la Fecha de Fin del Rango de Fechas
        /// </summary>
        public DateTime FechaFin
        {
            get { return this.iFechaFin; }
            set { this.iFechaFin = value; }
        }

        /// <summary>
        /// Get/Set de la Lista de Rangos de Horario
        /// </summary>
        public List<RangoHorario> ListaRangosHorario
        {
            get { return this.iListaRangosHorario; }
            set { this.iListaRangosHorario = value; }
        }

        /// <summary>
        /// Determina si un Rango de Fecha está dentro del actual
        /// </summary>
        /// <param name="pRangoFecha">Rango Fecha a verificar</param>
        /// <param name="pFecha">Fecha a verificar</param>
        /// <returns>Tipo de dato booleano que representa si un Rango de Fecha es actual</returns>
        public static bool RangoContieneFecha(RangoFecha pRangoFecha, DateTime pFecha)
        {
            DateTime hoy = pFecha.Date;
            return (pRangoFecha.FechaInicio.Date.CompareTo(hoy) <= 0 && pRangoFecha.FechaFin.Date.CompareTo(hoy) >= 0);
        }
    }
}
