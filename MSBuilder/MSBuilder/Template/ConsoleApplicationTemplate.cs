using MSBuilder.Enums;
using MSBuilder.Extensions;

namespace MSBuilder.Template
{
    public class ConsoleApplicationTemplate : ProjectTemplate
    {
        public ConsoleApplicationTemplate(string name, string path) : base(name, path)
        {
            Name = name;
            Path = path;
        }

        public override ProjectWriter CreateTemplate()
        {
            var project = new ProjectWriter(Name, Path);

            var imGroup1 = project.CreateImportItemGroup();
            var import1 = new ImportItem();
            import1.Project = @"$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props";
            import1.Condition = @"Exists('$(MSBuildExtensionsPath)\$(MSBuildToolsVersion)\Microsoft.Common.props')";
            imGroup1.AddImportItem(import1);

            var import2 = new ImportItem();
            import2.Project = @"$(MSBuildToolsPath)\Microsoft.CSharp.targets";
            imGroup1.AddImportItem(import2);

            var pGroup1 = project.CreatePropertyGroup();

            var prop1 = new Property("Configuration", "Debug");
            prop1.AddAttribute("Condition", " '$(Configuration)' == '' ");
            pGroup1.AddProperty(prop1);

            var prop2 = new Property("Platform", ProjectPlatformTarget.AnyCPU.GetDescription());
            prop2.AddAttribute("Condition", " '$(Platform)' == '' ");
            pGroup1.AddProperty(prop2);

            var prop3 = new Property("ProjectGuid", project.ProjectId);
            pGroup1.AddProperty(prop3);

            var prop4 = new Property("OutputType", ProjectOutputType.ConsoleApplication.GetDescription());
            pGroup1.AddProperty(prop4);

            var prop5 = new Property("AppDesignerFolder", "Properties");
            pGroup1.AddProperty(prop5);

            var prop6 = new Property("RootNamespace", Name);
            pGroup1.AddProperty(prop6);

            var prop7 = new Property("AssemblyName", Name);
            pGroup1.AddProperty(prop7);

            var prop8 = new Property("TargetFrameworkVersion", TargetFrameworkVersion.Framework_4_6_1.GetDescription());
            pGroup1.AddProperty(prop8);

            var prop9 = new Property("FileAlignment", "512");
            pGroup1.AddProperty(prop9);

            var prop10 = new Property("AutoGenerateBindingRedirects", "true");
            pGroup1.AddProperty(prop10);


            var pGroup2 = project.CreatePropertyGroup();
            pGroup2.AddAttribute("Condition", " '$(Configuration)|$(Platform)' == 'Debug|AnyCPU' ");

            var prop11 = new Property("PlatformTarget", ProjectPlatformTarget.AnyCPU.GetDescription());
            pGroup2.AddProperty(prop11);

            var prop13 = new Property("DebugType", ProjectDebugType.Full.GetDescription());
            pGroup2.AddProperty(prop13);

            var prop14 = new Property("Optimize", "false");
            pGroup2.AddProperty(prop14);

            var prop15 = new Property("OutputPath", @"bin\Debug\");
            pGroup2.AddProperty(prop15);

            var prop16 = new Property("DefineConstants", ProjectDefineConstant.Debug + ";" + ProjectDefineConstant.Trace);
            pGroup2.AddProperty(prop16);

            var prop17 = new Property("ErrorReport", "prompt");
            pGroup2.AddProperty(prop17);

            var prop18 = new Property("WarningLevel", ProjectWarningLevel.Four.GetDescription());
            pGroup2.AddProperty(prop18);

            var pGroup3 = project.CreatePropertyGroup();
            pGroup3.AddAttribute("Condition", " '$(Configuration)|$(Platform)' == 'Release|AnyCPU' ");

            var prop19 = new Property("PlatformTarget", ProjectPlatformTarget.AnyCPU.GetDescription());
            pGroup2.AddProperty(prop19);

            var prop20 = new Property("DebugType", ProjectDebugType.Pdb.GetDescription());
            pGroup3.AddProperty(prop20);

            var prop21 = new Property("Optimize", "true");
            pGroup3.AddProperty(prop21);

            var prop22 = new Property("OutputPath", @"bin\Release\");
            pGroup3.AddProperty(prop22);

            var prop23 = new Property("DefineConstants", ProjectDefineConstant.Trace.GetDescription());
            pGroup3.AddProperty(prop23);

            var prop24 = new Property("ErrorReport", "prompt");
            pGroup3.AddProperty(prop24);

            var prop25 = new Property("WarningLevel", ProjectWarningLevel.Four.GetDescription());
            pGroup3.AddProperty(prop25);

            var ref1 = project.CreateReferenceItemGroup();

            var r1 = new ReferenceItem();
            r1.Include = "System";
            ref1.AddReferenceItem(r1);

            var r2 = new ReferenceItem();
            r2.Include = "System.Core";
            ref1.AddReferenceItem(r2);

            var r3 = new ReferenceItem();
            r3.Include = "System.Xml.Linq";
            ref1.AddReferenceItem(r3);

            var r4 = new ReferenceItem();
            r4.Include = "System.Data.DataSetExtensions";
            ref1.AddReferenceItem(r4);

            var r5 = new ReferenceItem();
            r5.Include = "Microsoft.CSharp";
            ref1.AddReferenceItem(r5);

            var r6 = new ReferenceItem();
            r6.Include = "System.Data";
            ref1.AddReferenceItem(r6);

            var r7 = new ReferenceItem();
            r7.Include = "System.Net.Http";
            ref1.AddReferenceItem(r7);

            var r8 = new ReferenceItem();
            r8.Include = "System.Xml";
            ref1.AddReferenceItem(r8);


            var cGroup1 = project.CreateCompileItemGroup();
            var c1 = new CompileItem();
            c1.Include = "Program.cs";
            cGroup1.AddCompileItem(c1);

            var c2 = new CompileItem();
            c2.Include = @"Properties\AssemblyInfo.cs";
            cGroup1.AddCompileItem(c2);

            var nGroup1 = project.CreateNoneItemGroup();
            var n1 = new NoneItem();
            n1.Include = @"App.config";
            nGroup1.AddNoneItem(n1);


            return project;
        }
    }
}
