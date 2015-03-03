using System.Collections.Generic;
using System.Reflection;
using System.Web.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MDB.Unity
{
    public class Bootstrapper
    {
        public void Configure(IUnityContainer container)
        {
            var config = GetConfigurationSection();

            container.LoadConfiguration(config);

            var assemblies = GetRegisteredAssemblies();

            container.RegisterTypes(AllClasses.FromAssemblies(assemblies), WithMappings.FromMatchingInterface, WithName.Default, WithLifetime.ContainerControlled);
        }

        private IEnumerable<Assembly> GetRegisteredAssemblies()
        {
            var assemblies = UnityConfigurationSection.CurrentSection.Assemblies;
            var list = new List<Assembly>();

            foreach (var assembly in assemblies)
            {
                var element = Assembly.LoadFrom(string.Format("{0}{1}.dll", System.Web.HttpRuntime.BinDirectory, assembly.Name));
                list.Add(element);
            }
            return list;
        }

        private UnityConfigurationSection GetConfigurationSection()
        {
            return (UnityConfigurationSection)WebConfigurationManager.GetSection("unity");
        }
    }
}