using System;
using System.Collections.Generic;

namespace Persistencia
{
    class Fachada
    {
        public int CrearCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.Create(pCampaña);
        }

        public void ActualizarCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            fachadaCampaña.Update(pCampaña);
        }

        public void EliminarCampaña(Campaña pCampaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            fachadaCampaña.Delete(pCampaña);
        }

        public int CrearBanner(Banner pBanner)
        {
            if (pBanner.Fuente.GetType() == typeof(FuenteTextoFijo))
            {
                pBanner.Fuente.Codigo = this.CrearFuente(pBanner.Fuente);
            }
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.Create(pBanner);
        }

        public void ActualizarBanner(Banner pBanner)
        {
            if(pBanner.Fuente.GetType() == typeof(FuenteTextoFijo))
            {
                this.ActualizarFuente(pBanner.Fuente);
            }
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            fachadaBanner.Update(pBanner);
        }

        public void EliminarBanner(Banner pBanner)
        {
            Fuente pFuente = pBanner.Fuente;
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            fachadaBanner.Delete(pBanner);
            if (pFuente.GetType() == typeof(FuenteTextoFijo))
            {
                this.EliminarFuente(pBanner.Fuente);
            }
        }

        public int CrearFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.Create(pFuente);
        }

        public void ActualizarFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            fachadaFuente.Update(pFuente);
        }

        public void EliminarFuente(Fuente pFuente)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            fachadaFuente.Delete(pFuente);
        }

        public List<Campaña> ObtenerCampañas()
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.GetAll();
        }

        public List<Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.GetAll(argumentosFiltrado);
        }

        public List<Banner> ObtenerBanners()
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.GetAll();
        }

        public List<Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.GetAll(argumentosFiltrado);
        }

        public List<Fuente> ObtenerFuentes(Type tipo)
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.GetAll(tipo);
        }

        public List<Fuente> ObtenerFuentes()
        {
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.GetAll();
        }
    }
}
