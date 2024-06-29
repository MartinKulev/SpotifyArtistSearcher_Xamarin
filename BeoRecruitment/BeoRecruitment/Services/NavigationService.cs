using System;
using System.Threading.Tasks;
using BeoRecruitment.Services.Interfaces;
using Xamarin.Forms;

namespace BeoRecruitment.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IViewLocator _viewLocator;

        public NavigationService(IServiceProvider serviceProvider, IViewLocator viewLocator)
        {
            _serviceProvider = serviceProvider;
            _viewLocator = viewLocator;
        }

        public Task NavigateToAsync<TViewModel>()
        {
            return NavigateToAsync<TViewModel, object>(null);
        }

        public Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter)
        {
            var viewType = _viewLocator.LocateView<TViewModel>();
            if (_serviceProvider.GetService(viewType) is Page page)
            {
                if (page.BindingContext is INavigationParameter<TParameter> viewModel)
                {
                    viewModel.SetParameter(parameter);
                }
                if (Application.Current.MainPage is NavigationPage navigationPage)
                {
                    return navigationPage.PushAsync(page);
                }
                else if (Application.Current.MainPage is INavigation navigation)
                {
                    return navigation.PushModalAsync(page);
                }
                return Task.CompletedTask;
            }

            throw new ArgumentOutOfRangeException(nameof(TViewModel), $@"Please register {viewType.FullName} with the IoC");
        }
    }
}

