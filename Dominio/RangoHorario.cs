using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]
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

        /// <summary>
        /// Get del código de la Hora de Inicio
        /// </summary>
        /// <returns>Tipo de dato entero que representa el código de la hora de inicio</returns>
        public int CodigoInicio
        {
            get
            {
                return (int)this.iHoraInicio.TotalMinutes;
            }
        }

        /// <summary>
        /// Get del código de la Hora de Fin
        /// </summary>
        /// <returns>Tipo de dato entero que representa el código de la hora de fin</returns>
        public int CodigoFin
        {
            get
            {
                return (int)this.iHoraFin.TotalMinutes;
            }
        }
    }
}
