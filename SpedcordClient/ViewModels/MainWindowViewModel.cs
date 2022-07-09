using Avalonia.Controls.ApplicationLifetimes;
using ReactiveUI;
using SpedcordClient.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SpedcordClient.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ViewModelBase content;
        public ViewModelBase Content
        {
            get => content;
            private set => this.RaiseAndSetIfChanged(ref content, value);
        }

        public MainWindowViewModel()
        {
            Content = new LoginViewModel();
        }
    }
}
