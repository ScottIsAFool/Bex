using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bex.Model;
using Bex.Model.Requests;
using Bex.Model.Responses;

namespace Bex
{
    public interface IBexClient
    {
        /// <summary>
        /// Gets the client secret. This can be got from https://account.live.com/developers/applications
        /// </summary>
        string ClientSecret { get; }

        /// <summary>
        /// Gets the client identifier. This can be got from https://account.live.com/developers/applications
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Gets the credentials.
        /// </summary>
        LiveIdCredentials Credentials { get; }

        /// <summary>
        /// Sets the credentials.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        void SetCredentials(LiveIdCredentials credentials);

        /// <summary>
        /// Clears the credentials.
        /// </summary>
        void ClearCredentials();

        /// <summary>
        /// Creates the authentication URL.
        /// </summary>
        /// <param name="scopes">The scopes.</param>
        /// <param name="redirectUrl">This is optional. If using a WebAuthenticationBroker, don't set this, if you're using a website, you may want to set it</param>
        /// <returns></returns>
        string CreateAuthenticationUrl(IEnumerable<Scope> scopes, string redirectUrl = null);

        /// <summary>
        /// Refreshes the access code using the refresh token held within the current credentials.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Credentials with a refreshed access code.</returns>
        Task<LiveIdCredentials> RefreshAccessCodeFromCredentialsAsync(
            CancellationToken cancellationToken = default(CancellationToken) );

        /// <summary>
        /// Creates the sign out URL.
        /// </summary>
        /// <returns></returns>
        string CreateSignOutUrl();

        /// <summary>
        /// Signs out from Microsoft Health.
        /// </summary>
        /// <returns>Whether the signout HTTP request returned a success status code.</returns>
        Task<bool> SignOutAsync();

        /// <summary>
        /// Exchanges the code.
        /// </summary>
        /// <param name="code">The code. If performing a refresh of the token, this should be the RefreshToken</param>
        /// <param name="isTokenRefresh">if set to <c>true</c> [is token refresh].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">code cannot be null or empty</exception>
        Task<LiveIdCredentials> ExchangeCodeAsync(string code, bool isTokenRefresh = false, CancellationToken cancellationToken = default(CancellationToken));

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
        Task<SummariesResponse> GetDailySummaryAsync(DateTime startTime, DateTime endTime, IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the summary for today.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SummariesResponse> GetTodaysSummaryAsync(IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the hourly summary.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<SummariesResponse> GetHourlySummaryAsync(DateTime startTime, DateTime endTime, IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the hourly summary for today.
        /// </summary>
        /// <param name="deviceIds">The device ids.</param>
        /// <param name="maxItemsToReturn">The maximum items to return.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>
        /// The hourly summary for today
        /// </returns>
        Task<SummariesResponse> GetTodaysHourlySummaryAsync(IEnumerable<string> deviceIds = null, int? maxItemsToReturn = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the profile.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The user's profile</returns>
        Task<Profile> GetProfileAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the devices.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A list of devices for the user</returns>
        Task<IEnumerable<Device>> GetDevicesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Details about the specified device</returns>
        /// <exception cref="ArgumentNullException">Device ID cannot be null or empty</exception>
        Task<Device> GetDeviceAsync(string deviceId, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets the activities.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<ActivitiesResponse> GetActivitiesAsync(ActivitiesRequest request = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}