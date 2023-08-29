using Autofac;
using Autofac.Core;
using eCom_api.Interfaces;
using eCom_api.Repository;
using eCom_api.Services;

internal class WebModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        /*
        //It means that a new instance of the service will be created each time it is requested
        builder.RegisterType<MyService>().InstancePerDependency(); 
        //It means that a single instance of the service is created per lifetime scope.
        builder.RegisterType<MyScopedService>().InstancePerLifetimeScope(); 
        //It means that only one instance of the service is created and shared throughout the application.
        builder.RegisterType<MySingletonService>().SingleInstance(); 
        */
        //builder.RegisterType<IndexModel>().AsSelf(); //if wish to pass a model throgh DI
        /* RegisterType<IndexModel>(), it registers the IndexModel class as a dependency with Autofac.
         * .AsSelf(), it specifies that, Autofac will provide an instance of IndexModel when requested */
        builder.RegisterType<ProductRepository>().AsSelf();
        builder.RegisterType<StockRepository>().AsSelf();
        builder.RegisterType<CustomerProductRepository>().AsSelf();
        builder.RegisterType<SearchRepository>().AsSelf();
        builder.RegisterType<AdminRepository>().AsSelf();

        // Register a component with transient lifetime scope
        builder.RegisterType<TokenService>().As<ITokenService>().InstancePerDependency();
        builder.RegisterType<AdminRepository>().As<IAdminRepository>().InstancePerLifetimeScope();
        builder.RegisterType<TokenService>().As<ITokenService>().InstancePerLifetimeScope();

        base.Load(builder);
    }
}