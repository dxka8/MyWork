﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Admin.Compoent.Tool.Unity;
using Admin.Demo.Core.Data.Initialize;
using Admin.Demo.ISite;
using Admin.Demo.Core;


namespace Admin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            DatabaseInitializer.Initialize();
            //设置MEF依赖注入容器
            //DirectoryCatalog catalog=new DirectoryCatalog(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath);
            //MefDependencySolver solver=new MefDependencySolver(catalog);
            //DependencyResolver.SetResolver(solver);
            
            //设置unity依赖注入容器
           
        }
    }
}
