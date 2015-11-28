using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation.Collections;
using Windows.Security.Authentication.Web;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using Bex;
using Bex.Model.Requests;
using Newtonsoft.Json;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace BexPlayground
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (App.BexClient.Credentials == null)
            {
                var data = ApplicationData.Current.LocalSettings;
                if (data.Containers.ContainsKey("Credentials"))
                {
                    var creds = data.Containers["Credentials"];
                    var json = (string)creds.Values["Credentials"];
                    if (!string.IsNullOrEmpty(json))
                    {
                        var deets = JsonConvert.DeserializeObject<LiveIdCredentials>(json);

                        App.BexClient.SetCredentials(deets);
                    }
                }
            }
        }

        private async void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            if (App.BexClient.Credentials != null)
            {
                App.BexClient.ClearCredentials();
                return;
            }

            var url = App.BexClient.CreateAuthenticationUrl(new List<Scope>
            {
                Scope.ActivityHistory,
                Scope.ActivityLocation,
                Scope.Devices,
                Scope.Profile
            });

            WebAuthenticationBroker.AuthenticateAndContinue(new Uri(url), new Uri(BexClient.RedirectUri), new ValueSet(), WebAuthenticationOptions.None);
        }

        private async void ProfileButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var profile = await App.BexClient.GetProfileAsync();
            if (profile != null)
            {
                var dialog = new MessageDialog("Signed in as " + profile.FirstName);
                await dialog.ShowAsync();
            }
        }

        private async void DevicesButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var devices = await App.BexClient.GetDevicesAsync();
            if (devices != null)
            {
                var dialog = new MessageDialog($"User has {devices.Count()} Devices");
                await dialog.ShowAsync();
            }
        }

        private async void ActivitiesButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var activities = await App.BexClient.GetActivitiesAsync(new ActivitiesRequest
            {
                ActivityFieldsToInclude = new List<ActivityFields>
                {
                    ActivityFields.Details,
                    ActivityFields.MapPoints
                },
                EndTime = new DateTime(2015, 09, 01),
                StartTime = new DateTime(2015, 03, 01)
            });

            if (activities != null)
            {
                //var dialog = new MessageDialog($"User has {activities.Count()} Devices");
                //await dialog.ShowAsync();
            }
        }
    }
}
