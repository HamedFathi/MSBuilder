using System;
using System.Collections.Generic;
using System.IO;
using MSBuilder.Enums;

namespace MSBuilder
{
    public class SolutionWriter
    {
        private string _guid = "";
        public string Name { get; set; }
        public string Directory { get; set; }
        public bool CreateNugetPackageFolder { get; set; } = false;


        public VisualStudioVersion CurrentVersion { get; set; } = VisualStudioVersion.Vs2015;
        public VisualStudioVersion MinimumVersion { get; set; } = VisualStudioVersion.Vs2010;
        public string SolutionId => _guid;
        public List<ProjectWriter> Projects { get; set; }

        public SolutionWriter(string name, string path)
        {
            _guid = Guid.NewGuid().ToString("B");

            Name = name;
            Directory = path;
            if (Path.HasExtension(Directory))
            {
                throw new Exception("You should set directory path not file path!");
            }

        }

        public string ToXml() => SolutionGenerator.Generate(this);


        public void Save()
        {
            if (Projects.Count < 1)
            {
                throw new Exception("You didn't set any project!");
            }
            foreach (var item in Projects)
            {
                item.Save();
            }
            if (!System.IO.Directory.Exists(Directory))
            {
                System.IO.Directory.CreateDirectory(Directory);
            }

            var nugetPkg = Directory + Path.DirectorySeparatorChar+"packages";
            if (CreateNugetPackageFolder && !System.IO.Directory.Exists(nugetPkg))
            {
                System.IO.Directory.CreateDirectory(nugetPkg);
            }

            var slnFolder = Directory + Path.DirectorySeparatorChar + Name + ".sln";
            File.WriteAllText(slnFolder, ToXml());
        }
    }
}