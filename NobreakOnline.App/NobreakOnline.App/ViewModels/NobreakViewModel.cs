using Plugin.Battery;
using Plugin.Battery.Abstractions;
using System.Windows.Input;
using Xamarin.Forms;

namespace NobreakOnline.App.ViewModels
{
    public class NobreakViewModel : BaseViewModel
    {
        private string _nobreakChargePercent;
        public string NobreakChargePercent
        {
            get { return _nobreakChargePercent; }
            set { SetProperty(ref _nobreakChargePercent, value); }
        }

        private string _phoneChargePercent;
        public string PhoneChargePercent
        {
            get { return _phoneChargePercent; }
            set { SetProperty(ref _phoneChargePercent, value); }
        }

        private string _imagePhoneBattery;
        public string ImagePhoneBattery
        {
            get
            {
                if (Device.RuntimePlatform == Device.UWP)
                    _imagePhoneBattery = $"Assets/{_imagePhoneBattery}";

                return _imagePhoneBattery;
            }
            set { SetProperty(ref _imagePhoneBattery, value); }
        }

        private string _messageInfo;
        public string MessageInfo
        {
            get { return _messageInfo; }
            set { SetProperty(ref _messageInfo, value); }
        }

        private ICommand _powerCommand;
        public ICommand PowerCommand
        {
            get
            {
                if (_powerCommand == null)
                    _powerCommand = new Command(ExecutePowerCommand);

                return _powerCommand;
            }
        }

        private async void ExecutePowerCommand()
        {
            await App.Current.MainPage.DisplayAlert("Nobreak Online", "NOBREAK ONLINE NÃO PODE SER DESLIGADO!", "OK");
        }

        public NobreakViewModel()
        {
            if (CrossBattery.IsSupported)
            {
                CrossBattery.Current.BatteryChanged += Current_BatteryChanged;
                Current_BatteryChanged(this, new BatteryChangedEventArgs());
            }
        }

        private void Current_BatteryChanged(object sender, BatteryChangedEventArgs e)
        {
            var fakeNobreakChargePercent = e.RemainingChargePercent + 50;

            NobreakChargePercent = (fakeNobreakChargePercent > 100 || Device.RuntimePlatform == Device.UWP) ? "100%" : $"{fakeNobreakChargePercent}%";
            PhoneChargePercent = $"{e.RemainingChargePercent}%";
            ImagePhoneBattery = e.Status.ToString();

            if (e.PowerSource.Equals(PowerSource.Usb))
            {
                ImagePhoneBattery = "PhoneBatteryOnInUSB.png";
                MessageInfo = "Dispositivo conectado ao Nobreak Online!";
                return;
            }

            if (e.PowerSource.Equals(PowerSource.Ac))
            {
                ImagePhoneBattery = "PhoneBatteryOnInAC.png";
                MessageInfo = "Rede de energia conectada ao Nobreak Online!";
                return;
            }

            ImagePhoneBattery = "PhoneBatteryOff.png";
            MessageInfo = "*Dispositivo ou rede de energia desconectado!";
        }
    }
}
