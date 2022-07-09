using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Text;
using WebViewControl;

namespace SpedcordClient.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {

        private string address;
        private string currentAddress;

        public LoginViewModel()
        {
            CurrentAddress = "https://map.spedcord.xyz";
        }

        public void LoginClick()
        {

        }

        public string Address
        {
            get => address;
            set => this.RaiseAndSetIfChanged(ref address, value);
        }

        public string CurrentAddress
        {
            get => currentAddress;
            set => this.RaiseAndSetIfChanged(ref currentAddress, value);
        }

    }
}
