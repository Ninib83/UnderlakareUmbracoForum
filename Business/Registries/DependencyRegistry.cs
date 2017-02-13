using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Dialogue.Logic.Services;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Services;
using UmderlakareUmbCms.Business.Services.Interfaces;

namespace UmderlakareUmbCms.Business.Registries
{
    public static class DependencyRegistry
    {
        public static IContainer RegisterDependencies(this ApplicationContext applicationContext)
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(Umbraco.Web.UmbracoApplication).Assembly);

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
     

            builder.RegisterType<Services.TopicService>()
                .As<ITopicsService>()
                .WithParameter("topicService", ServiceFactory.TopicService);

            builder.RegisterType <Services.MemberService>()
                .As<IMembersService>()
                .WithParameter("memberService", ServiceFactory.MemberService);

            builder.RegisterType<Services.PostService>()
                .As<IPostsService>()
                .WithParameter("postService", ServiceFactory.PostService);

            builder.RegisterType<Services.CategoryService>().Named<ICategorysService>("categoryService");
             
            //builder.RegisterType<Services.CategoryService>()
            //    .As<ICategorysService>()
            //    .WithParameter("categoryService", ServiceFactory.CategoryService);


            builder.RegisterInstance(applicationContext.Services.ContentService).As<IContentService>();
            builder.RegisterInstance(applicationContext.Services.UserService).As<IUserService>();
            

            var container = builder.Build();
            
            return container;
        }

    }
}