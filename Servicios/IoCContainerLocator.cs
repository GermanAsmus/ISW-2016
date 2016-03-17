using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Configuration;

namespace Servicios
{
    /// <summary>
    /// Acceso al contenedor de IoC
    /// </summary>
    public static class IoCContainerLocator
    {
        /// <summary>
        /// Instancia lazy del contenedor de IoC.
        /// </summary>
        private static readonly Lazy<IUnityContainer> cInstance = new Lazy<IUnityContainer>(() =>
        {
            //ConfigurationFileMap fileMap = new ConfigurationFileMap("D:/App.config"); //Path to your config file
            //Configuration configuration = ConfigurationManager.OpenMappedMachineConfiguration(fileMap);
            // Se crea la instancia del contenedor, configurando el mismo a través del archivo de configuración de la aplicación
            IUnityContainer miContenedorUnity = new UnityContainer();
            UnityConfigurationSection section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            miContenedorUnity.LoadConfiguration(section);
            return miContenedorUnity;
        });

        /// <summary>
        /// Contenedor de instancias
        /// </summary>
        public static IUnityContainer Container
        {
            get { return cInstance.Value; }
        }

        /// <summary>
        /// Método para obtener una instancia de una Clase T
        /// </summary>
        /// <typeparam name="T">Clase a instanciar</typeparam>
        /// <returns>Tipo de dato de clase T que representa el objeto instancia de la clase</returns>
        public static T GetType<T>()
        {
            return IoCContainerLocator.Container.Resolve<T>();
        }
    }
}