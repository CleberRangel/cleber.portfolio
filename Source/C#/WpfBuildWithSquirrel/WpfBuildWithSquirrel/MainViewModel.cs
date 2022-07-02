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
        private string _gitHubUpdateSite;
        private bool _newVersionAvailable;
        private string? _applicationVersion;
        private string? _newApplicationVersion;

        public MainViewModel(string gitHubRepo)
        {
            _applicationVersion = $"{Assembly.GetExecutingAssembly().GetName().Version}";
            _gitHubUpdateSite = gitHubRepo;

            UpdateApplicationCommand = new AsyncRelayCommand(UpdateApplication);
            CheckUpdateCommand = new RelayCommand(CheckUpdate);
        }

        private async void CheckUpdate()
        {
            try
            {
                using (var updateManager = new GithubUpdateManager(_gitHubUpdateSite))
                {
                    if (updateManager.IsInstalledApp is true)
                    {
                        var updateInfo = await updateManager.CheckForUpdate();

                        if (updateInfo is not null)
                        {
                            if (updateInfo.CurrentlyInstalledVersion != updateInfo.FutureReleaseEntry)
                            {
                                NewVersionAvailable = true;
                                NewApplicationVersion = $"{updateInfo.FutureReleaseEntry.Version}";
                                return;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR!");

            }

            NewApplicationVersion = "No new version found!";
            NewVersionAvailable = false;
            return;
        }

        private async Task UpdateApplication()
        {
            using (var updateManager = new GithubUpdateManager(_gitHubUpdateSite))
            {
                await updateManager.UpdateApp();

                UpdateManager.RestartApp();
            }
        }

        public ICommand UpdateApplicationCommand { get; }
        public ICommand CheckUpdateCommand { get; }
        public bool NewVersionAvailable
        {
            get => _newVersionAvailable;
            set => SetProperty(ref _newVersionAvailable, value);
        }
        public string? ApplicationVersion
        {
            get => _applicationVersion;
            set => SetProperty(ref _applicationVersion, value);
        }

        public string? NewApplicationVersion
        {
            get => _newApplicationVersion;
            set => SetProperty(ref _newApplicationVersion, value);
        }
    }
}
