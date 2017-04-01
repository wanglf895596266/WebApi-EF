using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using webapi.Controllers;
using webapi.DAL;
using webapi.Infrastructure;
using webapi.Services;
using WebGrease;

namespace webapi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static System.Web.Mvc.IDependencyResolver mvcResolver;
        public static System.Web.Http.Dependencies.IDependencyResolver apiResolver;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            DependencyRegistrar.Register();

            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LogController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));

            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            var webApiResolver = new AutofacWebApiDependencyResolver(container);
            apiResolver = webApiResolver;
            GlobalConfiguration.Configuration.DependencyResolver = webApiResolver;
        }

      
    }
}
