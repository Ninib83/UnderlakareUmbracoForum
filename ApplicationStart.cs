using System.Web.Http;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Umbraco.Core;
using UmderlakareUmbCms.App_Start;
using UmderlakareUmbCms.Business.Registries;
using UmderlakareUmbCms.Business.Helpers;
using Umbraco.Web;

namespace UmderlakareUmbCms
{
    
    public class ApplicationStart : IApplicationEventHandler /*UmbracoApplication*/
    {
        public void OnApplicationInitialized(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
           

        }



        public void OnApplicationStarting(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {
            

        }

        public void OnApplicationStarted(UmbracoApplicationBase umbracoApplication, ApplicationContext applicationContext)
        {

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            var container = applicationContext.RegisterDependencies();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }


    }
}