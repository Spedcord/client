using ReactiveUI;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;

namespace SpedcordClient.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public string VersionText => Program.Version;
        private static MainViewModel Instance;

        private const int BTN_HOME = 0;
        private const int BTN_COMP = 1;
        private const int BTN_JOBS = 2;
        private const int BTN_OPTS = 3;
        private bool[] btnEnabled = new bool[4];

        public static void ChangePage(int idx)
        {
            switch (idx)
            {
                case BTN_HOME:
                    Instance.BtnHomeClick();
                    break;
                case BTN_COMP:
                    Instance.BtnCompanyClick();
                    break;
                case BTN_JOBS:
                    Instance.BtnJobsClick();
                    break;
                case BTN_OPTS:
                    Instance.BtnSettingsClick();
                    break;
            }
        }

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

        private int selectedContent;
        public int SelectedContent
        {
            get => selectedContent;
            set => this.RaiseAndSetIfChanged(ref selectedContent, value);
        }

        public bool BtnHomeEnabled
        {
            get => btnEnabled[BTN_HOME];
            set => this.RaiseAndSetIfChanged(ref btnEnabled[BTN_HOME], value);
        }

        public bool BtnCompanyEnabled
        {
            get => btnEnabled[BTN_COMP];
            set => this.RaiseAndSetIfChanged(ref btnEnabled[BTN_COMP], value);
        }

        public bool BtnJobsEnabled
        {
            get => btnEnabled[BTN_JOBS];
            set => this.RaiseAndSetIfChanged(ref btnEnabled[BTN_JOBS], value);
        }

        public bool BtnSettingsEnabled
        {
            get => btnEnabled[BTN_OPTS];
            set => this.RaiseAndSetIfChanged(ref btnEnabled[BTN_OPTS], value);
        }

        public MainViewModel()
        {
            BtnHomeEnabled = false;
            BtnCompanyEnabled = true;
            BtnJobsEnabled = true;
            BtnSettingsEnabled = true;
            Instance = this;
        }

        public void BtnClick()
        {
            CloseSidebar = !CloseSidebar;
            OpenSidebar = !CloseSidebar;
        }

        public void ResetButtonStates()
        {
            BtnHomeEnabled = true;
            BtnCompanyEnabled = true;
            BtnJobsEnabled = true;
            BtnSettingsEnabled = true;
        }

        public void BtnHomeClick()
        {
            SelectedContent = BTN_HOME; // Home
            ResetButtonStates();
            BtnHomeEnabled = false;
        }

        public void BtnCompanyClick()
        {
            SelectedContent = BTN_COMP; // Company
            ResetButtonStates();
            BtnCompanyEnabled = false;
        }

        public void BtnJobsClick()
        {
            SelectedContent = BTN_JOBS; // Jobs
            ResetButtonStates();
            BtnJobsEnabled = false;
        }

        public void BtnSettingsClick()
        {
            SelectedContent = BTN_OPTS; // Settings
            ResetButtonStates();
            BtnSettingsEnabled = false;
        }
    }
}
