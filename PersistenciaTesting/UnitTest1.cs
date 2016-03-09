using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistencia;
using System.Drawing;
using Servicios;
using System.Collections.Generic;

namespace PersistenciaTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PrubaCrearCampaña()
        {
            Imagen imagen1 = new Imagen
            {
                Codigo = 1,
                Tiempo = 10,
                Picture = ImagenServices.ImageToByteArray(Image.FromFile(@"F:/Lucho/Varios/Salida.jpg", true))
            };
            List<Imagen> listaImagenes = new List<Imagen>();
            listaImagenes.Add(imagen1);
            RangoHorario rangoHor1 = new RangoHorario
            {
                Codigo = 1,
                HoraFin = DateTime.Now.TimeOfDay,
                HoraInicio = DateTime.Now.AddMinutes(98).TimeOfDay
            };
            RangoFecha rangoFecha1 = new RangoFecha
            {
                Codigo = 1,
                FechaInicio = DateTime.Today,
                FechaFin = DateTime.Today.AddDays(10),
                RangosHorario = new List<RangoHorario>()
            };
            rangoFecha1.RangosHorario.Add(rangoHor1);
            List<RangoFecha> listaRangosFecha = new List<RangoFecha>();
            listaRangosFecha.Add(rangoFecha1);
            Campaña campaña = new Campaña
            {
                Codigo = 1,
                Imagenes = listaImagenes,
                Nombre = "Prueba",
                IntervaloTiempo = 80,
                RangosFecha = listaRangosFecha
            };
            FachadaCRUDCampaña fachada = new FachadaCRUDCampaña();
            fachada.Create(campaña);
        }

        [TestMethod]
        public void PruebaUnity()
        {
            //List<IObserver> listaObservadores = Servicios.IoCContainerLocator.Container.Resolve<List<IObserver>()
        }
    }
}
