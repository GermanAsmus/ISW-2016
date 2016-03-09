using AutoMapper;
using System.Drawing;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

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
            #region Modelo-->Persistencia
            Mapper.CreateMap<Dominio.RangoHorario, Persistencia.RangoHorario>();
            Mapper.CreateMap<Dominio.RangoFecha, Persistencia.RangoFecha>()
                    .ForMember(dest => dest.RangosHorario, opt => opt.MapFrom(src => src.ListaRangosHorario));
            Mapper.CreateMap<Dominio.Campaña, Persistencia.Campaña>()
                    .ForMember(dest => dest.RangosFecha, opt => opt.MapFrom(src => src.ListaRangosFecha));
            Mapper.CreateMap<Dominio.Banner, Persistencia.Banner>()
                    .ForMember(dest => dest.RangosFecha, opt => opt.MapFrom(src => src.ListaRangosFecha))
                    .ForMember(dest => dest.URL,opt => opt.ResolveUsing<BannerModeloURLTexto>().ConstructedBy(() => new BannerModeloURLTexto(true)))
                    .ForMember(dest => dest.Texto, opt => opt.ResolveUsing<BannerModeloURLTexto>().ConstructedBy(() => new BannerModeloURLTexto(false)));
            #endregion

            #region Persistencia-->Modelo
            Mapper.CreateMap<Persistencia.RangoHorario, Dominio.RangoHorario>();
            Mapper.CreateMap<Persistencia.RangoFecha, Dominio.RangoFecha>()
                    .ForMember(dest => dest.ListaRangosHorario, opt => opt.MapFrom(src => src.RangosHorario));
            Mapper.CreateMap<Persistencia.Campaña, Dominio.Campaña>()
                    .ForMember(dest => dest.ListaRangosFecha, opt => opt.MapFrom(src => src.RangosFecha));
            Mapper.CreateMap<Persistencia.Banner, Dominio.Banner>()
                .ForMember(dest => dest.ListaRangosFecha, opt => opt.MapFrom(src => src.RangosFecha))
                .ForMember(dest => dest.InstanciaTexto, opt => opt.ResolveUsing<BannerPersModInstanciaTexto>().ConstructedBy(() => new BannerPersModInstanciaTexto()));
            #endregion

        }

        /// <summary>
        /// Mappea Entre dos clases de objetos
        /// </summary>
        /// <typeparam name="TFuente">Clase del objeto fuente</typeparam>
        /// <typeparam name="TDestino">Clase del objeto destino</typeparam>
        /// <param name="pObejetoFuente">Objeto fuente del cual mapear la información</param>
        /// <returns>Tipo de dato TDestino que representa la clase del objeto que se pretende obtener</returns>
        public static TDestino Map<TFuente, TDestino>(TFuente pObejetoFuente)
        {
            return (TDestino)Mapper.Map(pObejetoFuente, typeof(TFuente), typeof(TDestino));
        }

        #region Resolución Mapeo
        /// <summary>
        /// Clase responsable de resolver el Mapping del URL y Texto del Banner del Modelo al de la Persistencia/UI
        /// </summary>
        private class BannerModeloURLTexto : ValueResolver<Dominio.Banner, string>
        {
            /// <summary>
            /// Booleano que es true si representa el URL, false si es el texto
            /// </summary>
            private bool iArgumento;

            /// <summary>
            /// Constructor
            /// </summary>
            /// <param name="pArgumento">Argumento booleano: True si es URL, falso en caso contrario</param>
            public BannerModeloURLTexto(bool pArgumento)
            {
                this.iArgumento = pArgumento;
            }

            /// <summary>
            /// Devuelve el resultado del campo del Banner que se desea
            /// </summary>
            /// <param name="fuente">Banner del Modelo de entrada a mappear</param>
            /// <returns>Tipo de dato string que representa la URL o Texto del Banner</returns>
            protected override string ResolveCore(Dominio.Banner fuente)
            {
                string pResultado = "";
                if (fuente.InstanciaTexto.GetType() == typeof(Dominio.RSS))
                {
                    if (this.iArgumento)
                    {
                        pResultado = ((Dominio.RSS)fuente.InstanciaTexto).URL;
                    }
                    else
                    {
                        pResultado = ((Dominio.RSS)fuente.InstanciaTexto).Texto();
                    }
                }
                else if ((fuente.InstanciaTexto.GetType() == typeof(Dominio.TextoFijo)) && !(this.iArgumento))
                {
                    pResultado = ((Dominio.TextoFijo)fuente.InstanciaTexto).Texto();
                }
                return pResultado;
            }
        }

        /// <summary>
        /// Clase responsable de resolver el Mapping de la InstanciaTexto del Banner de la Persistencia al del Modelo
        /// </summary>
        private class BannerPersModInstanciaTexto : ValueResolver<Persistencia.Banner, Dominio.ITexto>
        {
            /// <summary>
            /// Devuelve la instancia Texto que corresponde respecto a lo almacenado
            /// </summary>
            /// <param name="source">Banner de la Persistencia de entrada a mappear</param>
            /// <returns>Tipo de dato string que representa la instancia Texto del URL o Texto Banner</returns>
            protected override ITexto ResolveCore(Persistencia.Banner fuente)
            {
                dynamic resultado;
                if (fuente.URL == "")
                {

                    resultado = new Dominio.TextoFijo("");
                }
                else
                {
                    resultado = new Dominio.RSS(fuente.URL,"");
                }
                return resultado;
            }
        }

        /// <summary>
        /// Clase responsable de resolver el Mapping de Picture de la Imagen de la Persistencia al Modelo/UI
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
        /// Clase responsable de resolver el Mapping de Picture de la Imagen de la UI al de Persistencia
        /// </summary>
        private class PictureUI : ValueResolver<Dominio.Imagen, byte[]>
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
        #endregion

    }
}
