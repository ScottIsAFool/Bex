namespace BexPlayground.Extensions
{
    using System;
    using Windows.Storage;
    using Bex;
    using Newtonsoft.Json;

    public static class BexClientExtensions
    {

        public static void LoadCredentialsFromStorage( this IBexClient bexClient )
        {
            var data = ApplicationData.Current.LocalSettings;
            if (data.Containers.ContainsKey( "Credentials" ))
            {
                var creds = data.Containers[ "Credentials" ];

                var json = (string) creds.Values[ "MicrosoftHealthCredentials" ];
                if (string.IsNullOrEmpty( json ))
                    return;

                var deets = JsonConvert.DeserializeObject<LiveIdCredentials>( json );
                if (null == deets)
                    return;

                bexClient.SetCredentials( deets );
            }
        }

        public static void SaveCredentialsToStorage(this IBexClient bexClient)
        {
            if (null == bexClient)
                throw new ArgumentNullException(nameof(bexClient));

            SaveCredentials(bexClient.Credentials);

        }

        private static void SaveCredentials(LiveIdCredentials credentials)
        {
            var data = ApplicationData.Current.LocalSettings;
            ApplicationDataContainer creds;
            if (false == data.Containers.ContainsKey("Credentials"))
            {
                creds = data.CreateContainer("Credentials", ApplicationDataCreateDisposition.Always);
            }
            else
            {
                creds = data.Containers["Credentials"];
            }
            creds.Values["MicrosoftHealthCredentials"] = JsonConvert.SerializeObject(credentials);
        }
    }
}
