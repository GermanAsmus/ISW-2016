using System;
using System.Collections.Generic;

namespace Modelo
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
    }
}
