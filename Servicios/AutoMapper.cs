using AutoMapper;
using System.Drawing;
using Dominio;
using Persistencia;
using System.Collections.Generic;
using System;

namespace Servicios
{
    /// <summary>
    /// Clase responsable de hacer los mapeos entre diferentes clases de diferentes Capas
    /// </summary>
    public class AutoMapper
    {
        /// <summary>
        /// Configura los Mapeos entre diversas clases
        /// </summary>
        public static void Configurar()
        {
            #region Dominio-->Persistencia
            Mapper.CreateMap<Dominio.RangoHorario, Persistencia.RangoHorario>();
            Mapper.CreateMap<Dominio.Imagen, Persistencia.Imagen>()
                    .ForMember(dest => dest.Picture, opt => opt.ResolveUsing<PictureDominio>().ConstructedBy(() => new PictureDominio()));
            Mapper.CreateMap<Dominio.RangoFecha, Persistencia.RangoFecha>()
                    .ForMember(dest => dest.RangosHorario, opt => opt.MapFrom(src => src.ListaRangosHorario))
                    .AfterMap((s, d) => MapeoRangoFecha(d));
            Mapper.CreateMap<Dominio.Campaña, Persistencia.Campaña>()
                    .ForMember(dest => dest.Imagenes, opt => opt.MapFrom(src => src.ListaImagenes))
                    .ForMember(dest => dest.RangosFecha, opt => opt.MapFrom(src => src.ListaRangosFecha))
                    .AfterMap((s, d) => MapeoCampaña(d));
            Mapper.CreateMap<Dominio.IFuente, Persistencia.Fuente>()
                    .ConvertUsing<FuenteDominioConverter>();
            Mapper.CreateMap<Dominio.FuenteTextoFijo, Persistencia.FuenteTextoFijo>();
            Mapper.CreateMap<Dominio.FuenteRSS, Persistencia.FuenteRSS>();
            Mapper.CreateMap<Dominio.Banner, Persistencia.Banner>()
                    .ForMember(dest => dest.RangosFecha, opt => opt.MapFrom(src => src.ListaRangosFecha))
                    .ForMember(dest => dest.Fuente, opt => opt.MapFrom(src => src.InstanciaFuente))
                    .AfterMap((s, d) => MapeoBanner(d));
            #endregion

            #region Persistencia-->Dominio
            Mapper.CreateMap<Persistencia.RangoHorario, Dominio.RangoHorario>();
            Mapper.CreateMap<Persistencia.Imagen, Dominio.Imagen>()
                    .ForMember(dest => dest.Picture, opt => opt.ResolveUsing<PicturePersistencia>().ConstructedBy(() => new PicturePersistencia()));
            Mapper.CreateMap<Persistencia.RangoFecha, Dominio.RangoFecha>()
                    .ForMember(dest => dest.ListaRangosHorario, opt => opt.MapFrom(src => src.RangosHorario));
            Mapper.CreateMap<Persistencia.Campaña, Dominio.Campaña>()
                    .ForMember(dest => dest.ListaImagenes, opt => opt.MapFrom(src => src.Imagenes))
                    .ForMember(dest => dest.ListaRangosFecha, opt => opt.MapFrom(src => src.RangosFecha));
            Mapper.CreateMap<Persistencia.FuenteTextoFijo, Dominio.FuenteTextoFijo>();
            Mapper.CreateMap<Persistencia.FuenteRSS, Dominio.FuenteRSS>();
            Mapper.CreateMap<Persistencia.Fuente, Dominio.IFuente>()
                    .ConvertUsing<FuentePersistenciaConverter>();
            Mapper.CreateMap<Persistencia.Banner, Dominio.Banner>()
                    .ForMember(dest => dest.ListaRangosFecha, opt => opt.MapFrom(src => src.RangosFecha))
                    .ForMember(dest => dest.InstanciaFuente, opt => opt.MapFrom(src => src.Fuente));
            #endregion
        }

        /// <summary>
        /// Mappea Entre dos clases de objetos
        /// </summary>
        /// <typeparam name="TFuente">Clase del objeto fuente</typeparam>
        /// <typeparam name="TDestino">Clase del objeto destino</typeparam>
        /// <param name="pObjetoFuente">Objeto fuente del cual mapear la información</param>
        /// <returns>Tipo de dato TDestino que representa la clase del objeto que se pretende obtener</returns>
        public static TDestino Map<TFuente, TDestino>(TFuente pObjetoFuente)
        {
            return (TDestino)Mapper.Map(pObjetoFuente, typeof(TFuente), typeof(TDestino));
        }

        #region Métodos
        /// <summary>
        /// Asigna las propiedades de navegación del objeto
        /// </summary>
        /// <param name="pRangoFecha">Objeto Persistencia.RangoFecha a asingar propiedades de navegación</param>
        private static void MapeoRangoFecha(Persistencia.RangoFecha pRangoFecha)
        {
            foreach(Persistencia.RangoHorario pRangoHorario in pRangoFecha.RangosHorario)
            {
                pRangoHorario.RangoFecha = pRangoFecha;
                pRangoHorario.RangoFecha_Codigo = pRangoFecha.Codigo;
            }
        }

