// ReSharper disable InconsistentNaming

using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum TargetFrameworkVersion
    {
        [Description("v2.0")] Framework_2_0,
        [Description("v3.0")] Framework_3_0,
        [Description("v3.5")] Framework_3_5,
        [Description("v3.5.1")] Framework_3_5_1,
        [Description("v4.0")] Framework_4_0,
        [Description("v4.5")] Framework_4_5,
        [Description("v4.5.1")] Framework_4_5_1,
        [Description("v4.5.2")] Framework_4_5_2,
        [Description("v4.6")] Framework_4_6,
        [Description("v4.6.1")] Framework_4_6_1,
        [Description("v4.6.2")] Framework_4_6_2
    }
}