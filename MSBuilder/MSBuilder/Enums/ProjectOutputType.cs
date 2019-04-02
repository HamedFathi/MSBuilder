using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum ProjectOutputType
    {
        [Description("Exe")] ConsoleApplication,
        [Description("Library")] WebApplication,
        [Description("Library")] ClassLibrary
    }
}