using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UI")]

namespace Dominio
{
    class Campaña : IEquatable<Campaña>
    {
        private int iCodigo;
        private int iInteravaloTiempo;
        private string iNombre;
        private List<RangoFecha> iListaRangosFecha;
        private List<Imagen> iListaImagenes;

        /// <summary>
        /// Constructor de la Campaña
        /// </summary>
        public Campaña()
        {
            this.iListaRangosFecha = new List<RangoFecha>();
            this.iListaImagenes = new List<Imagen>();
        }

        /// <summary>
        /// Get/Set del código de la campaña
        /// </summary>
        public int Codigo
        {
            get { return this.iCodigo; }
            set { this.iCodigo = value; }
        }

        /// <summary>
        /// Get/Set del intervalo de tiempo  de la campaña
        /// </summary>
        public int IntervaloTiempo
        {
            get { return this.iInteravaloTiempo; }
            set { this.iInteravaloTiempo = value; }
        }

        /// <summary>
        /// Get/Set del nombre de la campaña
        /// </summary>
        public string Nombre
        {
            get { return this.iNombre; }
            set { this.iNombre = value; }
        }

        /// <summary>
        /// Get/Set de la lista de Rangos de Fecha
        /// </summary>
        public List<RangoFecha> ListaRangosFecha
        {
            get { return this.iListaRangosFecha; }
            set { this.iListaRangosFecha = value; }
        }

        /// <summary>
        /// Get/Set de la lista de imágenes de la campaña
        /// </summary>
        public List<Imagen> ListaImagenes
        {
            get { return this.iListaImagenes; }
            set { this.iListaImagenes = value; }
        }
        
        /// <summary>
        /// Determina si dos campañas son iguales
        /// </summary>
        /// <param name="other">Otra campaña a comparar</param>
        /// <returns>Tipo de dato booleano que representa si dos campañas son iguales</returns>
        public bool Equals(Campaña other)
        {
            return this.Codigo == other.Codigo;
        }

        /// <summary>
        /// Devuelve los rangos Horarios ocupados por la campaña
        /// </summary>
        /// <returns>Tipo de dato Lista de Rangos Horarios que representan aquellos ocupados por la campaña</returns>
        public List<RangoHorario> ObtenerRangosHorariosOcupados()
        {
            List<RangoHorario> listaResultado = new List<RangoHorario>();
            foreach(RangoFecha pRangoFecha in this.iListaRangosFecha)
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
        private List<RangoHorario> RangosHorariosDeFecha(DateTime pFecha)
        {
            List<RangoHorario> listaRangosHorarios = new List<RangoHorario>();
            foreach (RangoFecha pRangoFecha in this.ListaRangosFecha)
            {
                if (RangoFecha.RangoContieneFecha(pRangoFecha, pFecha))
                {
                    listaRangosHorarios.AddRange(pRangoFecha.ListaRangosHorario);
                }
            }
            return listaRangosHorarios;
        }

        /// <summary>
        /// Devuelve los Rangos Horarios de los Rangos de Fecha que contienen la fecha suministrada
        /// </summary>
        /// <param name="pFecha">Fecha a contener</param>
        /// <returns>Tipo de dato Lista de Rangos Horarios que pertenencen a los Rangos de fecha que contienen la fecha suministrada</returns>
        public List<int> ListaDeIndices(DateTime pFecha)
        {
            List<int> listaResultado = new List<int>();
            List<RangoHorario> listaRangosHorarios = this.RangosHorariosDeFecha(pFecha);
            foreach (RangoHorario pRangoHorario in listaRangosHorarios)
            {
                for (int i = pRangoHorario.CodigoInicio; i < pRangoHorario.CodigoFin; i++)
                {
                    listaResultado.Add(i);
                }
            }
            return listaResultado;
        }
    }
}
