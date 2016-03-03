using Bex.Attributes;

namespace Bex
{
    public enum Scope
    {
        [Description("mshealth.ReadDevices")]
        Devices,

        [Description("mshealth.ReadActivityHistory")]
        ActivityHistory,

        [Description("mshealth.ReadActivityLocation")]
        ActivityLocation,

        [Description("mshealth.ReadProfile")]
        Profile,

        /// <summary>
        /// By supplying this scope, a refresh token will be provided 
        /// that can be used to get new access tokens when the supplied
        /// one expires. 
        /// </summary>
        [Description("wl.offline_access")]
        OfflineAccess
    }
}