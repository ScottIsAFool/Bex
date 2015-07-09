using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Bex.Exceptions;
using Bex.Extensions;
using Bex.Model;
using Bex.Model.Requests;
using Bex.Model.Responses;
using Newtonsoft.Json;

namespace Bex
{
    public class BexClient : IBexClient
    {
        public const string RedirectUri = "https://login.live.com/oauth20_desktop.srf";
        private const string BaseHealthUri = "https://api.microsofthealth.net/v1/me/";
        private const string AuthUrl = "https://login.live.com/oauth20_authorize.srf";
        private const string SignOutUrl = "https://login.live.com/oauth20_logout.srf";
        private const string TokenUrl = "https://login.live.com/oauth20_token.srf";

        private readonly HttpClient _httpClient;

        /// <summary>
        /// Gets the client secret. This can be got from https://account.live.com/developers/applications
        /// </summary>
        public string ClientSecret { get; }

        /// <summary>
        /// Gets the client identifier. This can be got from https://account.live.com/developers/applications
        /// </summary>
        public string ClientId { get; }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        public LiveIdCredentials Credentials { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="BexClient"/> class.
        /// </summary>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="clientId">The client identifier.</param>
        public BexClient(string clientSecret, string clientId)
            : this(clientSecret, clientId, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BexClient"/> class.
        /// </summary>
        /// <param name="clientSecret">The client secret.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="handler">The handler.</param>
        public BexClient(string clientSecret, string clientId, HttpMessageHandler handler)
        {
            ClientSecret = clientSecret;
            ClientId = clientId;

            var messageHandler = handler ??
                                 new HttpClientHandler
                                 {
                                     AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip
                                 };

            _httpClient = new HttpClient(messageHandler);
        }

        /// <summary>
        /// Sets the credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        public void SetCredentials(LiveIdCredentials credentials)
        {
            Credentials = credentials;
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"bearer {Credentials.AccessToken}");
        }

        /// <summary>
        /// Clears the credentials.
        /// </summary>
        public void ClearCredentials()
        {
            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            Credentials = null;
        }

        /// <summary>
        /// Creates the authentication URL.
        /// </summary>
        /// <param name="scopes">The scopes.</param>
        /// <returns></returns>
        public string CreateAuthenticationUrl(IEnumerable<Scope> scopes)
        {
            var uriBuilder = new UriBuilder(AuthUrl);
            var query = new StringBuilder();

            query.AppendFormat("redirect_uri={0}", Uri.EscapeUriString(RedirectUri));
            query.AppendFormat("&client_id={0}", Uri.EscapeUriString(ClientId));

            var scopesString = string.Join(" ", scopes.Select(x => x.GetDescription()));
            query.AppendFormat("&scope={0}", Uri.EscapeUriString(scopesString));
            query.Append("&response_type=code");

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri.ToString();
        }

        /// <summary>
        /// Creates the sign out URL.
        /// </summary>
        /// <returns></returns>
        public string CreateSignOutUrl()
        {
            UriBuilder uriBuilder = new UriBuilder(SignOutUrl);
            var query = new StringBuilder();

            query.AppendFormat("redirect_uri={0}", Uri.EscapeUriString(RedirectUri));
            query.AppendFormat("&client_id={0}", Uri.EscapeUriString(ClientId));

            uriBuilder.Query = query.ToString();

            return uriBuilder.Uri.ToString();
        }

        /// <summary>
        /// Exchanges the code.
        /// </summary>
        /// <param name="code">The code. If performing a refresh of the token, this should be the RefreshToken</param>
        /// <param name="isTokenRefresh">if set to <c>true</c> [is token refresh].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">code cannot be null or empty</exception>
        public async Task<LiveIdCredentials> ExchangeCodeAsync(string code, bool isTokenRefresh = false, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(nameof(code), "code cannot be null or empty");
            }

            var postData = new Dictionary<string, string>
            {
                {"redirect_uri", Uri.EscapeUriString(RedirectUri)},
                {"client_id", Uri.EscapeUriString(ClientId)},
                {"client_secret", Uri.EscapeUriString(ClientSecret)}
            };

            if (isTokenRefresh)
            {
                postData.Add("refresh_token", Uri.EscapeUriString(code));
                postData.Add("grant_type", "refresh_token");
            }
            else
            {
                postData.Add("code", Uri.EscapeUriString(code));
                postData.Add("grant_type", "authorization_code");
            }

            var response = await GetResponse<LiveIdCredentials>("", postData, cancellationToken, TokenUrl);
            SetCredentials(response);

            return response;
        }

