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

        //private bool _execute;

        //protected override void OnAppearing()
        //{
        //    base.OnAppearing(); base.OnAppearing();

        //    _execute = true;

        //    Device.StartTimer(TimeSpan.FromMilliseconds(50), () =>
        //    {
        //        labelChargeStatus.TranslationX += 5f;

        //        if (labelChargeStatus.TranslationX > Width)
        //            labelChargeStatus.TranslationX = -labelChargeStatus.Width;

        //        return _execute;
        //    });
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    _execute = false;
        //}
    }
}
