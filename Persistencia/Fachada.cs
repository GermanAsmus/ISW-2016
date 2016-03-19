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

        public List<Campaña> ObtenerCampañas(Dictionary<Type, object> argumentosFiltrado = null)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return fachadaCampaña.GetAll(argumentosFiltrado);
        }

        public List<Imagen> ObtenerImagenesCampaña(int pCodigoCamapaña)
        {
            FachadaCRUDCampaña fachadaCampaña = new FachadaCRUDCampaña();
            return (fachadaCampaña.GetByCodigo(pCodigoCamapaña).Imagenes);
        }

        public int CrearBanner(Banner pBanner)
        {
            if (pBanner.Fuente.GetType() == typeof(FuenteTextoFijo))
            {
                pBanner.Fuente.Codigo = this.CrearFuente(pBanner.Fuente);
                pBanner.Fuente_Codigo = pBanner.Fuente.Codigo;
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

        public List<Banner> ObtenerBanners(Dictionary<Type, object> argumentosFiltrado = null)
        {
            FachadaCRUDBanner fachadaBanner = new FachadaCRUDBanner();
            return fachadaBanner.GetAll(argumentosFiltrado);
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

        public List<Fuente> ObtenerFuentes(Fuente pFuente = null)
        {
            Type filtro;
            if(pFuente == null)
            {
                filtro = null;
            }
            else
            {
                filtro = pFuente.GetType();
            }
            FachadaCRUDFuente fachadaFuente = new FachadaCRUDFuente();
            return fachadaFuente.GetAll(filtro);
        }
    }
}