        /// <summary>
        /// Gets the daily summary.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The daily summary for the specified dates
        /// </returns>
        public Task<SummariesResponse> GetDailySummaryAsync(DateTime startTime, DateTime endTime, IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetSummaryInfo(startTime, endTime, "Daily", deviceIds, maxItemsToReturn, cancellationToken);
        }

        /// <summary>
        /// Gets the summary for today.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<SummariesResponse> GetTodaysSummaryAsync(IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetDailySummaryAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, deviceIds, maxItemsToReturn, cancellationToken);
        }

        /// <summary>
        /// Gets the hourly summary.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public Task<SummariesResponse> GetHourlySummaryAsync(DateTime startTime, DateTime endTime, IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetSummaryInfo(startTime, endTime, "Hourly", deviceIds, maxItemsToReturn, cancellationToken);
        }

        /// <summary>
        /// Gets the hourly summary for today.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The hourly summary for today
        /// </returns>
        public Task<SummariesResponse> GetTodaysHourlySummaryAsync(IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return GetHourlySummaryAsync(DateTime.UtcNow.AddDays(-1), DateTime.UtcNow, deviceIds, maxItemsToReturn, cancellationToken);
        }

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The user's profile</returns>
        public async Task<Profile> GetProfileAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await ValidateCredentials();

            var response = await GetResponse<Profile>("Profile", new Dictionary<string, string>(), cancellationToken);

            return response;
        }

        /// <summary>
        /// Gets the devices.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of devices for the user</returns>
        public async Task<IEnumerable<Device>> GetDevicesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await ValidateCredentials();

            var response = await GetResponse<DevicesResponse>("Devices", new Dictionary<string, string>(), cancellationToken);

            return response != null ? response.Devices : new List<Device>();
        }

        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Details about the specified device</returns>
        /// <exception cref="ArgumentNullException">Device ID cannot be null or empty</exception>
        public async Task<Device> GetDeviceAsync(string deviceId, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(deviceId))
            {
                throw new ArgumentNullException(nameof(deviceId), "Device ID cannot be null or empty");
            }

            await ValidateCredentials();

            var path = $"Devices/{deviceId}";
            var response = await GetResponse<Device>(path, new Dictionary<string, string>(), cancellationToken);

            return response;
        }

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        public async Task<ActivitiesResponse> GetActivitiesAsync(ActivitiesRequest request = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            await ValidateCredentials();

            var postData = request != null ? request.ToDictionary() : new Dictionary<string, string>();

            var response = await GetResponse<ActivitiesResponse>("Activities", postData, cancellationToken);

            return response;
        }

        private async Task<SummariesResponse> GetSummaryInfo(DateTime startTime, DateTime endTime, string period, IEnumerable<string> deviceIds, int? maxItemsToReturn, CancellationToken cancellationToken)
        {
            await ValidateCredentials();

            var startTimeString = startTime.ToString("O");
            var endtimeString = endTime.ToString("O");

            var postData = new Dictionary<string, string>
            {
                { "startTime", startTimeString },
                { "endTime", endtimeString }
            };

            if (deviceIds != null)
            {
                if (deviceIds.Count > 1)
                {
                    throw new BexException("TooManyDevices", "The preview currently only supports one device.");
                }

                var devices = string.Join(",", deviceIds);
                postData.Add("deviceIds", devices);
            }

            if (maxItemsToReturn.HasValue)
            {
                postData.Add("maxPageSize", maxItemsToReturn.Value.ToString());
            }

            var path = $"Summaries/{period}";

            return await GetResponse<SummariesResponse>(path, postData, cancellationToken);
        }

        private async Task<TReturnType> GetResponse<TReturnType>(string path, Dictionary<string, string> postData, CancellationToken cancellationToken = default(CancellationToken), string altBaseUrl = null)
        {
            var uri = new UriBuilder(altBaseUrl ?? BaseHealthUri);
            uri.Path += path;

            var queryParams = string.Join("&", postData.Select(x => $"{x.Key}={x.Value}"));
            uri.Query = queryParams;

            var response = await _httpClient.GetAsync(uri.Uri, cancellationToken);

            //response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<TReturnType>(responseString);
            return item;
        }

        private Task<bool> ValidateCredentials()
        {
            if (string.IsNullOrEmpty(Credentials?.AccessToken))
            {
                throw new BexException("NoCreds", "No valid credentials have been set");
            }

            return Task.FromResult(true);
        }
    }
}
