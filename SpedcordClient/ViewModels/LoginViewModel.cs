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
        private bool styleClass;

        public LoginViewModel()
        {
            CurrentAddress = "https://map.spedcord.xyz";
            StyleClass = false;
        }

        public void LoginClick()
        {
            StyleClass = true;
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

        public bool StyleClass
        {
            get => styleClass;
            set => this.RaiseAndSetIfChanged(ref styleClass, value);
        }

    }
}
