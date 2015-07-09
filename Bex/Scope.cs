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
        Profile
    }
}
