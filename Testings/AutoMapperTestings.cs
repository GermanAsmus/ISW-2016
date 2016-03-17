using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Drawing;
using Servicios;

namespace Testings
{
    [TestClass]
    public class AutoMapperTestings
    {
        #region Configurar AutoMapper
        [TestMethod]
        public void PruebaConfigurarAutoMapper()
        {
            AutoMapper.Configurar();
        }
        #endregion

        #region Fuente
        [TestMethod]
        public void FuenteRSSPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.FuenteRSS persistenciaObjeto = new Persistencia.FuenteRSS()
            {
                Codigo = 1,
                Valor = "Diario Google",
                URL = "www.google.com.ar",
                Descripcion = "Página oficial del Diario Google"
            };
            Dominio.FuenteRSS dominioObjeto =
                AutoMapper.Map<Persistencia.FuenteRSS, Dominio.FuenteRSS>(persistenciaObjeto);
            Persistencia.FuenteRSS persitenciaAuxiliar =
                AutoMapper.Map<Dominio.FuenteRSS, Persistencia.FuenteRSS>(dominioObjeto);
            bool resul = Equality.Equals(persistenciaObjeto, persitenciaAuxiliar);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void FuenteTextoFijoPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.FuenteTextoFijo persistenciaObjeto = new Persistencia.FuenteTextoFijo()
            {
                Codigo = 1,
                Valor = "Publicite Aquí"
            };
            Dominio.FuenteTextoFijo dominioObjeto =
                AutoMapper.Map<Persistencia.FuenteTextoFijo, Dominio.FuenteTextoFijo>(persistenciaObjeto);
            Persistencia.FuenteTextoFijo persitenciaAuxiliar =
                AutoMapper.Map<Dominio.FuenteTextoFijo,Persistencia.FuenteTextoFijo> (dominioObjeto);
            bool resul = Equality.Equals(persistenciaObjeto, persitenciaAuxiliar);
            Assert.IsTrue(resul);
        }
        #endregion

