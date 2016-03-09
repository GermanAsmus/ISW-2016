using System;
using System.IO;
using Servicios.Excepciones;
using System.Threading.Tasks;

namespace Servicios
{
    /// <summary>
    /// Clase responsable del manejo de Archivos 
    /// </summary>
    public class ArchivoServices
    {
        /// <summary>
        /// Verifica si la dirección/ruta es válida, en caso contrario una excepción es lanzada
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del Archivo a verificar</param>
        public static void VerificarDireccionVálida(string pRutaArchivo)
        {
            try
            {
                // Abre el archivo de texto usando un stream reader
                StreamReader sr = new StreamReader(pRutaArchivo);
                //Liberar recursos del stream reader
                sr.Close();
                if (!File.Exists(pRutaArchivo))
                {
                    throw new ExcepcionArchivo(pRutaArchivo, "La ruta especificada no existe");
                }
            }
            catch (FileNotFoundException e)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "El archivo no existe", e));
            }
            catch (DirectoryNotFoundException e)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "La ruta del archivo es inválida", e));
            }
            catch (ArgumentNullException e)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "La ruta especificada es nula", e));
            }
            catch (ArgumentException e)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "No se ha proprocionado una ruta de archivo", e));
            }
            catch (IOException e)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "La ruta especificada contiene una sintaxis inválida: ruta errónea", e));
            }
        }

        /// <summary>
        /// Lee una cierta cantidad de líneas desde una posición inicial de lectura hasta el final
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del archivo a leer</param>
        /// <param name="posIncioLectura">Línea inicial a partir de la cual leer</param>
        /// <param name="cantidadLineasLectura">Cantidad de líneas a leer</param>
        /// <returns>Tipo de dato string que representa la lectura del archivo</returns>
        public static string LeerArchivo(string pRutaArchivo,int posIncioLectura,int cantidadLineasLectura)
        {
            try
            {
                StreamReader sr = new StreamReader(pRutaArchivo);
                string TextoArchivo = "";
                // Lee el stream a un string
                int i = 0;
                while ((i < posIncioLectura) && (i < File.ReadAllLines(pRutaArchivo).Length)) 
                {
                    sr.ReadLine();
                    i++;
                }
                i = 0;
                while ((i < cantidadLineasLectura) && (i < File.ReadAllLines(pRutaArchivo).Length))
                {
                    TextoArchivo += sr.ReadLine();
                    i++;
                }
                //Liberar recursos del stream reader
                sr.Close();
                return (TextoArchivo);
            }
            catch (OutOfMemoryException ex)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "El archivo es demasiado grande", ex));
            }
            catch (IOException ex)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "El archivo no existe", ex));
            }
        }

        /// <summary>
        /// Lee el archivo completo hasta el final
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del archivo a leer</param>
        /// <returns>Tipo de dato string que representa la lectura completa del archivo</returns>
        public static string LeerArchivo(string pRutaArchivo)
        {
            try
            {
                StreamReader sr = new StreamReader(pRutaArchivo);
                // Lee el stream a un string
                string TextoArchivo = sr.ReadToEnd();
                //Liberar recursos del stream reader
                sr.Close();
                return (TextoArchivo);
            }
            catch (OutOfMemoryException ex)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "El archivo es demasiado grande", ex));
            }
            catch (IOException ex)
            {
                throw (new ExcepcionArchivo(pRutaArchivo, "El archivo no existe", ex));
            }
        }

        /// <summary>
        /// Lee el contenido del archivo especificado por la ruta y lo devuelve
        /// </summary>
        /// <param name="pRutaArchivo">Ruta del archivo a leer</param>
        /// <returns>Tipo de dato string que representa el contenido del archivo leido</returns>
        public async static Task<string> LeerArchivoAsync(string pRutaArchivo)
        {
            // Abre el archivo de texto usando un stream reader
            StreamReader sr = new StreamReader(pRutaArchivo);
            // Lee el stream a un string
            string TextoArchivo = await sr.ReadToEndAsync();
            //Liberar recursos del stream reader
            sr.Close();
            return (TextoArchivo);
        }
    }
}
