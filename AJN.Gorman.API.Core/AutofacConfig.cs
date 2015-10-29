

namespace AJN.Gorman.API.Core {

    using Autofac;

    public static class AutofacConfig {
        public static void RegisterDependencies(ContainerBuilder builder) {
            builder.Register(c => new EntitiesContext()).As<IEntitiesContext>();

        }
    }
}
