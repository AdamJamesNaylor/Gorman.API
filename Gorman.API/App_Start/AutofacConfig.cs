
namespace Gorman.API {
    using System.Reflection;
    using System.Web.Http;
    using Autofac;
    using Autofac.Integration.WebApi;
    using Controllers;
    using Core.Services;

    public static class AutofacConfig {
        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();

            Core.AutofacConfig.RegisterDependencies(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register(c => new ActionController(c.Resolve<IActionService>()));
            builder.Register(c => new ActorController(c.Resolve<IActorService>()));
            builder.Register(c => new ActivityController(c.Resolve<IActivityService>(), c.Resolve<IActionService>()));
            builder.Register(
                c =>
                    new MapController(c.Resolve<IMapService>(), c.Resolve<IActivityService>(),
                        c.Resolve<IActorService>(), c.Resolve<IActionService>()));

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}