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
        public void PruebaAutoMapperBannerUIModelo()
        {
            AutoMapper.Configurar();
            UI.Tipos.RangoHorario rangoHorario = new UI.Tipos.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<UI.Tipos.RangoHorario> listaRangosHorarios = new List<UI.Tipos.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            UI.Tipos.RangoFecha rangoFecha = new UI.Tipos.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<UI.Tipos.RangoFecha> listaRangosFechas = new List<UI.Tipos.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            UI.Tipos.Banner bannerUI = new UI.Tipos.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                Texto = "Hola",
                URL = "",
                ListaRangosFecha = listaRangosFechas
            };
            //UI a Modelo
            Modelo.Banner bannerModelo = (Modelo.Banner) Servicios.AutoMapper.Map<UI.Tipos.Banner, Modelo.Banner>(bannerUI);
            //Modelo a UI
            UI.Tipos.Banner bannerUICopia = (UI.Tipos.Banner)Servicios.AutoMapper.Map<Modelo.Banner, UI.Tipos.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerUI, bannerUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerUIModelo2()
        {
            AutoMapper.Configurar();
            UI.Tipos.RangoHorario rangoHorario = new UI.Tipos.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<UI.Tipos.RangoHorario> listaRangosHorarios = new List<UI.Tipos.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            UI.Tipos.RangoFecha rangoFecha = new UI.Tipos.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<UI.Tipos.RangoFecha> listaRangosFechas = new List<UI.Tipos.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            UI.Tipos.Banner bannerUI = new UI.Tipos.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                Texto = "",
                URL = "Hola",
                ListaRangosFecha = listaRangosFechas
            };
            //UI a Modelo
            Modelo.Banner bannerModelo = (Modelo.Banner)Servicios.AutoMapper.Map<UI.Tipos.Banner, Modelo.Banner>(bannerUI);
            //Modelo a UI
            UI.Tipos.Banner bannerUICopia = (UI.Tipos.Banner)Servicios.AutoMapper.Map<Modelo.Banner, UI.Tipos.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerUI, bannerUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerUIPersistencia()
        {
            AutoMapper.Configurar();
            UI.Tipos.RangoHorario rangoHorario = new UI.Tipos.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<UI.Tipos.RangoHorario> listaRangosHorarios = new List<UI.Tipos.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            UI.Tipos.RangoFecha rangoFecha = new UI.Tipos.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<UI.Tipos.RangoFecha> listaRangosFechas = new List<UI.Tipos.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            UI.Tipos.Banner bannerUI = new UI.Tipos.Banner()
            {
                Codigo = 1,
                Nombre = "Prueba",
                Texto = "Hola",
                URL = "",
                ListaRangosFecha = listaRangosFechas
            };
            //UI a Persistencia
            Persistencia.Banner bannerPersistencia = (Persistencia.Banner) Servicios.AutoMapper.Map<UI.Tipos.Banner, Persistencia.Banner>(bannerUI);
            //Persistencia a UI
            UI.Tipos.Banner bannerUICopia = (UI.Tipos.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, UI.Tipos.Banner>(bannerPersistencia);
            bool resul = Equality.Equals(bannerUI, bannerUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerPersistenciaModelo()
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
            //Persistencia a Modelo
            Modelo.Banner bannerModelo = (Modelo.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, Modelo.Banner>(bannerPersistencia);
            //Modelo a Persistencia
            Persistencia.Banner bannerPersistenciaCopia = (Persistencia.Banner)Servicios.AutoMapper.Map<Modelo.Banner, Persistencia.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerPersistencia, bannerPersistenciaCopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperBannerPersistenciaModelo2()
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
            //Persistencia a Modelo
            Modelo.Banner bannerModelo = (Modelo.Banner)Servicios.AutoMapper.Map<Persistencia.Banner, Modelo.Banner>(bannerPersistencia);
            //Modelo a Persistencia
            Persistencia.Banner bannerPersistenciaCopia = (Persistencia.Banner)Servicios.AutoMapper.Map<Modelo.Banner, Persistencia.Banner>(bannerModelo);
            bool resul = Equality.Equals(bannerPersistencia, bannerPersistenciaCopia);
            Assert.IsTrue(resul);
        }
        #endregion
        
        #region Campaña
        [TestMethod]
        public void PruebaAutoMapperCampañaUIModelo()
        {
            AutoMapper.Configurar();
            UI.Tipos.Imagen imagen = new UI.Tipos.Imagen
            {
                Codigo = 1,
                Tiempo = 10,
                Picture = Image.FromFile(@"F:/Lucho/Varios/Salida.jpg", true)
            };
            List<UI.Tipos.Imagen> listaImagenes = new List<UI.Tipos.Imagen>();
            listaImagenes.Add(imagen);
            UI.Tipos.RangoHorario rangoHorario = new UI.Tipos.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<UI.Tipos.RangoHorario> listaRangosHorarios = new List<UI.Tipos.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            UI.Tipos.RangoFecha rangoFecha = new UI.Tipos.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<UI.Tipos.RangoFecha> listaRangosFechas = new List<UI.Tipos.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            UI.Tipos.Campaña CampañaUI = new UI.Tipos.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                IntervaloTiempo = 12,
                ListaImagenes = listaImagenes,
                ListaRangosFecha = listaRangosFechas
            };
            //UI a Modelo
            Modelo.Campaña CampañaModelo = (Modelo.Campaña)Servicios.AutoMapper.Map<UI.Tipos.Campaña, Modelo.Campaña>(CampañaUI);
            //Modelo a UI
            UI.Tipos.Campaña CampañaUICopia = (UI.Tipos.Campaña)Servicios.AutoMapper.Map<Modelo.Campaña, UI.Tipos.Campaña>(CampañaModelo);
            bool resul = Equality.EqualsDesdeModelo(CampañaUI, CampañaUICopia);
            Assert.IsTrue(resul);
        }
     
        [TestMethod]
        public void PruebaAutoMapperCampañaUIPersistencia()
        {
            AutoMapper.Configurar();
            UI.Tipos.Imagen imagen = new UI.Tipos.Imagen
            {
                Codigo = 1,
                Tiempo = 10,
                Picture = Image.FromFile(@"F:/Lucho/Varios/Salida.jpg", true)
            };
            List<UI.Tipos.Imagen> listaImagenes = new List<UI.Tipos.Imagen>();
            listaImagenes.Add(imagen);
            UI.Tipos.RangoHorario rangoHorario = new UI.Tipos.RangoHorario()
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMilliseconds(122222222).TimeOfDay
            };
            List<UI.Tipos.RangoHorario> listaRangosHorarios = new List<UI.Tipos.RangoHorario>();
            listaRangosHorarios.Add(rangoHorario);
            UI.Tipos.RangoFecha rangoFecha = new UI.Tipos.RangoFecha()
            {
                Codigo = 1,
                FechaFin = DateTime.Today,
                FechaInicio = DateTime.Today.AddDays(-10),
                ListaRangosHorario = listaRangosHorarios
            };
            List<UI.Tipos.RangoFecha> listaRangosFechas = new List<UI.Tipos.RangoFecha>();
            listaRangosFechas.Add(rangoFecha);
            UI.Tipos.Campaña CampañaUI = new UI.Tipos.Campaña()
            {
                Codigo = 1,
                Nombre = "Prueba",
                IntervaloTiempo = 12,
                ListaImagenes = listaImagenes,
                ListaRangosFecha = listaRangosFechas
            };
            //UI a Persistencia
            Persistencia.Campaña CampañaPersistencia = (Persistencia.Campaña)Servicios.AutoMapper.Map<UI.Tipos.Campaña, Persistencia.Campaña>(CampañaUI);
            //Persistencia a UI
            UI.Tipos.Campaña CampañaUICopia = (UI.Tipos.Campaña)Servicios.AutoMapper.Map<Persistencia.Campaña, UI.Tipos.Campaña>(CampañaPersistencia);
            bool resul = Equality.Equals(CampañaUI, CampañaUICopia);
            Assert.IsTrue(resul);
        }

        [TestMethod]
        public void PruebaAutoMapperCampañaPersistenciaModelo()
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
            //Persistencia a Modelo
            Modelo.Campaña CampañaModelo = (Modelo.Campaña)Servicios.AutoMapper.Map<Persistencia.Campaña, Modelo.Campaña>(CampañaPersistencia);
            //Modelo a Persistencia
            Persistencia.Campaña CampañaPersistenciaCopia = (Persistencia.Campaña)Servicios.AutoMapper.Map<Modelo.Campaña, Persistencia.Campaña>(CampañaModelo);
            bool resul = Equality.EqualsDesdeModelo(CampañaPersistencia, CampañaPersistenciaCopia);
            Assert.IsTrue(resul);
        }
        #endregion
    }
}
