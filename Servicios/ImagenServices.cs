using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Servicios
{
    /// <summary>
    /// Clase responsable de las Imágenes y sus respectivas transformaciones/representaciones
    /// </summary>
    public class ImagenServices
    {
        /// <summary>
        /// Transforma la imagen a un array de bytes
        /// </summary>
        /// <param name="imagenEntrada">Imagen de entrada que se transformará en un array de bytes</param>
        /// <returns>Tipo de dato Array de bytes que representa la imagen transformada</returns>
        public static byte[] ImageToByteArray(Image imagenEntrada)
        {
            MemoryStream ms = new MemoryStream();
            imagenEntrada.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        /// <summary>
        /// Transforma un array de bytes a una imagen
        /// </summary>
        /// <param name="arrayByteEntrada">Array de bytes de entrada que se transformará en una imagen</param>
        /// <returns></returns>
        public static Image ByteArrayToImage(byte[] arrayByteEntrada)
        {
            MemoryStream ms = new MemoryStream(arrayByteEntrada);
            Image image = Image.FromStream(ms);
            return image;
        }

        /// <summary>
        /// Cambia el tamaño de la imagen a un ancho y alto especificados
        /// </summary>
        /// <param name="imagen">Imagen a cambiar de tamaño</param>
        /// <param name="ancho">Ancho al cual cambiar</param>
        /// <param name="alto">Ancho al cual cambiar</param>
        /// <returns>Tipo de dato Imagen que representa la imagen cambiada de tamaño</returns>
        public static Bitmap CambiarTamañoImagen(Image imagen, int ancho, int alto)
        {
            var destRect = new Rectangle(0, 0, ancho, alto);
            var destImage = new Bitmap(ancho, alto);
            //Mantiene los DPI sin importar del tamaño físico, puede incrementar calidad al 
            //reducir las dimensiones o al mostrar
            destImage.SetResolution(imagen.HorizontalResolution, imagen.VerticalResolution);
            using (var gráficos = Graphics.FromImage(destImage))
            {
                gráficos.CompositingMode = CompositingMode.SourceCopy;
                gráficos.CompositingQuality = CompositingQuality.HighQuality;
                gráficos.InterpolationMode = InterpolationMode.HighQualityBicubic;
                gráficos.SmoothingMode = SmoothingMode.HighQuality;
                gráficos.PixelOffsetMode = PixelOffsetMode.HighQuality;
                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    gráficos.DrawImage(imagen, destRect, 0, 0, imagen.Width, imagen.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }
            return destImage;
        }
    }
}
