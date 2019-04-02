// ReSharper disable InconsistentNaming

using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum ProjectType
    {
        [Description(".csproj")] CSharp,
        [Description(".vbproj")] VBNET,
        [Description(".vcxproj")] VisualCPlusPlus,
        [Description(".dbproj")] DatabaseProject,
        [Description(".fsproj")] FSharp,
        [Description(".pyproj")] IronPython,
        [Description(".rbproj")] IronRuby,
        [Description(".wixproj")] WindowsInstallerXMLWiX,
        [Description(".vdproj")] VisualStudioDeploymentProject,
        [Description(".isproj")] InstallShield,
        [Description(".pssproj")] PowerShell,
        [Description(".modelproj")] ModelingProject
    }
}