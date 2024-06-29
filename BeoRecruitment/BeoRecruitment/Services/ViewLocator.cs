using System;
using System.Collections.Generic;
using BeoRecruitment.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace BeoRecruitment.Services
{
    public class ViewLocator : IViewLocator
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly Dictionary<Type, Type> _registeredViews = new Dictionary<Type, Type>();

        public ViewLocator(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        public void RegisterView<TViewModel, TView>()
            where TViewModel : class
            where TView : Page
        {
            _registeredViews[typeof(TViewModel)] = typeof(TView);
            _serviceCollection.AddTransient<TViewModel>();
            _serviceCollection.AddTransient<TView>();
        }

        public Type LocateView<TViewModel>()
        {
            return _registeredViews[typeof(TViewModel)];
        }
    }
}

