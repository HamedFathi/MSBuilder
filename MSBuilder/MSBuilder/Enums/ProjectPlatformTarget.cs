using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum ProjectPlatformTarget
    {
        [Description("AnyCPU")]
        AnyCPU,
        [Description("x86")]
        x86,
        [Description("x64")]
        x64
    }
}