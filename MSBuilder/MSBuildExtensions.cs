using System.IO;
using Microsoft.Build.Evaluation;

namespace MSBuilder
{
    public static class MSBuildExtensions
    {
        public static string ToText(this Project project)
        {
            var text = new StringWriter();            
            project.Save(text);
            return text.ToString();
        }
    }
}
