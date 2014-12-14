

namespace AJN.Gorman.API
{
    using Autofac;
    using Core.Services;

    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new PhaseService()).As<IPhaseService>();

            builder.Build();
        }
    }
}