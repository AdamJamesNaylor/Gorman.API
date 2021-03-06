﻿

namespace Gorman.API.Core {

    using Autofac;
    using Builders;
    using Repositories;
    using Services;

    public static class AutofacConfig {
        public static void RegisterDependencies(ContainerBuilder builder) {
            builder.Register(c => new MapBuilder()).As<IMapBuilder>();
            builder.Register(c => new ActivityBuilder()).As<IActivityBuilder>();
            builder.Register(c => new ActorBuilder()).As<IActorBuilder>();
            builder.Register(c => new ActionBuilder()).As<IActionBuilder>();
            builder.Register(c => new ActionParameterBuilder()).As<IActionParameterBuilder>();

            builder.Register(c => new MapRepository(c.Resolve<IMapBuilder>())).As<IMapRepository>();
            builder.Register(c => new ActivityRepository(c.Resolve<IActivityBuilder>())).As<IActivityRepository>();
            builder.Register(c => new ActorRepository(c.Resolve<IActorBuilder>())).As<IActorRepository>();
            builder.Register(c => new ActionRepository(c.Resolve<IActionBuilder>())).As<IActionRepository>();
            builder.Register(c => new ActionParameterRepository(c.Resolve<IActionParameterBuilder>())).As<IActionParameterRepository>();

            builder.Register(c => new MapService(c.Resolve<IMapRepository>())).As<IMapService>();
            builder.Register(c => new ActivityService(c.Resolve<IActivityRepository>(), c.Resolve<IActorService>(), c.Resolve<IActionService>())).As<IActivityService>();
            builder.Register(c => new ActorService(c.Resolve<IActorRepository>())).As<IActorService>();
            builder.Register(c => new ActionService(c.Resolve<IActionRepository>(), c.Resolve<IActionParameterService>())).As<IActionService>();
            builder.Register(c => new ActionParameterService(c.Resolve<IActionParameterRepository>())).As<IActionParameterService>();
        }
    }
}
