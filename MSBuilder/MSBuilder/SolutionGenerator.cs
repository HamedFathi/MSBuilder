using System.Collections.Generic;
using System.IO;
using System.Text;
using MSBuilder.Extensions;

namespace MSBuilder
{
    internal class SolutionGenerator
    {
        internal static string Generate(SolutionWriter solution)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Microsoft Visual Studio Solution File, Format Version 12.00");
            sb.AppendLine("# Visual Studio 14");
            sb.AppendLine("VisualStudioVersion = " + solution.CurrentVersion.GetDescription());
            sb.AppendLine("MinimumVisualStudioVersion = " + solution.MinimumVersion.GetDescription());
            sb.AppendLine(SolutionProjectBlockGenerator(solution.SolutionId, solution.Projects));
            sb.AppendLine(SolutionGlobalBlockGenerator(solution.Projects));
            return sb.ToString();
        }

        private static string SolutionGlobalBlockGenerator(List<ProjectWriter> projects)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Global");
            sb.AppendLine("\tGlobalSection(SolutionConfigurationPlatforms) = preSolution");
            sb.AppendLine("\t\tDebug|Any CPU = Debug|Any CPU");
            sb.AppendLine("\t\tRelease|Any CPU = Release|Any CPU");
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("\tGlobalSection(ProjectConfigurationPlatforms) = postSolution");
            foreach (var solutionProject in projects)
            {
                var template =
                    $"\tProject({solutionProject.ProjectId}" + ".Debug | Any CPU.ActiveCfg = Debug | Any CPU\n" +
                    $"\tProject({solutionProject.ProjectId}" + ".Debug|Any CPU.Build.0 = Debug|Any CPU\n" +
                    $"\tProject({solutionProject.ProjectId}" + ".Release|Any CPU.ActiveCfg = Release|Any CPU\n" +
                    $"\tProject({solutionProject.ProjectId}" + ".Release|Any CPU.Build.0 = Release|Any CPU";
                sb.AppendLine(template);
            }
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("\tGlobalSection(SolutionProperties) = preSolution");
            sb.AppendLine("\t\tHideSolutionNode = FALSE");
            sb.AppendLine("\tEndGlobalSection");
            sb.AppendLine("EndGlobal");

            return sb.ToString();
        }

        private static string SolutionProjectBlockGenerator(string solutionId, List<ProjectWriter> projects)
        {
            var sb = new StringBuilder();


            foreach (var solutionProject in projects)
            {
                var template =
                    $"Project(\"{solutionId}\") = \"{solutionProject.Name}\", \"{solutionProject.Directory + Path.DirectorySeparatorChar + solutionProject.Name + ".csproj"}\", \"{solutionProject.ProjectId}\"\nEndProject";
                sb.AppendLine(template);
            }
            return sb.ToString();
        }
    }
}