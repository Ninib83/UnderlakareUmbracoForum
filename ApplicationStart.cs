using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using UmderlakareUmbCms.App_Start;

using UmderlakareUmbCms.Business.Helpers;
using Umbraco.Web;
using System.Web.Http.Dispatcher;

namespace UmderlakareUmbCms
{
    
    public class ApplicationStart : ApplicationEventHandler 
    {
        protected override void ApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            AreaRegistration.RegisterAllAreas();
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            GlobalConfiguration.Configuration.Services.
               Replace(typeof(IHttpControllerActivator), new UmbracoWebApiHttpControllerActivator());


        }

    }
}