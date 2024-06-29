using BeoRecruitment.Models.Entities;
using BeoRecruitment.Services;
using BeoRecruitment.Services.Interfaces;
using BeoRecruitment.ViewModels;
using BeoRecruitment.Views;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeoRecruitment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel _mainViewModel;
        private readonly IArtistsService artistsService;
        private readonly INavigationService navigationService;

        public MainPage(MainViewModel mainViewModel, IArtistsService artistsService, INavigationService navigationService)
        {
            InitializeComponent();
            _mainViewModel = mainViewModel ?? throw new ArgumentNullException(nameof(mainViewModel));
            BindingContext = _mainViewModel;
            this.artistsService = artistsService;
            this.navigationService = navigationService;
        }

        private async void ArtistsSearchBar_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            string keyword = ArtistsSearchBar.Text?.ToLower();
            if (string.IsNullOrEmpty(keyword))
            {
                SuggestionListView.ItemsSource = null; 
                return;
            }
            List<Artist> result = await artistsService.GetArtistsAsync(keyword);
            SuggestionListView.ItemsSource = result;
        }

        private async void SuggestionListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var artist = (Artist)e.SelectedItem;
            await navigationService.NavigateToAsync<ArtistViewModel, Artist>(artist);
        }
    }
}
