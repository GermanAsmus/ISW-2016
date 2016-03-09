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
            //fachada.Create(campaña);
        }

        [TestMethod]
        public void PruebaFiltrarBanner()
        {
            FachadaCRUDBanner fachada = new FachadaCRUDBanner();
            Dictionary<string, object> argumentos = new Dictionary<string, object>();
            argumentos.Add("Nombre", "Mi");
            argumentos.Add("URL", "");
            argumentos.Add("Texto", "");
            /*
            RangoFecha pRF = new RangoFecha() { FechaInicio = DateTime.Today, FechaFin = DateTime.Today };
            argumentos.Add("Rango Fecha", pRF);
            */
            List<Banner> auxiliar = fachada.GetAll(argumentos);
            List<Banner> ayuda = fachada.GetAll();
            auxiliar.Sort();
        }
    }
}
