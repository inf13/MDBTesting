using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace MDB.Unity
{
    public class UnityHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            //context.PreRequestHandlerExecute += OnPreRequestHandlerExecute;
        }

        public void Dispose()
        {
            
        }


        private void OnPreRequestHandlerExecute(object sender, System.EventArgs e)
        {
            var handler = HttpContext.Current.Handler;
            HttpContext.Current.Application.GetContainer().BuildUp(handler.GetType(), handler, string.Empty, null);

            var page = HttpContext.Current.Handler as Page;
            if (page!=null)
            {
                page.InitComplete += OnPageInitComplete;
            }
        }

        private void OnPageInitComplete(object sender, EventArgs e)
        {
            var page = (Page) sender;
            var container = HttpContext.Current.Application.GetContainer();
            var controlTree = GetControlTree(page);
            foreach (var item in controlTree)
            {
                container.BuildUp(item.GetType(), item, string.Empty, null);
            }
        }

        private IEnumerable GetControlTree(Control root)
        {
            foreach (Control child in root.Controls)
            {
                yield return child;
                foreach (Control c in GetControlTree(child))
                {
                    yield return c;
                }
            }
        }
    }
}