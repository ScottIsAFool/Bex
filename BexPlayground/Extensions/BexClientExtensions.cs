using System;
using Windows.Storage;
using Bex;
using Newtonsoft.Json;

namespace BexPlayground.Extensions
{

    public static class BexClientExtensions
    {

        private const string CredentialsContainerKey = "Credentials";
        private const string CredentialsValueKey = "MicrosoftHealthCredentials";

        /// <summary>
        /// Loads credentials from the current settings storage, if available.
        /// </summary>
        /// <param name="bexClient">The BexClient to set credentials on.</param>
        public static void LoadCredentialsFromStorage( this IBexClient bexClient )
        {
            if(null == bexClient)
                throw new ArgumentNullException(nameof(bexClient));
            var data = ApplicationData.Current.LocalSettings;
            if (data.Containers.ContainsKey( BexClientExtensions.CredentialsContainerKey ))
            {
                var creds = data.Containers[ BexClientExtensions.CredentialsContainerKey ];

                if (false == creds.Values.ContainsKey( BexClientExtensions.CredentialsValueKey ))
                    return;

                var json = (string) creds.Values[ BexClientExtensions.CredentialsValueKey ];
                if (string.IsNullOrEmpty( json ))
                    return;

                var deets = JsonConvert.DeserializeObject<LiveIdCredentials>( json );
                if (null == deets)
                    return;

                bexClient.SetCredentials( deets );
            }
        }

        /// <summary>
        /// Saves credentials from the client to storage.
        /// </summary>
        /// <param name="bexClient">The BexClient to save credentials from.</param>
        public static void SaveCredentialsToStorage(this IBexClient bexClient)
        {
            if (null == bexClient)
                throw new ArgumentNullException(nameof(bexClient));

            SaveCredentials(bexClient.Credentials);

        }

        private static void SaveCredentials( LiveIdCredentials credentials )
        {
            var data = ApplicationData.Current.LocalSettings;
            ApplicationDataContainer creds;
            if (false == data.Containers.ContainsKey( BexClientExtensions.CredentialsContainerKey ))
            {
                creds = data.CreateContainer( BexClientExtensions.CredentialsContainerKey,
                    ApplicationDataCreateDisposition.Always );
            }
            else
            {
                creds = data.Containers[ BexClientExtensions.CredentialsContainerKey ];
            }
            creds.Values[ BexClientExtensions.CredentialsValueKey ] = JsonConvert.SerializeObject( credentials );
        }
    }
}
