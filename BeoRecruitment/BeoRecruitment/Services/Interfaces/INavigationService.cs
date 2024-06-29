using System.Threading.Tasks;

namespace BeoRecruitment.Services.Interfaces
{
    /// <summary>
    /// The worlds most simple navigation service.
    /// </summary>
    public interface INavigationService
    {
        /// <summary>
        /// Navigate to a view model.
        /// </summary>
        /// <typeparam name="TViewModel">
        /// The view model to navigate to.
        /// </typeparam>
        Task NavigateToAsync<TViewModel>();

        /// <summary>
        /// Navigate to a view model parsing a parameter.<br/>
        /// The <typeparamref name="TViewModel"/> must implement
        /// <see cref="INavigationParameter{TParameter}"/> in order to receive the parameter.
        /// </summary>
        /// <typeparam name="TViewModel">
        /// The view model to navigate to.
        /// </typeparam>
        /// <typeparam name="TParameter">
        ///The type of the parameter to pass.
        /// </typeparam>
        /// <param name="parameter">
        /// The actual parameter.
        /// </param>
        Task NavigateToAsync<TViewModel, TParameter>(TParameter parameter);
    }

    /// <summary>
    /// Used for pasing parameters when navigating to view models.<br/>
    /// The view model must implement this interface in order to receive the parameter.
    /// </summary>
    /// <typeparam name="TParameter">
    /// The type of the parameter to pass.
    /// </typeparam>
    public interface INavigationParameter<TParameter>
    {
        /// <summary>
        /// This is called before the view model is navigated to.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to pass.
        /// </param>
        void SetParameter(TParameter parameter);
    }
}

