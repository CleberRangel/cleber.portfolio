using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Squirrel;
using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfBuildWithSquirrel
{
    public sealed class MainViewModel : ObservableRecipient
    {
        private string _GitHubUpdateSite;
        private bool _NewVersionAvailable;
        private string? _ApplicationVersion;
        private string? _NewApplicationVersion;

        public MainViewModel(string gitHubRepo)
        {
            _ApplicationVersion = $"{Assembly.GetExecutingAssembly().GetName().Version}";
            _GitHubUpdateSite = gitHubRepo;

            UpdateApplicationCommand = new AsyncRelayCommand(UpdateApplication);
            CheckUpdateCommand = new RelayCommand(CheckUpdate);
        }

        private async void CheckUpdate()
        {
            try
            {
                using (var updateManager = new GithubUpdateManager(_GitHubUpdateSite))
                {
                    if (updateManager.IsInstalledApp is false)
                    {
                        NewApplicationVersion = "No new version found!";
                        return;
                    }

                    var updateInfo = await updateManager.CheckForUpdate();

                    if (updateInfo is not null)
                    {
                        NewVersionAvailable = true;
                        NewApplicationVersion = $"{updateInfo.FutureReleaseEntry.Version}";
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            NewVersionAvailable = false;
        }

        private async Task UpdateApplication()
        {
            using (var updateManager = new GithubUpdateManager(_GitHubUpdateSite))
            {
                await updateManager.UpdateApp();

                UpdateManager.RestartApp();
            }
        }

        public ICommand UpdateApplicationCommand { get; }
        public ICommand CheckUpdateCommand { get; }
        public bool NewVersionAvailable
        {
            get => _NewVersionAvailable;
            set => SetProperty(ref _NewVersionAvailable, value);
        }
        public string? ApplicationVersion
        {
            get => _ApplicationVersion;
            set => SetProperty(ref _ApplicationVersion, value);
        }

        public string? NewApplicationVersion 
        { 
            get => _NewApplicationVersion; 
            set => SetProperty(ref _NewApplicationVersion, value); 
        }
    }
}
