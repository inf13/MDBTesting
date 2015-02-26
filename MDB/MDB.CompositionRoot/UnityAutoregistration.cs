using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MDB.CompositionRoot
{
    public class UnityAutoregistration
    {
        public UnityContainer Registrate()
        {
            var config = GetConfigurationSection();

            var container = new UnityContainer();
            
            container.LoadConfiguration(config);

            var assemblies = GetRegisteredAssemblies();
            
            container.RegisterTypes(AllClasses.FromAssemblies(assemblies), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.ContainerControlled);

            return container;
        }

        private IEnumerable<Assembly> GetRegisteredAssemblies()
        {
            var assemblies = UnityConfigurationSection.CurrentSection.Assemblies;
            var list = new List<Assembly>();

            foreach (var assembly in assemblies)
            {
                var element = Assembly.LoadFrom(string.Format("{0}.dll",assembly.Name));
                list.Add(element);
            }
            return list;
        }

        private UnityConfigurationSection GetConfigurationSection()
        {
            var fileMap = new ExeConfigurationFileMap { ExeConfigFilename = "unity.config" };
            var configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None );

            return (UnityConfigurationSection)configuration.GetSection("unity");
        }
    }
}