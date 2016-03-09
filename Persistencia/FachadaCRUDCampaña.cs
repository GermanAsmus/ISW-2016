using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Persistencia
{
    class FachadaCRUDCampaña
    {
        private UnitOfWork iUnitOfWork;

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
                this.iUnitOfWork = pUnitOfWork;
                this.iUnitOfWork.CampañaRepository.Insert(pCampaña);
                this.iUnitOfWork.Save();
                return pCampaña.Codigo;
            }
        }

        /// <summary>
        /// Actualiza una Campaña de la base de datos
        /// </summary>
        /// <param name="pCampaña">Campaña a actualizar</param>
        public virtual void Update(Campaña pCampaña)
        {
            Campaña databaseCampaña = this.GetByCodigo(pCampaña.Codigo);
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                //IMÁGENES
                List<Imagen> imagenesEliminadas = ExtesionLista.GetDeleted<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                List<Imagen> imagenesModificadas = ExtesionLista.GetModified<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                List<Imagen> imagenesAInsertar = ExtesionLista.GetNew<Imagen>(databaseCampaña.Imagenes, pCampaña.Imagenes);
                foreach (Imagen pImagen in imagenesModificadas)
                {
                    this.iUnitOfWork.ImagenRepository.Update(pImagen);
                }
                foreach (Imagen pImagen in imagenesEliminadas)
                {
                    this.iUnitOfWork.ImagenRepository.Delete(pImagen);
                }
                foreach (Imagen pImagen in imagenesAInsertar)
                {
                    this.iUnitOfWork.ImagenRepository.Insert(pImagen);
                }
                //RANGOS FECHA y HORARIO
                List<RangoFecha> rangosFechaEliminados = ExtesionLista.GetDeleted<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                List<RangoFecha> rangosFechaModificados = ExtesionLista.GetModified<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                List<RangoFecha> rangosFechaAInsertar = ExtesionLista.GetNew<RangoFecha>(databaseCampaña.RangosFecha, pCampaña.RangosFecha);
                foreach (RangoFecha pRangoFecha in rangosFechaEliminados)
                {
                    this.iUnitOfWork.RangoFechaRepository.Delete(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaAInsertar)
                {
                    this.iUnitOfWork.RangoFechaRepository.Insert(pRangoFecha);
                }
                foreach (RangoFecha pRangoFecha in rangosFechaModificados)
                {
                    //Rangos Horarios
                    List<RangoHorario> rangosHorariosEliminados = databaseCampaña.RangosFecha.Find(x => x.Equals(pRangoFecha)).RangosHorario;
                    List<RangoHorario> rangosHorariosAInsertar = pRangoFecha.RangosHorario;
                    foreach (RangoHorario pRangoHorario in rangosHorariosEliminados)
                    {
                        this.iUnitOfWork.RangoHorarioRepository.Delete(pRangoHorario);
                    }
                    foreach (RangoHorario pRangoHorario in rangosHorariosAInsertar)
                    {
                        this.iUnitOfWork.RangoHorarioRepository.Insert(pRangoHorario);
                    }
                    this.iUnitOfWork.RangoFechaRepository.Update(pRangoFecha);
                }
                this.iUnitOfWork.CampañaRepository.Update(pCampaña);
                this.iUnitOfWork.Save();
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
                this.iUnitOfWork = new UnitOfWork();
                this.iUnitOfWork.CampañaRepository.Delete(pCampaña);
                this.iUnitOfWork.Save();
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
                this.iUnitOfWork = pUnitOfWork;
                List<Campaña> listaCampañas = this.iUnitOfWork.CampañaRepository.context.Campañas.ToList<Campaña>();
                foreach (Campaña campaña in listaCampañas)
                {
                    //Por razones de eficiencia no cargamos las imágenes de todas las campañas sólo lo hacemos con el GetByCodigo
                    //this.iUnitOfWork.CampañaRepository.Queryable.Include("Imagen").ToList();
                    this.iUnitOfWork.CampañaRepository.Queryable.Include("RangosFecha").ToList();
                    foreach (RangoFecha rangoFecha in campaña.RangosFecha)
                    {
                        this.iUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return listaCampañas;
            }
        }

        /// <summary>
        /// Obtiene una instancia de Campaña
        /// </summary>
        /// <param name="pCampañaCodigo">Código de la Campaña que se desea obtener</param>
        /// <returns></returns>
        public virtual Campaña GetByCodigo(int pCampañaCodigo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                Campaña campaña = this.iUnitOfWork.CampañaRepository.GetByCodigo(pCampañaCodigo);
                this.iUnitOfWork.CampañaRepository.context.Entry(campaña).Collection("Imagenes").Load();
                this.iUnitOfWork.CampañaRepository.context.Entry(campaña).Collection("RangosFecha").Load();
                foreach(RangoFecha rangoFecha in campaña.RangosFecha)
                {
                    this.iUnitOfWork.RangoFechaRepository.context.Entry(rangoFecha).Collection("RangosHorario").Load();
                }
                return campaña;
            }
        }

        /// <summary>
        /// Obtiene todos las Campañas de la base de datos que cumplen con el filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar campañas</param>
        /// <returns>Tipo de dato Lista de campañas a filtrar</returns>
        public virtual List<Campaña> GetAll(Dictionary<string, object> argumentosFiltrado)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                string nombre = (string)argumentosFiltrado["Nombre"];
                var result = from campaña in this.iUnitOfWork.CampañaRepository.Queryable.Include("RangosFecha")
                             where campaña.Nombre.Contains(nombre)
                             select campaña;
                List<Campaña> resultado = new List<Campaña>();
                if (argumentosFiltrado.ContainsKey("Rango Fecha"))
                {
                    RangoFecha pRF = (RangoFecha)argumentosFiltrado["Rango Fecha"];
                    DateTime fechaI = pRF.FechaInicio;
                    DateTime fechaF = pRF.FechaFin;
                    foreach (var banner in result)
                    {
                        IQueryable<RangoFecha> rangoFecha = banner.RangosFecha.AsQueryable<RangoFecha>();
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
                            resultado.Add(banner);
                        }
                    }
                }
                else
                {
                    foreach (Campaña campaña in result)
                    {
                        resultado.Add(campaña);
                    }
                }
                //cargar Rangos Horarios
                foreach (Campaña campaña in resultado)
                {
                    foreach (RangoFecha rangoFecha in campaña.RangosFecha)
                    {
                        this.iUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return resultado;
            }
        }
    }
}
