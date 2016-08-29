


namespace Gorman.API
{
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Controllers;
    using Core.Services;
    using Core;

    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            Core.AutofacConfig.RegisterDependencies(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new PlanService(c.Resolve<IEntitiesContext>())).As<IPlanService>();
            builder.Register(c => new MapService(c.Resolve<IEntitiesContext>())).As<IMapService>();

            builder.Register(c => new MapController(c.Resolve<IMapService>()));
            builder.Register(c => new PlanController(c.Resolve<IPlanService>()));

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}