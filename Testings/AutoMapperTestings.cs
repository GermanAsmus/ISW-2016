using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Servicios;
using System.Collections.Generic;
using System.Drawing;

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

        #region Banner

       

        [TestMethod]
        public void PruebaAutoMapperBannerDominioPersistencia()
        {
            AutoMapper.Configurar();
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
            Dominio.Banner bannerUI = new Dominio.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                ListaRangosFecha = listaRangosFechas
            };
            //Dominio a Persistencia
            Persistencia.Banner bannerPersistencia = (Persistencia.Banner) Servicios.AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(bannerUI);
            //Persistencia a Dominio
            Dominio.Banner bannerUICopia = (Dominio.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, Dominio.Banner>(bannerPersistencia);
            bool resul = Equality.Equals(bannerUI, bannerUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.RangoHorario rangoHorario = new Persistencia.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<Persistencia.RangoHorario> listaRangosHorarios = new List<Persistencia.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            Persistencia.RangoFecha rangoFecha = new Persistencia.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                RangosHorario = listaRangosHorarios
            };
            List<Persistencia.RangoFecha> listaRangosFechas = new List<Persistencia.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            Persistencia.Banner bannerPersistencia = new Persistencia.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                //Texto = "Hola",
                URL = "",
                RangosFecha = listaRangosFechas
            };
            //Persistencia a Dominio
            Dominio.Banner bannerModelo = (Dominio.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, Dominio.Banner>(bannerPersistencia);
            //Dominio a Persistencia
            Persistencia.Banner bannerPersistenciaCopia = (Persistencia.Banner)Servicios.AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerPersistencia, bannerPersistenciaCopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerPersistenciaDominio2()
        {
            AutoMapper.Configurar();
            Persistencia.RangoHorario rangoHorario = new Persistencia.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<Persistencia.RangoHorario> listaRangosHorarios = new List<Persistencia.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            Persistencia.RangoFecha rangoFecha = new Persistencia.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                RangosHorario = listaRangosHorarios
            };
            List<Persistencia.RangoFecha> listaRangosFechas = new List<Persistencia.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            Persistencia.Banner bannerPersistencia = new Persistencia.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                //Texto = "",
                URL = "Hola",
                RangosFecha = listaRangosFechas
            };
            //Persistencia a Dominio
            Dominio.Banner bannerModelo = (Dominio.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, Dominio.Banner>(bannerPersistencia);
            //Modelo a Persistencia
            Persistencia.Banner bannerPersistenciaCopia = (Persistencia.Banner)Servicios.AutoMapper.Map<Dominio.Banner, Persistencia.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerPersistencia, bannerPersistenciaCopia);
            Assert.IsTrue(resul);
        }
        #endregion
        
        #region Campaña
        
     
        [TestMethod]
        public void PruebaAutoMapperCampañaDominioPersistencia()
        {
            AutoMapper.Configurar();
            Dominio.Imagen imagen = new Dominio.Imagen
            {
                Codigo = 1,
                Tiempo = 10,
                Picture = Image.FromFile(@"F:/Lucho/Varios/Salida.jpg", true)
            };
            List<Dominio.Imagen> listaImagenes = new List<Dominio.Imagen>();
            listaImagenes.Add(imagen);
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
            Dominio.Campaña CampañaUI = new Dominio.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                IntervaloTiempo = 12,
                ListaImagenes = listaImagenes,
                ListaRangosFecha = listaRangosFechas
            };
            //Dominio a Persistencia
            Persistencia.Campaña CampañaPersistencia = (Persistencia.Campaña)Servicios.AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(CampañaUI);
            //Persistencia a Dominio
            Dominio.Campaña CampañaUICopia = (Dominio.Campaña)Servicios.AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(CampañaPersistencia);
            bool resul = Equality.Equals(CampañaUI, CampañaUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperCampañaPersistenciaDominio()
        {
            AutoMapper.Configurar();
            Persistencia.Imagen imagen = new Persistencia.Imagen
            {
                Codigo = 1,
                Tiempo = 10,
                Picture = ImagenServices.ImageToByteArray(Image.FromFile(@"F:/Lucho/Varios/Salida.jpg", true))
            };
            List<Persistencia.Imagen> listaImagenes = new List<Persistencia.Imagen>();
            listaImagenes.Add(imagen);
            Persistencia.RangoHorario rangoHorario = new Persistencia.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<Persistencia.RangoHorario> listaRangosHorarios = new List<Persistencia.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            Persistencia.RangoFecha rangoFecha = new Persistencia.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                RangosHorario = listaRangosHorarios
            };
            List<Persistencia.RangoFecha> listaRangosFechas = new List<Persistencia.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            Persistencia.Campaña CampañaPersistencia = new Persistencia.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                IntervaloTiempo = 12,
                Imagenes = listaImagenes,
                RangosFecha = listaRangosFechas
            };
            //Persistencia a Dominio
            Dominio.Campaña CampañaModelo = (Dominio.Campaña)Servicios.AutoMapper.Map<Persistencia.Campaña, Dominio.Campaña>(CampañaPersistencia);
            //Dominio a Persistencia
            Persistencia.Campaña CampañaPersistenciaCopia = (Persistencia.Campaña)Servicios.AutoMapper.Map<Dominio.Campaña, Persistencia.Campaña>(CampañaModelo);
            bool resul = Equality.EqualsDesdeModelo(CampañaPersistencia, CampañaPersistenciaCopia);
            Assert.IsTrue(resul);
        }
        #endregion
    }
}
