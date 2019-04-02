using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum ProjectDebugType
    {
        [Description("full")] Full,
        [Description("pdbonly")] Pdb
    }
}