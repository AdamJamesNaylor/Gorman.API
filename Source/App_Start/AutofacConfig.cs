

namespace AJN.Gorman.API
{
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Controllers;
    using Core.Services;
    using Domain;

    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new EntitiesContext()).As<IEntitiesContext>();

            builder.Register(c => new PhaseService()).As<IPhaseService>();
            builder.Register(c => new MapService(c.Resolve<IEntitiesContext>())).As<IMapService>();

            builder.Register(c => new MapController(c.Resolve<IMapService>()));

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}