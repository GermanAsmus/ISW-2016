using System;
using System.Linq;
using log4net;
using System.Reflection;

namespace Dominio
{
    static class Logging
    {
        private static readonly Lazy<ILog> cInstance = new Lazy<ILog>(() =>
        {
            ILog logger;
            logger = LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            log4net.Config.XmlConfigurator.Configure();
            return logger;
        });

        public static ILog Logger
        {
            get { return cInstance.Value; }
        }


    }
}
