﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using webapi.Controllers;
using webapi.Services;
using WebGrease;

namespace webapi.Infrastructure
{
    public class DependencyRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
          
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<LogController>()
                .WithParameter(ResolvedParameter.ForNamed<ICacheManager>("nop_cache_static"));

            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
   


    }

    //public class AutoFacBootStrapper
    //{
    //    public static void CoreAutoFacInit()
    //    {
    //        var builder = new ContainerBuilder();
    //        HttpConfiguration config = GlobalConfiguration.Configuration;

    //        SetupResolveRules(builder);

    //        ////注册所有的Controllers
    //        //builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
    //        //注册所有的ApiControllers
    //        builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();

    //        var container = builder.Build();
    //        //注册api容器需要使用HttpConfiguration对象
    //        config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    //        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    //    }

    //    private static void SetupResolveRules(ContainerBuilder builder)
    //    {
    //        //WebAPI只用引用services和repository的接口，不用引用实现的dll。
    //        //如需加载实现的程序集，将dll拷贝到bin目录下即可，不用引用dll
    //        var iServices = Assembly.Load("WebAPI.IServices");
    //        var services = Assembly.Load("WebAPI.Services");
    //        var iRepository = Assembly.Load("WebAPI.IRepository");
    //        var repository = Assembly.Load("WebAPI.Repository");

    //        //根据名称约定（服务层的接口和实现均以Services结尾），实现服务接口和服务实现的依赖
    //        builder.RegisterAssemblyTypes(iServices, services)
    //          .Where(t => t.Name.EndsWith("Services"))
    //          .AsImplementedInterfaces();

    //        //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
    //        builder.RegisterAssemblyTypes(iRepository, repository)
    //          .Where(t => t.Name.EndsWith("Repository"))
    //          .AsImplementedInterfaces();
    //    }
    //}
}