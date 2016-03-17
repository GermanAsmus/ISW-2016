using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    class FachadaCRUDCampaña
    {
        /// <summary>
        /// Constructor del CRUDFacade
        /// </summary>
        public FachadaCRUDCampaña()
        {

        }

        /// <summary>
        /// Crea (guarda) una Campaña junto con sus Imágenes y Rangos de Fecha en la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a almacenar en la base datos</param>
        /// <returns>Tipo de dato entero que representa el código de la campaña</returns>
        public virtual int Create(Campaña pCampaña)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pUnitOfWork.CampañaRepository.Insert(pCampaña);
                pUnitOfWork.Save();
                return pCampaña.Codigo;
            }
        }

        /// <summary>
        /// Actualiza una Campaña de la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a actualizar</param>
        public virtual void Update(Campaña pCampaña)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                Campaña databaseCampaña = this.GetByCodigo(pCampaña.Codigo);
                pUnitOfWork.CampañaRepository.Update(databaseCampaña);
                pUnitOfWork.CampañaRepository.ChangeValues(databaseCampaña, pCampaña);
                //Imágenes
                List<Imagen> imagenesEliminadas = ExtesionLista.GetDeleted<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                List<Imagen> imagenesModificadas = ExtesionLista.GetModified<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                List<Imagen> imagenesAInsertar = ExtesionLista.GetNew<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                foreach (Imagen pImagen in imagenesModificadas)
                {
                    Imagen imagenOriginal = databaseCampaña.Imagenes.Find(x => x.Equals(pImagen));
                    pUnitOfWork.ImagenRepository.ChangeValues(imagenOriginal, pImagen);
                }
                foreach (Imagen pImagen in imagenesEliminadas)
                {
                    //Para que no lance excepción
                    pImagen.Campaña = null;
                    pUnitOfWork.ImagenRepository.DeleteWithRelated(pImagen);
                }
                foreach (Imagen pImagen in imagenesAInsertar)
                {
                    //Para que no cree otra campaña
                    pImagen.Campaña = null;
                    pUnitOfWork.ImagenRepository.Insert(pImagen);
                }
                //Rangos Fecha
                List<RangoFecha> rangosFechaEliminados = ExtesionLista.GetDeleted<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                List<RangoFecha> rangosFechaModificados = ExtesionLista.GetModified<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                List<RangoFecha> rangosFechaAInsertar = ExtesionLista.GetNew<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                foreach (RangoFecha pRangoFecha in rangosFechaEliminados)
                {
                    pRangoFecha.Principal = null;
                    pUnitOfWork.RangoFechaRepository.DeleteWithRelated(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaAInsertar)
                {
                    pRangoFecha.Principal = null;
                    pUnitOfWork.RangoFechaRepository.Insert(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaModificados)
                {
                    //Actualizar Rango Fecha
                    RangoFecha rangoFechaOriginal = databaseCampaña.RangosFecha.Find(x => x.Equals(pRangoFecha));
                    pUnitOfWork.RangoFechaRepository.ChangeValues(rangoFechaOriginal, pRangoFecha);
                    //Rangos Horarios
                    List<RangoHorario> rangosHorariosAInsertar = pRangoFecha.RangosHorario;
                    for (int i = rangoFechaOriginal.RangosHorario.Count - 1; i >= 0; i--)
                    {
                        pUnitOfWork.RangoHorarioRepository.Delete(rangoFechaOriginal.RangosHorario[i]);
                    }
                    foreach (RangoHorario pRangoHorario in rangosHorariosAInsertar)
                    {
                        pRangoHorario.RangoFecha = null;
                        pUnitOfWork.RangoHorarioRepository.Insert(pRangoHorario);
                    }
                }
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Elimina una Campaña de la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a eliminar</param>
        public virtual void Delete(Campaña pCampaña)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                pUnitOfWork.CampañaRepository.DeleteWithRelated(pCampaña);
                pUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Obtiene una instancia de Campaña
        /// </summary>
        /// <param name="pCampañaCodigo">Código de la Campaña que se desea obtener</param>
        /// <returns>Tipo de dato Campaña que representa la buscada por código</returns>
        public virtual Campaña GetByCodigo(int pCampañaCodigo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                Campaña campaña = pUnitOfWork.CampañaRepository.GetByCodigo(pCampañaCodigo);
                foreach (RangoFecha rangoFecha in campaña.RangosFecha)
                {
                    RangoFecha aux = pUnitOfWork.RangoFechaRepository.GetByCodigo(rangoFecha.Codigo);
                    rangoFecha.RangosHorario = aux.RangosHorario;
                    rangoFecha.Principal = aux.Principal;
                }
                return campaña;
            }
        }

        /// <summary>
        /// Obtiene todos las Campañas de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista que representa todas las Campañas almacenadas en la base de datos</returns>
        public virtual List<Campaña> GetAll()
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                List<Campaña> listaCampañas = pUnitOfWork.CampañaRepository.GetAll();
                foreach (Campaña campaña in listaCampañas)
                {
                    //Por razones de eficiencia no cargamos las imágenes de todas las campañas sólo lo hacemos con el GetByCodigo
                    //pUnitOfWork.CampañaRepository.Queryable.Include("Imagen").ToList();
                    pUnitOfWork.CampañaRepository.Queryable.Include("RangosFecha").ToList();
                    foreach (RangoFecha rangoFecha in campaña.RangosFecha)
                    {
                        pUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return listaCampañas;
            }
        }

        /// <summary>
        /// Obtiene todos las Campañas de la base de datos que cumplen con el filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar campañas</param>
        /// <returns>Tipo de dato Lista de campañas a filtrar</returns>
        public virtual List<Campaña> GetAll(Dictionary<Type, object> argumentosFiltrado)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                string nombre = (string)argumentosFiltrado[typeof(string)];
                var result = from campaña in pUnitOfWork.CampañaRepository.Queryable.Include("RangosFecha")
                             where campaña.Nombre.Contains(nombre)
                             select campaña;
                List<Campaña> resultado = new List<Campaña>();
                if (argumentosFiltrado.ContainsKey(typeof(RangoFecha)))
                {
                    RangoFecha pRF = (RangoFecha)argumentosFiltrado[typeof(RangoFecha)];
                    DateTime fechaI = pRF.FechaInicio;
                    DateTime fechaF = pRF.FechaFin;
                    foreach (var campaña in result)
                    {
                        IQueryable<RangoFecha> rangoFecha = campaña.RangosFecha.AsQueryable<RangoFecha>();
                        var auxiliar = from rf in rangoFecha
                                       where ((rf.FechaInicio.Year <= fechaI.Year && rf.FechaInicio.Month <= fechaI.Month && rf.FechaInicio.Day <= fechaI.Day &&
                                              rf.FechaFin.Year >= fechaI.Year && rf.FechaFin.Month >= fechaI.Month && rf.FechaFin.Day >= fechaI.Day) ||
                                              (rf.FechaInicio.Year <= fechaF.Year && rf.FechaInicio.Month <= fechaF.Month && rf.FechaInicio.Day <= fechaF.Day &&
                                              rf.FechaFin.Year >= fechaF.Year && rf.FechaFin.Month >= fechaF.Month && rf.FechaFin.Day >= fechaF.Day) ||
                                              (rf.FechaInicio.Year >= fechaI.Year && rf.FechaInicio.Month >= fechaI.Month && rf.FechaInicio.Day >= fechaI.Day &&
                                              rf.FechaFin.Year <= fechaF.Year && rf.FechaFin.Month <= fechaF.Month && rf.FechaFin.Day <= fechaF.Day))
                                       select rf;
                        if (auxiliar.ToList().Count != 0)
                        {
                            resultado.Add(campaña);
                        }
                    }
                }
                else
                {
                    resultado = result.ToList();
                    /*
                    foreach (Campaña campaña in result)
                    {
                        resultado.Add(campaña);
                    }
                    */
                }
                //cargar Rangos Horarios
                foreach (Campaña campaña in resultado)
                {
                    foreach (RangoFecha rangoFecha in campaña.RangosFecha)
                    {
                        pUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return resultado;
            }
        }
    }
}
