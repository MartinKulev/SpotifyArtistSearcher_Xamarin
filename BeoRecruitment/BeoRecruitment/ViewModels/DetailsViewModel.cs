using System.Collections.ObjectModel;
using BeoRecruitment.Services.Interfaces;

namespace BeoRecruitment.ViewModels
{
    public class DetailsViewModel : INavigationParameter<int>
    {
        private readonly IDataService _dataService;

        public DetailsViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        public ObservableCollection<string> Items { get; } = new ObservableCollection<string>();

        #region INavigationParameter<int>

        public void SetParameter(int parameter)
        {
            foreach (var item in _dataService.GetData(parameter))
            {
                Items.Add(item);
            }
        }

        #endregion

    }
}