        /// <summary>
        /// Asigna las propiedades de navegación del objeto
        /// </summary>
        /// <param name="pBanner">Objeto Persistencia.Banner a asingar propiedades de navegación</param>
        private static void MapeoBanner(Persistencia.Banner pBanner)
        {
            foreach (Persistencia.RangoFecha pRangoFecha in pBanner.RangosFecha)
            {
                pRangoFecha.Principal = pBanner;
                pRangoFecha.Principal_Codigo = pBanner.Codigo;
            }
            pBanner.Fuente_Codigo = pBanner.Fuente.Codigo;
        }

        /// <summary>
        /// Asigna las propiedades de navegación del objeto
        /// </summary>
        /// <param name="pCampaña">Objeto Persistencia.Campaña a asingar propiedades de navegación</param>
        private static void MapeoCampaña(Persistencia.Campaña pCampaña)
        {
            foreach (Persistencia.RangoFecha pRangoFecha in pCampaña.RangosFecha)
            {
                pRangoFecha.Principal = pCampaña;
                pRangoFecha.Principal_Codigo = pCampaña.Codigo;
            }
            foreach (Persistencia.Imagen pImagen in pCampaña.Imagenes)
            {
                pImagen.Campaña = pCampaña;
                pImagen.Campaña_Codigo = pCampaña.Codigo;
            }
        }

        /// <summary>
        /// Clase responsable de resolver el Mapping de Picture de la Imagen del Dominio al de Persistencia
        /// </summary>
        private class PictureDominio : ValueResolver<Dominio.Imagen, byte[]>
        {
            /// <summary>
            /// Devuelve el byte[] de la imagen que se desea
            /// </summary>
            /// <param name="fuente">Byte[] de entrada a mappear</param>
            /// <returns>Tipo de dato byte[] que representa la Picture de la imagen</returns>
            protected override byte[] ResolveCore(Dominio.Imagen fuente)
            {
                return ImagenServices.ImageToByteArray(fuente.Picture);
            }
        }

        /// <summary>
        /// Clase responsable de resolver el Mapping de Picture de la Imagen de la Persistencia al Dominio
        /// </summary>
        private class PicturePersistencia : ValueResolver<Persistencia.Imagen, Image>
        {
            /// <summary>
            /// Devuelve el picture de la imagen que se desea
            /// </summary>
            /// <param name="fuente">Byte[] de entrada a mappear</param>
            /// <returns>Tipo de dato Image que representa la imagen del byte[]</returns>
            protected override Image ResolveCore(Persistencia.Imagen fuente)
            {
                return ImagenServices.ByteArrayToImage(fuente.Picture);
            }
        }

        /// <summary>
        /// Clase responsable de convertir de Fuente de Persistencia a Dominio
        /// </summary>
        private class FuentePersistenciaConverter : ITypeConverter<Persistencia.Fuente, Dominio.IFuente>
        {
            /// <summary>
            /// Convierte la fuente de la Persistencia al Dominio
            /// </summary>
            /// <param name="context">Contexto de conversión</param>
            /// <returns>Tipo de dato Fuente que representa la fuente del Dominio transformada</returns>
            public Dominio.IFuente Convert(ResolutionContext context)
            {
                Dominio.IFuente resultado;
                Persistencia.Fuente fuente = (Persistencia.Fuente) context.SourceValue;
                if(context.SourceValue.GetType() == typeof(Persistencia.FuenteRSS))
                {
                    resultado = Map<Persistencia.FuenteRSS, Dominio.FuenteRSS>((Persistencia.FuenteRSS)fuente);
                }
                else
                {
                    resultado = Map<Persistencia.FuenteTextoFijo, Dominio.FuenteTextoFijo>((Persistencia.FuenteTextoFijo)fuente);
                }
                return resultado;
            }
        }

        /// <summary>
        /// Clase responsable de convertir de Fuente de Dominio a Persistencia
        /// </summary>
        private class FuenteDominioConverter : ITypeConverter<Dominio.IFuente, Persistencia.Fuente>
        {
            /// <summary>
            /// Convierte la fuente del Dominio a la Persistencia
            /// </summary>
            /// <param name="context">Contexto de conversión</param>
            /// <returns>Tipo de dato Fuente que representa la fuente de la Persistencia transformada</returns>
            public Persistencia.Fuente Convert(ResolutionContext context)
            {
                Persistencia.Fuente resultado;
                Dominio.IFuente fuente = (Dominio.IFuente)context.SourceValue;
                if (context.SourceValue.GetType() == typeof(Dominio.FuenteRSS))
                {
                    resultado = Map<Dominio.FuenteRSS, Persistencia.FuenteRSS>((Dominio.FuenteRSS)fuente);
                }
                else
                {
                    resultado = Map<Dominio.FuenteTextoFijo, Persistencia.FuenteTextoFijo>((Dominio.FuenteTextoFijo)fuente);
                }
                return resultado;
            }
        }
        #endregion
    }
}
