using Autofac;
using MyApp.ApplicationServices;
using MyApp.Domain;
using MyApp.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Bootstrapper
{
    public static class Bootstrap
    {
        public static IContainer Create()
        {
            return Create(null);
        }

        public static IContainer Create(Action<ContainerBuilder> additionalRegistrations)
        {
            IContainer container = null;

            var builder = new ContainerBuilder();

            RegisterEntityFramework(builder);
            RegisterDomainServices(builder);
            RegisterApplicationServices(builder);


            if (additionalRegistrations != null)
                additionalRegistrations.Invoke(builder);

            container = builder.Build();

            return container;
        }

        private static void RegisterEntityFramework(ContainerBuilder builder)
        {
            builder.RegisterType<MyAppContext>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.Register<IUnitOfWork>(c => new UnitOfWork(new MyAppContext())).InstancePerLifetimeScope();
            //builder.Register<IEFUnitOfWork>(c => new UnitOfWork(new MyAppContext())).InstancePerLifetimeScope();

            var assembly = typeof(MyAppContext).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private static void RegisterDomainServices(ContainerBuilder builder)
        {
            var assembly = typeof(LegoSet).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("DomainService")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("Factory")).AsImplementedInterfaces().InstancePerLifetimeScope();
        }

        private static void RegisterApplicationServices(ContainerBuilder builder)
        {
            var assembly = typeof(LegoSetApplicationService).Assembly;
            builder.RegisterAssemblyTypes(assembly).Where(x => x.Name.EndsWith("ApplicationService")).AsSelf().InstancePerLifetimeScope();
        }
    }
}
