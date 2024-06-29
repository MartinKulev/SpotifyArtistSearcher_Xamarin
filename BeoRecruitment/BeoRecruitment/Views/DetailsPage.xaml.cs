using System.Collections.ObjectModel;
using BeoRecruitment.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeoRecruitment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public DetailsPage(DetailsViewModel detailsViewModel)
        {
            BindingContext = detailsViewModel;
            InitializeComponent();
        }

        private void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // Deselect Item
            ((ListView)sender).SelectedItem = null;

            if (e.Item is string item)
            {
                _ = DisplayAlert(item, "What an excelent choice!", "OK");
            }
        }
    }
}

