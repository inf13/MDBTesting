using System;

namespace MDB.CompositionRoot
{
    public class DependencyContainer
    {
        private static readonly Lazy<DependencyContainer> Lazy = new Lazy<DependencyContainer>(()=>new DependencyContainer());

        public static DependencyContainer Instance {
            get { return Lazy.Value; }
        }
        
        private DependencyContainer()
        {
           
        }
    }
}