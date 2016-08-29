

namespace Gorman.API.Core {

    using Autofac;
    using Repositories;
    using Services;

    public static class AutofacConfig {
        public static void RegisterDependencies(ContainerBuilder builder) {
            builder.Register(c => new MapBuilder()).As<IMapBuilder>();
            builder.Register(c => new MapRepository(c.Resolve<IMapBuilder>())).As<IMapRepository>();
            builder.Register(c => new MapService(c.Resolve<IMapRepository>())).As<IMapService>();

        }
    }
}
