using System.Net;
using System;
using System.Threading.Tasks;
using Servicios.Excepciones;

namespace Servicios
{
    /// <summary>
    /// Clase responsable de brindar servicios Web
    /// </summary>
    public class WebServices
    {
        /// <summary>
        /// Verifica si la URL es válida, en caso contrario una excepción es lanzada
        /// </summary>
        /// <param name="pWebURL">URL a verificar si es válida</param>
        public static void VerificarURLVálida(string pWebURL)
        {
            try
            {
                Uri uriResult = new Uri(pWebURL, UriKind.Absolute);
                if (!(uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps))
                {
                    throw new UriFormatException();
                }
            }
            catch (ArgumentNullException ex)
            {
                string mensaje = "No se ha suministrado una URL";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch(Exception ex)
            {
                string mensaje = "El URL suministrado no es correcto, compruebe si es correcta :" + Environment.NewLine + pWebURL;
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
        }

        /// <summary>
        /// Verifica si la URL es válida para descargar, en caso contrario una excepción es lanzada
        /// </summary>
        /// <param name="pWebURL">URL a verificar si es válida para descarga</param>
        public static void VerificarURLDescargaVálida(string pWebURL)
        {
            try
            {
                HttpWebResponse response = null;
                var request = (HttpWebRequest)WebRequest.Create(pWebURL);
                request.Method = "HEAD";
                request.Timeout = 5*1000; //milisegundos
                response = (HttpWebResponse)request.GetResponse();
                response.Close();
            }
            catch (WebException ex)
            {
                string mensaje = "Problema al descargar de la URL especificada";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (ProtocolViolationException ex)
            {
                string mensaje = "El protocolo de Red especificado ha producido un error";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch(UriFormatException ex)
            {
                string mensaje = "El formato de URL no es válido";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch(NotSupportedException ex)
            {
                string mensaje = "El método invocado no es compatible, intento de Lectura/Escritura" + Environment.NewLine +
                                    "de secuencia incompatible con las funciones invocadas.";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (InvalidOperationException ex)
            {
                string mensaje = "Otra descarga está siendo procesada";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
        }
        
        /// <summary>
        /// Descarga información del URL especificado asíncronamente
        /// </summary>
        /// <param name="pWebURL">URL del cual se descarga información</param>
        /// <returns>Tipo de dato string que representa la información descargada del URL</returns>
        public async static Task<string> DescargarURLAsync(string pWebURL)
        {
            try
            {
                WebClient cliente = new WebClient();
                return await cliente.DownloadStringTaskAsync(new Uri(pWebURL));
            }
            catch (WebException ex)
            {
                string mensaje = "Problema al descargar de la URL especificada";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (NotSupportedException ex)
            {
                string mensaje = "El método invocado no es compatible, intento de Lectura/Escritura" + Environment.NewLine +
                                    "de secuencia incompatible con las funciones invocadas.";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (ArgumentNullException ex)
            {
                string mensaje = "No se ha suministrado URL";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
        }

        /// <summary>
        /// Descarga información del URL especificado
        /// </summary>
        /// <param name="pWebURL">URL del cual se descarga información</param>
        /// <returns>Tipo de dato string que representa la información descargada del URL</returns>
        public static string DescargarURL(string pWebURL)
        {
            try
            {
                WebClient cliente = new WebClient();
                return cliente.DownloadString(new Uri(pWebURL));
            }
            catch (WebException ex)
            {
                string mensaje = "Problema al descargar de la URL especificada";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (NotSupportedException ex)
            {
                string mensaje = "El método invocado no es compatible, intento de Lectura/Escritura" + Environment.NewLine +
                                    "de secuencia incompatible con las funciones invocadas.";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
            catch (ArgumentNullException ex)
            {
                string mensaje = "No se ha suministrado URL";
                throw new ExcepcionWeb(pWebURL, mensaje, ex);
            }
        }

        /// <summary>
        /// Comprueba si la URL de RSS es válida con retorno de valor booleano
        /// </summary>
        /// <param name="pWebURL">URL a verificar si es válida</param>
        /// <returns>Tipo de dato booleano que representa si la URL es válida o no</returns>
        public static bool ComprobarURLVálidaRSS(string pWebURL)
        {
            Uri mUrl;
            return Uri.TryCreate(pWebURL, UriKind.Absolute,out mUrl);
        }

        /// <summary>
        /// Obtiene el URL asociado al string
        /// </summary>
        /// <param name="pWebURL">URL a verificar si es válida</param>
        /// <returns>Tipo de dato booleano que representa si la URL es válida o no</returns>
        public static Uri ObtenerURLVálida(string pWebURL)
        {
            Uri mUrl = null;
            Uri.TryCreate(pWebURL, UriKind.RelativeOrAbsolute, out mUrl);
            return mUrl;
        }
    }
}
