//using Common.Logging;
using System;
using System.Collections.Generic;
using System.Xml;
using log4net;

namespace Dominio
{
    /// <summary>
    /// Lector de RSS que procesa directamente el XML en bruto de la fuente.
    /// </summary>
    public class RawXmlRssReader : RssReader
    {
        public override IEnumerable<RssItem> Read(Uri pUrl)
        {
            if (pUrl == null)
            {
                throw new ArgumentNullException("pUrl");
            }
            XmlTextReader mXmlReader = new XmlTextReader(pUrl.AbsoluteUri);
            XmlDocument mRssXmlDocument = new XmlDocument();
            Logging.Logger.Info("Obteniendo feeds...");
            Logging.Logger.DebugFormat("Obteniendo feeds desde {0}...", pUrl.AbsoluteUri);
            mRssXmlDocument.Load(mXmlReader);
            Logging.Logger.Info("Ha finalizado la obtención de feeds.");
            IList<RssItem> mRssItems = new List<RssItem>();
            Logging.Logger.Info("Adaptando feeds...");
            foreach (XmlNode bRssXmlItem in mRssXmlDocument.SelectNodes("//channel/item"))
            {
                mRssItems.Add(new RssItem
                {
                    Title = RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "title"),
                    Description = RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "description"),
                    Url = new Uri(RawXmlRssReader.GetXmlNodeValue<String>(bRssXmlItem, "link")),
                    PublishingDate = RawXmlRssReader.GetXmlNodeValue<DateTime?>(bRssXmlItem, "pubDate")
                });
            }
            Logging.Logger.Info("Devolviendo feeds adaptados...");
            return mRssItems;
        }

        private static TResult GetXmlNodeValue<TResult>(XmlNode pParentNode, String pChildNodeName)
        {
            if (pParentNode == null)
            {
                throw new ArgumentNullException("pParentNode");
            }

            if (String.IsNullOrWhiteSpace(pChildNodeName))
            {
                throw new ArgumentException("pChildNodeName");
            }
            // Inicialmente se devuelve el valor por defecto del tipo genérico. Si es un objeto, este valor es null, en caso contrario depende del tipo.
            TResult mResult = default(TResult);
            // Tipo utilizado para la conversión final. Por defecto va a ser el mismo tipo genérico indicado.
            Type mConvertToType = typeof(TResult);
            XmlNode mChildNode = pParentNode.SelectSingleNode(pChildNodeName);
            // Si el nodo existe, entonces se obtiene el valor del texto del mismo para convertirlo al tipo genérico indicado.
            if (mChildNode != null)
            {
                // Se comprueba si el tipo es Nullable, ya que en dicho caso se debe convertir al tipo subyacente y no directamente al Nullable.
                if (Nullable.GetUnderlyingType(mConvertToType) != null)
                {
                    mConvertToType = Nullable.GetUnderlyingType(mConvertToType);
                }
                // Se realiza la conversión del texto del nodo al tipo adecuado, ya sea el tipo genérico indicado o bien al tipo subyacente del Nullable.
                mResult = (TResult)Convert.ChangeType(mChildNode.InnerText.Trim(), mConvertToType);
            }
            return mResult;
        }

    }
}
