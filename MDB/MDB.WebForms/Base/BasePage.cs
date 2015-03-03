using System.Web.UI;
using MDB.Unity;
using Microsoft.Practices.Unity;

namespace MDB.WebForms.Base
{
    public class BasePage : Page
    {
        protected IUnityContainer Container
        {
            get { return Application.GetContainer(); }
        }
    }
}