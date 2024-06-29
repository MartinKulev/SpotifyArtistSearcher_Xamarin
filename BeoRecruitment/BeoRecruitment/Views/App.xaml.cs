using System;
using BeoRecruitment.Services;
using BeoRecruitment.Services.Interfaces;
using BeoRecruitment.ViewModels;
using BeoRecruitment.Views;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace BeoRecruitment
{
    public partial class App : Application
    {
        public App(Action<IServiceCollection> addPlatformServices = null)
        {
            InitializeComponent();

            ServiceProvider = SetupServices(addPlatformServices);

            MainPage = ServiceProvider.GetService<MainNavigationPage>();
        }

        protected IServiceProvider ServiceProvider { get; }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        private IServiceProvider SetupServices(Action<IServiceCollection> addPlatformServices)
        {
            var services = new ServiceCollection();

            var viewLocator = new ViewLocator(services);

            // Add platform specific services
            addPlatformServices?.Invoke(services);

            // Add navigation service
            services.AddSingleton<INavigationService>(i => new NavigationService(ServiceProvider, viewLocator));

            // Add ViewModels
            services.AddTransient<MainNavigationPage>();
            viewLocator.RegisterView<MainViewModel, MainPage>();
            viewLocator.RegisterView<DetailsViewModel, DetailsPage>();
            viewLocator.RegisterView<ArtistViewModel, ArtistPage>();

            // Add core services
            services.AddSingleton<IDataService, DataService>();
            services.AddSingleton<IArtistsService, ArtistsService>();
            services.AddSingleton<ISpotifyAPIService, SpotifyAPIService>();

            return services.BuildServiceProvider();
        }
    }
}

