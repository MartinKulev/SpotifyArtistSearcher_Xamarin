using BeoRecruitment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeoRecruitment.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ArtistPage : ContentPage
    {
        public ArtistPage(ArtistViewModel artistViewModel)
        {
            BindingContext = artistViewModel;
            InitializeComponent();
        }
    }
}