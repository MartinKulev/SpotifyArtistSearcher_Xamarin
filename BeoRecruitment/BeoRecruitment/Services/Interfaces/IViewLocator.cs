using System;
using Xamarin.Forms;

namespace BeoRecruitment.Services.Interfaces
{
    /// <summary>
    /// A very simple view locater that matches view models and views together.
    /// </summary>
    public interface IViewLocator
    {
        /// <summary>
        /// Register the view model <typeparamref name="TViewModel"/>
        /// with the view <typeparamref name="TView"/>.
        /// </summary>
        void RegisterView<TViewModel, TView>()
            where TViewModel : class
            where TView : Page;

        /// <summary>
        /// Used for locating a view given the view model <typeparamref name="TViewModel"/>.
        /// </summary>
        /// <returns>
        /// The type of the view registered with <typeparamref name="TViewModel"/>.
        /// </returns>
        Type LocateView<TViewModel>();
    }
}

