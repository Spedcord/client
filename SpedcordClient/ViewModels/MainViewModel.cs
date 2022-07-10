using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpedcordClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool closeSidebar;
        public bool CloseSidebar
        {
            get => closeSidebar;
            set => this.RaiseAndSetIfChanged(ref closeSidebar, value);
        }

        private bool openSidebar;
        public bool OpenSidebar
        {
            get => openSidebar;
            set => this.RaiseAndSetIfChanged(ref openSidebar, value);
        }

        private bool showButtonText;
        public bool ShowButtonText
        {
            get => showButtonText;
            set => this.RaiseAndSetIfChanged(ref showButtonText, value);
        }

        private int selectedContent;
        public int SelectedContent
        {
            get => selectedContent;
            set => this.RaiseAndSetIfChanged(ref selectedContent, value);
        }

        public MainViewModel()
        {
            ShowButtonText = true;
        }

        public void BtnClick()
        {
            CloseSidebar = !CloseSidebar;
            OpenSidebar = !CloseSidebar;
            ShowButtonText = OpenSidebar;
        }

        public void BtnHomeClick()
        {
            SelectedContent = 0; // Home
        }

        public void BtnCompanyClick()
        {
            SelectedContent = 1; // Company
        }

        public void BtnJobsClick()
        {
            SelectedContent = 2; // Jobs
        }

        public void BtnSettingsClick()
        {
            SelectedContent = 3; // Settings
        }
    }
}
