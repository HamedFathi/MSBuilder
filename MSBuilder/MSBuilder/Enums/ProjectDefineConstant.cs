using System.ComponentModel;

namespace MSBuilder.Enums
{
    public enum ProjectDefineConstant
    {
        [Description("DEBUG")] Debug,
        [Description("TRACE")] Trace,
        [Description("RELEASE")] Release,
        [Description("THREAD_SAFE")] ThreadSafe
    }
}