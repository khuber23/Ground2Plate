using Ground2Plate.Maui.Services.DI;
using Ground2Plate.Maui.ViewModels;

namespace Ground2Plate.Maui.Custom
{
    public static class DIRegisterer
    {
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
        {
            builder.Services.Scan(i =>
                i.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo<ITransient>())
                .AsImplementedInterfaces()
                .WithTransientLifetime()

                .AddClasses(c => c.AssignableTo<ISingleton>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime()

                .AddClasses(c => c.AssignableTo<IScoped>())
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );
            return builder;
        }

        public static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.Scan(i => 
                i.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo<ContentPage>())
                .AsSelf()
                .WithSingletonLifetime()
            );
            return builder;
        }

        public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.Scan(i =>
                i.FromCallingAssembly()
                .AddClasses(c => c.AssignableTo<BaseViewModel>())
                .AsSelf()
                .WithTransientLifetime()
            );
            return builder;
        }
    }
}
