using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRM.Site
{
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Reflection;
    using System.Web.Mvc;
    using CRM.Common;
    public class AutofacConfig
    {
        //负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象创建 
        //接管DefaultControllerFactory工作
        public static void Register()
        {
            //实例化一个autofac的创建容器
            var builder = new ContainerBuilder();
            //告诉Autofac框架，将来要创建的控制器存放在哪个程序集CRM.Site
            Assembly controllerAss = Assembly.Load("CRM.Site");
            builder.RegisterControllers(controllerAss);

            //数据仓储层所有程序集中所有类的对象实例
            Assembly respAss = Assembly.Load("CRM.Repository");
            builder.RegisterTypes(respAss.GetTypes()).AsImplementedInterfaces();

            //业务逻辑层所在程序集中所有类的对象实例
            Assembly serAss = Assembly.Load("CRM.Services");
            builder.RegisterTypes(serAss.GetTypes()).AsImplementedInterfaces();

            //创建autofac容器
            var container = builder.Build();
            //将container缓存到httpRuntime.cache中，并且永久有效
            CacheMgr.SetData(Keys.AutofacContainer, container);
            //mvc控制器对象实例交给autofac来创建
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

       }
    }
}