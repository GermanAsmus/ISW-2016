using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia;
using Servicios;
using System.Drawing;
using System.Collections.Generic;

namespace Testings
{
    [TestClass]
    public class PersistenciaTestings
    {
        [TestMethod]
        public void Campaña1Insertar()
        {
            Campaña campaña;
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            for (int i = 1; i < 61; i++)
            {
                campaña = new Campaña
                {
                    Codigo = i,
                    Nombre = "Prueba " + i.ToString(),
                    IntervaloTiempo = 80
                };
                List<Imagen> listaImagenes = new List<Imagen>(); listaImagenes.Add(this.CrearImagen(1, 1200000, campaña));
                List<RangoFecha> listaRangosFecha = new List<RangoFecha>(); listaRangosFecha.Add(this.CrearRangoFecha(1, DateTime.Today.AddDays(10),campaña));
                campaña.Imagenes = listaImagenes;
                campaña.RangosFecha = listaRangosFecha;
                fachada.CrearCampaña(campaña);
            }
        }

        [TestMethod]
        public void Campaña2Actualizar()
        {
            int i = 61;
            Campaña campaña = new Campaña
            {
                Codigo = i,
                Nombre = "PruebaActualizar",
                IntervaloTiempo = 80
            };
            List<Imagen> listaImagenes = new List<Imagen>(); listaImagenes.Add(this.CrearImagen(i, 100,campaña));
            listaImagenes.Add(this.CrearImagen(0, 150, campaña));
            List<RangoFecha> listaRangosFecha = new List<RangoFecha>(); listaRangosFecha.Add(this.CrearRangoFecha(i, DateTime.Today, campaña));
            campaña.Imagenes = listaImagenes;
            campaña.RangosFecha = listaRangosFecha;
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            fachada.ActualizarCampaña(campaña);
        }

        [TestMethod]
        public void Campaña3Eliminar()
        {
            int i = 61;
            Campaña campaña = new Campaña
            {
                Codigo = i
            };
            List<Imagen> listaImagenes = new List<Imagen>();
            listaImagenes.Add(this.CrearImagen(i, 1200000, campaña));
            listaImagenes.Add(this.CrearImagen(i+1, 1200000, campaña));
            List<RangoFecha> listaRangosFecha = new List<RangoFecha>();
            listaRangosFecha.Add(this.CrearRangoFecha(122, DateTime.Today.AddDays(10),campaña));
            campaña.Imagenes = listaImagenes;
            campaña.RangosFecha = listaRangosFecha;
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            fachada.EliminarCampaña(campaña);
        }

