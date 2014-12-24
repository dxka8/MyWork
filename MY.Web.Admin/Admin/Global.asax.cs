using System;
using System.Collections.Generic;

using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Admin.Compoent.Tool.Unity;
using Admin.Component.Data;
using Admin.Demo.Core.Data.Context;
using Admin.Demo.Core.Data.Initialize;
using Admin.Demo.Core.Data.Repositories.Account;
using Admin.Demo.Core.Impl;
using Admin.Demo.Core.Models.Account;
using Admin.Demo.ICore;
using Admin.Demo.ISite;
using Admin.Demo.Core;
using Admin.Demo.Site.Impl;
using Autofac;
using Autofac.Integration.Mvc;


namespace Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static IContainer Container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            DatabaseInitializer.Initialize();
           
            
            //设置unity依赖注入容器
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<AccountSiteService>().As<IAccountSiteContract>();

            builder.RegisterType<AccountSiteService>().PropertiesAutowired();
            builder.RegisterType<AccountService>().As<IAccountContract>();

            builder.RegisterType<MemberRepository>().PropertiesAutowired();
            builder.RegisterType<EfUnitOfWorkContext>().As<IUnitOfWork>();

            builder.RegisterType<EfUnitOfWorkContext>().PropertiesAutowired();
            builder.RegisterType<EfDbContext>().As<DbContext>();

            builder.RegisterType<AccountService>().PropertiesAutowired();
            builder.RegisterType<MemberRepository>().As<IMemberRepository>();

            //builder.RegisterType<EfDbContext>().PropertiesAutowired();
            //builder.RegisterGeneric(typeof(List<>)).As(typeof(IEnumerable<IEntityMapper>)).InstancePerLifetimeScope(); 
            Container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

        }
    }
}
