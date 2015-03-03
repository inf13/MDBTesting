using System.Web;
using Microsoft.Practices.Unity;

namespace MDB.Unity
{
    public static class HttpApplicationStateExtensions
    {
        private const string UnityContainerKey = "UnityContainerKey";

        public static IUnityContainer GetContainer(this HttpApplicationState httpApplication)
        {
            var container = httpApplication[UnityContainerKey] as IUnityContainer;
            if (container == null)
            {
                httpApplication.Lock();
                try
                {
                    container = httpApplication[UnityContainerKey] as IUnityContainer;
                    if (container == null)
                    {
                        container = new UnityContainer();
                        httpApplication[UnityContainerKey] = container;
                    }
                }
                finally
                {
                    httpApplication.UnLock();
                }
            }
            return container;
        }
    }
}