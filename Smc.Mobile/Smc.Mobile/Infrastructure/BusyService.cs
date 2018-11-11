using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMC.Mobile.Infrastructure
{
    public class BusyService : IBusyService
    {
        ScopedValue<bool> isBusy;
        public BusyService()
        {
            this.isBusy = new ScopedValue<bool>();
            this.isBusy.ValueStarted += OnBusyStarted;
            this.isBusy.ValueEnded += OnBusyEnded;

        }

        public bool IsBusy => this.isBusy.Value;

        public IDisposable BeginBusy()
        {
            return this.isBusy.BeginScope(true);
        }

        private void OnBusyEnded(bool oldValue, bool newValue)
        {
            UserDialogs.Instance.HideLoading();
        }

        private void OnBusyStarted(bool oldValue, bool newValue)
        {
            UserDialogs.Instance.ShowLoading(maskType: MaskType.Black);
        }
    }
}