        #region Banner
        [TestMethod]
        public void BannerPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.FuenteTextoFijo pFuente = new Persistencia.FuenteTextoFijo()
            {
                Codigo = 1,
                Valor = "Publicite Aquí"
            };
            Persistencia.Banner persistenciaObjeto = new Persistencia.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                Fuente = pFuente,
                Fuente_Codigo = pFuente.Codigo
            };
            Persistencia.RangoFecha rangoFecha = new Persistencia.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                Principal = persistenciaObjeto,
                Principal_Codigo = persistenciaObjeto.Codigo
            };
            Persistencia.RangoHorario rangoHorario = new Persistencia.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay,
                RangoFecha = rangoFecha,
                RangoFecha_Codigo = rangoFecha.Codigo
            };
            List<Persistencia.RangoHorario> listaRangosHorarios = new List<Persistencia.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            rangoFecha.RangosHorario = listaRangosHorarios;
            List<Persistencia.RangoFecha> listaRangosFechas = new List<Persistencia.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            persistenciaObjeto.RangosFecha = listaRangosFechas;
            Dominio.Banner dominioObjeto =
                AutoMapper.Map<Persistencia.Banner, Dominio.Banner>(persistenciaObjeto);
            Persistencia.Banner persitenciaAuxiliar =
                AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(dominioObjeto);
            bool resul = Equality.Equals(persistenciaObjeto, persitenciaAuxiliar);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void BannerDominioPersistencia()
        {
            AutoMapper.Configurar();
            Dominio.FuenteRSS pFuente = new Dominio.FuenteRSS()
            {
                Codigo = 1,
                URL = "www.google.com.ar",
                Descripcion = "Página oficial del Diario Google"
            };
            Dominio.RangoHorario rangoHorario = new Dominio.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<Dominio.RangoHorario> listaRangosHorarios = new List<Dominio.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            Dominio.RangoFecha rangoFecha = new Dominio.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<Dominio.RangoFecha> listaRangosFechas = new List<Dominio.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            Dominio.Banner dominioObjeto = new Dominio.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                InstanciaFuente = pFuente,
                ListaRangosFecha = listaRangosFechas
            };
            Persistencia.Banner persistenciaObjeto =
                AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(dominioObjeto);
            Dominio.Banner dominioAuxiliar =
                AutoMapper.Map<Persistencia.Banner, Dominio.Banner >(persistenciaObjeto);
            bool resul = Equality.Equals(dominioObjeto, dominioAuxiliar);
            Assert.IsTrue(resul);
        }
        #endregion

        #region Campaña
        [TestMethod]
        public void CampañaPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.FuenteTextoFijo pFuente = new Persistencia.FuenteTextoFijo()
            {
                Codigo = 1,
                Valor = "Publicite Aquí"
            };
            Persistencia.Campaña persistenciaObjeto = new Persistencia.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                IntervaloTiempo = 20
            };
            Persistencia.Imagen pImagen = new Persistencia.Imagen()
            {
                Codigo = 1,
                Picture = ImagenServices.ImageToByteArray(Image.FromFile(@"F:\Lucho\Varios\Salida.jpg")),
                Tiempo = 10,
                Campaña = persistenciaObjeto,
                Campaña_Codigo = persistenciaObjeto.Codigo
            };
            List<Persistencia.Imagen> listaImagenes = new List<Persistencia.Imagen>();
            listaImagenes.Add(pImagen);
            Persistencia.RangoFecha rangoFecha = new Persistencia.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                Principal = persistenciaObjeto,
                Principal_Codigo = persistenciaObjeto.Codigo
            };
            Persistencia.RangoHorario rangoHorario = new Persistencia.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay,
                RangoFecha = rangoFecha,
                RangoFecha_Codigo = rangoFecha.Codigo
            };
            List<Persistencia.RangoHorario> listaRangosHorarios = new List<Persistencia.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            rangoFecha.RangosHorario = listaRangosHorarios;
            List<Persistencia.RangoFecha> listaRangosFechas = new List<Persistencia.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            persistenciaObjeto.RangosFecha = listaRangosFechas;
            persistenciaObjeto.Imagenes = listaImagenes;
            Dominio.Campaña dominioObjeto =
                AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(persistenciaObjeto);
            Persistencia.Campaña persitenciaAuxiliar =
                AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(dominioObjeto);
            bool resul = Equality.Equals(persistenciaObjeto, persitenciaAuxiliar);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void CampañaDominioPersistencia()
        {
            AutoMapper.Configurar();
            Dominio.FuenteTextoFijo pFuente = new Dominio.FuenteTextoFijo()
            {
                Codigo = 1,
                Valor = "Publicite Aquí"
            };
            Dominio.Imagen pImagen = new Dominio.Imagen()
            {
                Codigo = 1,
                Picture = Image.FromFile(@"F:\Lucho\Varios\Salida.jpg"),
                Tiempo = 10
            };
            List<Dominio.Imagen> listaImagenes = new List<Dominio.Imagen>();
            listaImagenes.Add(pImagen);
            Dominio.RangoHorario rangoHorario = new Dominio.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<Dominio.RangoHorario> listaRangosHorarios = new List<Dominio.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            Dominio.RangoFecha rangoFecha = new Dominio.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<Dominio.RangoFecha> listaRangosFechas = new List<Dominio.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            Dominio.Campaña dominioObjeto = new Dominio.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                ListaImagenes = listaImagenes,
                IntervaloTiempo = 20,
                ListaRangosFecha = listaRangosFechas
            };
            Persistencia.Campaña persistenciaObjeto =
                AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(dominioObjeto);
            Dominio.Campaña dominioAuxiliar =
                AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(persistenciaObjeto);
            bool resul = Equality.Equals(dominioObjeto, dominioAuxiliar);
            Assert.IsTrue(resul);
        }
        #endregion
    }
}