        [TestMethod]
        public void Campaña4GetAll()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerCampañas().Count > 0);
        }

        [TestMethod]
        public void Campaña5GetAllFiltro()
        {
            Dictionary<Type, object> argumentosFiltrado = new Dictionary<Type, object>();
            argumentosFiltrado.Add(typeof(string), "Prueba");
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerCampañas(argumentosFiltrado).Count > 0);
        }

        [TestMethod]
        public void Banner1Insercion()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            FuenteRSS pFuenteRSS = this.CrearFuenteRSS(3, "Predeterminado");
            Banner pBanner;
            FuenteTextoFijo pTextoFijo;
            for (int i = 1; i < 61; i++)
            {
                pBanner = new Banner()
                {
                    Codigo = i,
                    Nombre = "Banner N° " + i.ToString()
                };
                if (i < 31)
                {
                    pBanner.Fuente = pFuenteRSS;
                    pBanner.Fuente_Codigo = pFuenteRSS.Codigo; 
                }
                else
                {
                    pTextoFijo = this.CrearFuenteTextoFijo(i, "Texto Fijo N° " + (i - 30).ToString());
                    pBanner.Fuente = pTextoFijo;
                    pBanner.Fuente_Codigo = pTextoFijo.Codigo;
                }
                List<RangoFecha> listaRangosFecha = new List<RangoFecha>(); listaRangosFecha.Add(this.CrearRangoFecha(1, DateTime.Today.AddDays(10), pBanner));
                pBanner.RangosFecha = listaRangosFecha;
                fachada.CrearBanner(pBanner);
            }
        }

        [TestMethod]
        public void Banner2Actualizar()
        {
            List<RangoFecha> listaRangosFecha = new List<RangoFecha>();
            FuenteTextoFijo pTextoFijo = this.CrearFuenteTextoFijo(31, "dsad");
            Banner pBanner = new Banner()
            {
                Codigo = 31,
                Nombre = "Prueba",
                Fuente = pTextoFijo,
                Fuente_Codigo = pTextoFijo.Codigo
            };
            listaRangosFecha.Add(this.CrearRangoFecha(31, DateTime.Now.AddDays(2800), pBanner));
            listaRangosFecha.Add(this.CrearRangoFecha(12, DateTime.Now.AddDays(2800), pBanner));
            pBanner.RangosFecha = listaRangosFecha;
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            fachada.ActualizarBanner(pBanner);
        }

        [TestMethod]
        public void Banner3Eliminar()
        {
            int i = 33;
            List<RangoFecha> listaRangosFecha = new List<RangoFecha>();
            FuenteRSS pFuenteRSS = this.CrearFuenteRSS(33, "Fuente RSS " + i.ToString());
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Banner pBanner = new Banner()
            {
                Codigo = i,
                Fuente = pFuenteRSS,
                Fuente_Codigo = pFuenteRSS.Codigo
            };
            listaRangosFecha.Add(this.CrearRangoFecha(i, DateTime.Today,pBanner));
            pBanner.RangosFecha = listaRangosFecha;
            fachada.EliminarBanner(pBanner);
        }

        [TestMethod]
        public void Banner4GetAll()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerBanners().Count > 0);
        }

        [TestMethod]
        public void Banner5GetallFiltro()
        {
            Dictionary<Type, object> argumentosFiltrado = new Dictionary<Type, object>();
            argumentosFiltrado.Add(typeof(string), "Banner");
            argumentosFiltrado.Add(typeof(FuenteRSS), typeof(FuenteRSS));
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerBanners(argumentosFiltrado).Count > 0);
        }

        [TestMethod]
        public void Fuente1Insercion()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            FuenteRSS pFuenteRSS;
            for (int i = 1; i < 31; i++)
            {
                pFuenteRSS = this.CrearFuenteRSS(i, "Fuente RSS " + i.ToString());
                fachada.CrearFuente(pFuenteRSS);
            }
        }

        [TestMethod]
        public void Fuente2Actualizar()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            fachada.ActualizarFuente(this.CrearFuenteRSS(1, "Prueba"));
        }

        [TestMethod]
        public void Fuente3Eliminar()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            fachada.EliminarFuente(this.CrearFuenteRSS(3,"Prueba"));
        }

        [TestMethod]
        public void Fuente4GetAll()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerFuentes().Count > 30);
        }

        [TestMethod]
        public void Fuente5GetAllFiltro()
        {
            Persistencia.Fachada fachada = new Persistencia.Fachada();
            Assert.IsTrue(fachada.ObtenerFuentes(new FuenteTextoFijo()).Count <= 30);
        }

        [TestMethod]
        public void GetByCodigoBanner()
        {
            (new FachadaCRUDBanner()).GetByCodigo(1);
        }

        [TestMethod]
        public void GetByCodigoCampaña()
        {
            (new FachadaCRUDCampaña()).GetByCodigo(61);
        }

        /// <summary>
        /// Crea un RangoFecha
        /// </summary>
        /// <param name="pCodigo">Código del RangoFecha</param>
        /// <param name="pFechaInicio">Fecha Inicio del RangoFecha</param>
        /// <param name="pBanner">Campaña para la propiedad de navegación</param>
        /// <returns>Tipo de dato RangoFecha que representa el creado</returns>
        private RangoFecha CrearRangoFecha(int pCodigo,DateTime pFechaInicio,RangoFecheable pPrincipal)
        {
            List<RangoHorario> listaRangosHorario = new List<RangoHorario>();
            RangoFecha rf = new RangoFecha
            {
                Codigo = pCodigo,
                FechaInicio = pFechaInicio.Date,
                FechaFin = pFechaInicio.AddDays(1).Date,
                RangosHorario = listaRangosHorario,
                Principal = pPrincipal,
                Principal_Codigo = pPrincipal.Codigo
            };

            RangoHorario rh = new RangoHorario
            {
                Codigo = pCodigo,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.TimeOfDay,
                RangoFecha = rf,
                RangoFecha_Codigo = rf.Codigo
            };
            listaRangosHorario.Add(rh);
            return rf;
        }

        /// <summary>
        /// Crea una Imagen
        /// </summary>
        /// <param name="pCodigo">Código de la Imagen</param>
        /// <param name="pTiempoActualizacion">Tiempo de Actualización de la Imagen</param> 
        /// <param name="pCampaña">Campaña para la propiedad de navegación</param>
        /// <returns>Tipo de dato Imagen que representa la creada</returns>
        private Imagen CrearImagen(int pCodigo, int pTiempoActualizacion,Campaña pCampaña)
        {
            Imagen imagen = new Imagen
            {
                Codigo = pCodigo,
                Tiempo = pTiempoActualizacion,
                Campaña = pCampaña,
                Campaña_Codigo = pCampaña.Codigo
            };
            return imagen;
        }

        /// <summary>
        /// Crea una fuente de RSS
        /// </summary>
        /// <param name="pCodigo">Código de la fuente de RSS</param>
        /// <param name="pValor">Valor de la fuente de RSS</param>
        /// <returns>Tipo de dato fuente de RSS que representa el creado</returns>
        private FuenteRSS CrearFuenteRSS(int pCodigo,string pValor)
        {
            FuenteRSS pFuenteRSS = new FuenteRSS()
            {
                Codigo = pCodigo,
                Descripcion = "Inserción " + pCodigo.ToString(),
                URL = "URL N° " + pCodigo.ToString(),
                Valor = pValor
            };
            return pFuenteRSS;
        }
    
        /// <summary>
        /// Crea una fuente Texto Fijo
        /// </summary>
        /// <param name="pCodigo">Código de la fuente Texto Fijo</param>
        /// <param name="pValor">Valor de la fuente Texto Fijo</param>
        /// <returns>Tipo de dato fuente Texto fijo que representa el creado</returns>
        private FuenteTextoFijo CrearFuenteTextoFijo(int pCodigo, string pValor)
        {
            FuenteTextoFijo pFuenteTextoFijo = new FuenteTextoFijo()
            {
                Codigo = pCodigo,
                Valor = pValor
            };
            return pFuenteTextoFijo;
        }
    }
}
