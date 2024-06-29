using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BeoRecruitment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNavigationPage : NavigationPage
    {
        public MainNavigationPage(MainPage root) : base(root)
        {
            InitializeComponent();
        }
    }
}
