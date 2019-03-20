using Plugin.Battery;
using Plugin.Battery.Abstractions;
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

        private string _chargeStatus;
        public string ChargeStatus
        {
            get { return _chargeStatus; }
            set { SetProperty(ref _chargeStatus, value); }
        }

        private string _messageInfo;
        public string MessageInfo
        {
            get { return _messageInfo; }
            set { SetProperty(ref _messageInfo, value); }
        }

        private Color _ledIndicator;
        public Color LedIndicator
        {
            get { return _ledIndicator; }
            set { SetProperty(ref _ledIndicator, value); }
        }

        public NobreakViewModel()
        {
            if (CrossBattery.IsSupported)
                CrossBattery.Current.BatteryChanged += Current_BatteryChanged;
        }

        private void Current_BatteryChanged(object sender, BatteryChangedEventArgs e)
        {
            NobreakChargePercent = $"{e.RemainingChargePercent + 10}%";
            PhoneChargePercent = $"{e.RemainingChargePercent}%";
            ChargeStatus = e.Status.ToString();


            if (e.Status.Equals(BatteryStatus.Charging) && !e.IsLow)
                LedIndicator = Color.LightGreen;

            if (e.Status.Equals(BatteryStatus.NotCharging) && e.IsLow)
                LedIndicator = Color.Red;

            if (e.PowerSource.Equals(PowerSource.Usb))
            {
                MessageInfo = $"Um dispositivo foi conectado ao Nobreak Online!";
                return;
            }

            if (e.PowerSource.Equals(PowerSource.Ac))
            {
                MessageInfo = $"A sua rede de energia foi conectada ao Nobreak Online!";
                return;
            }

            MessageInfo = string.Empty;
        }
    }
}
