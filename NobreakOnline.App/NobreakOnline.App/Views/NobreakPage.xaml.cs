using NobreakOnline.App.ViewModels;
using Xamarin.Forms;

namespace NobreakOnline.App.Views
{
    public partial class NobreakPage : ContentPage
    {
        public NobreakPage()
        {
            InitializeComponent();

            BindingContext = new NobreakViewModel();
        }
    }
}
