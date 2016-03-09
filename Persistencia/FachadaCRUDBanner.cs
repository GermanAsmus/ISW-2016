using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Runtime.CompilerServices;

//Hace que sea visible para el Testing y los Servicios
[assembly: InternalsVisibleTo("Testings")]
[assembly: InternalsVisibleTo("Servicios")]

namespace Persistencia
{
    class FachadaCRUDBanner
    {
        private UnitOfWork iUnitOfWork;

        /// <summary>
        /// Constructor del CRUDFacade
        /// </summary>
        public FachadaCRUDBanner()
        {

        }

        /// <summary>
        /// Crea una Banner en la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a almacenar en la base de datos</param>
        /// <returns>Tipo de dato entero que representa el código del banner agregado</returns>
        public virtual int Create(Banner pBanner)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                this.iUnitOfWork.BannerRepository.Insert(pBanner);
                this.iUnitOfWork.Save();
                return pBanner.Codigo;
            }
        }

        /// <summary>
        /// Actualiza un Banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a actualizar de la base de datos</param>
        public virtual void Update(Banner pBanner)
        {
            Banner databaseBanner = this.GetByCodigo(pBanner.Codigo);
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                //Rangos Fecha
                List<RangoFecha> rangosFechaEliminados = ExtesionLista.GetDeleted<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
                List<RangoFecha> rangosFechaModificados = ExtesionLista.GetModified<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
                List<RangoFecha> rangosFechaAInsertar = ExtesionLista.GetNew<RangoFecha>(databaseBanner.RangosFecha, pBanner.RangosFecha);
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
                    List<RangoHorario> rangosHorariosEliminados = databaseBanner.RangosFecha.Find(x => x.Equals(pRangoFecha)).RangosHorario;
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
                    this.iUnitOfWork.BannerRepository.Update(pBanner);
                    this.iUnitOfWork.Save();
                }
            }
        }

        /// <summary>
        /// Elimina un Banner de la base de datos
        /// </summary>
        /// <param name="pBanner">Banner a eliminar</param>
        public virtual void Delete(Banner pBanner)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = new UnitOfWork();
                this.iUnitOfWork.BannerRepository.Delete(pBanner);
                this.iUnitOfWork.Save();
            }
        }

        /// <summary>
        /// Obtiene todos los Banners de la base de datos
        /// </summary>
        /// <returns>Tipo de dato Lista que representa los Banners almacenados en la base de dato</returns>
        public virtual List<Banner> GetAll()
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                List<Banner> listaBanners = this.iUnitOfWork.BannerRepository.context.Banners.ToList<Banner>();
                foreach (Banner banner in listaBanners)
                {
                    this.iUnitOfWork.BannerRepository.Queryable.Include("RangosFecha").ToList();
                    foreach (RangoFecha rangoFecha in banner.RangosFecha)
                    {
                        this.iUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return listaBanners;
            }
        }

        /// <summary>
        /// Obtiene una instancia de Banner
        /// </summary>
        /// <param name="pBannerCodigo">Código del Banner que se desea obtener</param>
        /// <returns></returns>
        public virtual Banner GetByCodigo(int pBannerCodigo)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                Banner banner = this.iUnitOfWork.BannerRepository.GetByCodigo(pBannerCodigo);
                this.iUnitOfWork.CampañaRepository.context.Entry(banner).Collection("RangosFecha").Load();
                foreach (RangoFecha rangoFecha in banner.RangosFecha)
                {
                    this.iUnitOfWork.RangoFechaRepository.context.Entry(rangoFecha).Collection("RangosHorario").Load();
                }
                return banner;
            }
        }

        /// <summary>
        /// Obtiene todos los Banner de la base de datos que cumplen con el filtro
        /// </summary>
        /// <param name="argumentosFiltrado">Argumentos para filtrar banners</param>
        /// <returns>Tipo de dato Lista de Banners a filtrar</returns>
        public virtual List<Banner> GetAll(Dictionary<string, object> argumentosFiltrado)
        {
            using (UnitOfWork pUnitOfWork = new UnitOfWork())
            {
                this.iUnitOfWork = pUnitOfWork;
                //usar tipos simple(no objetos)  porque tirar error si se usan objetos
                string nombre = (string)argumentosFiltrado["Nombre"];
                string texto = (string)argumentosFiltrado["Texto"];
                string url = (string)argumentosFiltrado["URL"];
                IQueryable<Banner> result = from banner in this.iUnitOfWork.BannerRepository.Queryable.Include("RangosFecha")
                                            where banner.Nombre.Contains(nombre)
                                            //where banner.Texto.Contains(texto)
                                            where banner.URL.Contains(url)
                                            select banner;
                List<Banner> resultado = new List<Banner>();
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
                    foreach (Banner banner in result)
                    {
                        resultado.Add(banner);
                    }
                }
                //cargar Rangos Horarios
                foreach (Banner banner in resultado)
                {
                    foreach (RangoFecha rangoFecha in banner.RangosFecha)
                    {
                        this.iUnitOfWork.RangoFechaRepository.Queryable.Include("RangosHorario").ToList();
                    }
                }
                return resultado;
            }
        }
    }
}