using System;

namespace Dominio
{
    class RangoHorario
    {
        private TimeSpan iHoraInicio;
        private TimeSpan iHoraFin;
        private int iCodigo;

        /// <summary>
        /// Constructor del Rango de Horario
        /// </summary>
        public RangoHorario()
        {

        }

        /// <summary>
        /// Get/Set del Código del Rango Horario
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set de la Hora de Inicio del Rango Horario
        /// </summary>
        public TimeSpan HoraInicio
        {
            get { return this.iHoraInicio; }
            set { this.iHoraInicio = value; }
        }

        /// <summary>
        /// Get/Set de la Hora de Fin del Rango Horario
        /// </summary>
        public TimeSpan HoraFin
        {
            get { return this.iHoraFin; }
            set { this.iHoraFin = value; }
        }
    }
}
