using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum MsBuildTarget
    {
        [Description("Microsoft.CSharp.targets")] CSharp,
        [Description("Microsoft.VisualBasic.targets")] VisualBasic,
        [Description("Microsoft.Common.targets")] Common,
        [Description("Microsoft.WebApplication.targets")] WebApplication,
        [Description("Microsoft.TypeScript.targets")] TypeScript
    }
}