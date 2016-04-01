//using Common.Logging;
using System;
using System.Collections.Generic;
//using System.ServiceModel.Syndication;
using System.Xml;

namespace Dominio
{
    /// <summary>
    /// Implementación del lector de RSS basada en las clases de <see cref="System.ServiceModel.Syndication"/>.
    /// </summary>
    public class SyndicationFeedRssReader : RssReader
    {
        public override IEnumerable<RssItem> Read(Uri pUrl)
        {
            if (pUrl == null)
            {
                throw new ArgumentNullException("pUrl");
            }
            XmlReader mReader = XmlReader.Create(pUrl.AbsoluteUri);
            //SyndicationFeed mFeed = SyndicationFeed.Load(mReader);
            IList<RssItem> mRssItems = new List<RssItem>();
            return mRssItems;
        }

    }
}
